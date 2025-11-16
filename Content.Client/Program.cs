using Robust.Client;
using Robust.Shared.Utility;

namespace Content.Client;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        ContentStart.Start(args);
            
        /*
        // DEVNOTE: If you want to use RobustToolbox as a library, use the method below instead.
        // Keep in mind, this will make your game ineligible from appearing on hubs/unmodified launchers, specially if you
        // disable sandboxing.
        ContentStart.StartLibrary(args, new GameControllerOptions()
        {
            // DEVNOTE: Your options here.
            Sandboxing = false,
            SplashLogo = new ResPath("/path/to/splash/logo.png"),
            // Check "RobustToolbox/Resources/Textures/Logo/icon" for an example window icon set.
            WindowIconSet = new ResPath("/path/to/folder/with/window/icon/set"),
            DefaultWindowTitle = "Robust Template"
        });*/
    }
}