using ExceptionFinder.Analyzers;
using ExceptionFinder.Extensions;
using Reflector;
using Reflector.CodeModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ExceptionFinder
{
	public partial class ExceptionFinderView : UserControl
	{
		private const string XmlComment = "<Comment> ";

		public ExceptionFinderView()
			: base()
		{
			this.InitializeComponent();
		}

		private void AddContextMenuToNode(TreeNode node, IMethodDeclaration method)
		{
			if(this.ServiceProvider != null)
			{
				node.ContextMenu = new ContextMenu(new List<MenuItem>() { new MenuItem(
					"Go To Method", this.OnLocationNodeMenuItemClick) { Tag = method } }.ToArray());
			}
		}

		private TreeNode AddInstructionInformation(TreeNode node, IMethodDeclaration method, IInstruction instruction)
		{
			var childNode = node.Nodes.Add(method.ToString());

			var container = (method.DeclaringType as ITypeDeclaration).Translate();

			if(container != null)
			{
				childNode.Nodes.Add("Assembly: " + container.Assembly.FullName);
				childNode.Nodes.Add("Type: " + container.FullName);
				childNode.Nodes.Add("Method: " + method.ToString());
				
				if(instruction != null)
				{
					childNode.Nodes.Add("Location: " + instruction.Offset);				
				}

				this.AddContextMenuToNode(childNode, method);
			}
			else
			{
				childNode.Nodes.Add("Unable to resolve type for method " + method.Name);
			}

			return childNode;
		}

		private void OnLocationNodeMenuItemClick(object sender, EventArgs e)
		{
			if(this.ServiceProvider != null)
			{
				(this.ServiceProvider.GetService(typeof(IAssemblyBrowser)) as IAssemblyBrowser).ActiveItem =
					((sender as MenuItem).Tag as IMethodDeclaration);
			}
		}

		internal void ShowLeakedExceptions(IMethodDeclaration methodItem)
		{
			this.leakedExceptions.Nodes.Clear();
			this.methodName.Text = string.Empty;

			if(methodItem != null)
			{
				ExceptionFinderView.Resolve(methodItem);
				this.methodName.Text = methodItem.ToString();

				var analyzer = new MethodExceptionAnalyzer(methodItem,
					new LeakedExceptionsMethodInstructionsAnalyzerContext(OpCodeFilters.IncludeOverflow));
				analyzer.Analyze();

				var exceptionsNode = this.leakedExceptions.Nodes.Add("Exceptions");
				this.ShowLeakedExceptions(analyzer.LeakedExceptions.Exceptions,
					exceptionsNode.Nodes.Add("Documented"),
					exceptionsNode.Nodes.Add("Undocumented"));

				var nonExceptionsNode = this.leakedExceptions.Nodes.Add("Non-Exceptions");
				this.ShowLeakedExceptions(analyzer.LeakedExceptions.NonExceptions,
					nonExceptionsNode.Nodes.Add("Documented"),
					nonExceptionsNode.Nodes.Add("Undocumented"));
			}
		}

		private static void Resolve(IMethodDeclaration method)
		{
			var assemblyToResolve = ((method.DeclaringType as ITypeDeclaration).Owner as IModule).Assembly;

			if(assemblyToResolve != null)
			{
				assemblyToResolve.Load();

				foreach(IModule module in assemblyToResolve.Modules)
				{
					foreach(IAssemblyReference assemblyReferenceName in module.AssemblyReferences)
					{
						var resolvedAssembly = assemblyReferenceName.Resolve();

						if(resolvedAssembly == null)
						{
							break;
						}
						else
						{
							resolvedAssembly.Load();
						}
					}
				}
			}
		}

		internal void ShowLeakedExceptions(
			IDictionary<LeakedException, List<InstructionLocation>> leakedExceptions,
			TreeNode documentedNode, TreeNode undocumentedNode)
		{
			foreach(var pair in leakedExceptions)
			{
				var parentNode = pair.Key.DiscoveryStatuses.IsDocumented ? documentedNode : undocumentedNode;
				var typeNode = parentNode.Nodes.Add(pair.Key.Type.FullName);

				if(!pair.Key.DiscoveryStatuses.WasFoundThroughAnalysis)
				{
					typeNode.NodeFont = new Font(this.Font, FontStyle.Bold);
				}

				foreach(var location in pair.Value)
				{
					if(location.Instruction != null && location.Method != null)
					{
						var locationNode = this.AddInstructionInformation(typeNode, 
							location.Method, location.Instruction);
						
						var callStackNode = locationNode.Nodes.Add("Call Stack:");

						foreach(var callStack in location.CallStack)
						{
							this.AddInstructionInformation(callStackNode,
								callStack.Method, callStack.Instruction);
						}
					}
				}
			}
		}
		
		internal IServiceProvider ServiceProvider
		{
			get;
			set;
		}
	}
}
