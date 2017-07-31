using Reflector;
using Reflector.CodeModel;
using Spackle;
using Spackle.Extensions;
using System;
using System.Windows.Forms;

namespace ExceptionFinder
{
	public sealed class ExceptionFinderPackage : IPackage
	{
		private const Keys MenuKeys = Keys.Control | Keys.Shift | Keys.X;
		private const string ToolsCommandBar = "Tools";
		private const string ToolsTitle = "Find E&xceptions...";
		private const string WindowID = "ExceptionFinderWindow";
		private const string WindowTitle = "Find Exceptions";

		private IAssemblyBrowser assemblyBrowser;
		private ICommandBarButton commandBarButton;
		private ICommandBarSeparator commandBarSeparator;
		private IServiceProvider serviceProvider;
		private ExceptionFinderView view;
		private IWindow window;
		private IWindowManager windowManager;

		public ExceptionFinderPackage()
			: base()
		{
		}

		public void Load(IServiceProvider serviceProvider)
		{	
			serviceProvider.CheckParameterForNull("serviceProvider");

			this.serviceProvider = serviceProvider;

			this.assemblyBrowser = (IAssemblyBrowser)this.serviceProvider.GetService(typeof(IAssemblyBrowser));
			this.assemblyBrowser.ActiveItemChanged += this.OnAssemblyBrowserActiveItemChanged;

			this.view = new ExceptionFinderView();
			this.view.ServiceProvider = this.serviceProvider;

			this.windowManager = (IWindowManager)this.serviceProvider.GetService(typeof(IWindowManager));
			this.windowManager.Windows.Add(ExceptionFinderPackage.WindowID,
				this.view, ExceptionFinderPackage.WindowTitle);

			this.window = this.windowManager.Windows[ExceptionFinderPackage.WindowID];
			this.window.Content.Dock = DockStyle.Fill;

			var commandBarManager =
				 (ICommandBarManager)this.serviceProvider.GetService(typeof(ICommandBarManager));
			var commandToolItems =
				commandBarManager.CommandBars[ExceptionFinderPackage.ToolsCommandBar].Items;
			this.commandBarSeparator = commandToolItems.AddSeparator();
			this.commandBarButton = commandToolItems.AddButton(
				 ExceptionFinderPackage.ToolsTitle, new EventHandler(this.OnExceptionFinderButtonClick),
				 ExceptionFinderPackage.MenuKeys);

			this.UpdateView();
		}

		private void OnAssemblyBrowserActiveItemChanged(object sender, EventArgs e)
		{
			this.UpdateView();
		}
		
		private void OnExceptionFinderButtonClick(object sender, EventArgs e)
		{
			this.ShowAnalysis();
		}

		private void ShowAnalysis()
		{
			using(var switcher = new ScopeSwitcher<Cursor, Cursor>(Cursors.WaitCursor))
			{
				this.view.ShowLeakedExceptions(
					this.assemblyBrowser.ActiveItem as IMethodDeclaration);
				this.window.Visible = true;			
			}
		}

		public void Unload()
		{
			this.view.Dispose();
			
			var commandBarManager =
				(ICommandBarManager)this.serviceProvider.GetService(typeof(ICommandBarManager));
			var commandToolItems = commandBarManager.CommandBars[ExceptionFinderPackage.ToolsCommandBar].Items;

			commandToolItems.Remove(this.commandBarButton);
			commandToolItems.Remove(this.commandBarSeparator);
		}

		private void UpdateView()
		{
			this.commandBarButton.Enabled =
				(this.assemblyBrowser.ActiveItem as IMethodDeclaration) != null;
		}
	}
}