using AppKit;
using Avalonia;

namespace AvaloniaEmbedPopupTest
{
	static class MainClass
	{
		static void Main (string [] args)
		{
			BuildAvaloniaApp();
			
			NSApplication.Init ();
			NSApplication.Main (args);
		}
		
		public static AppBuilder BuildAvaloniaApp()
		{
			return AppBuilder.Configure<App>()
				.UseSkia()
				.UseAvaloniaNative()
				.With(new MacOSPlatformOptions()
				{
					DisableNativeMenus = true
				})
				.SetupWithoutStarting();
		}

	}
}
