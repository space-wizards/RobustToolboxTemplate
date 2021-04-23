using Robust.Client;

namespace Content.Client
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ContentStart.Start(args);
            
            /*
             // DEVNOTE: If you want to use RobustToolbox as a library, use the method below instead.
             // Keep in mind, this will make your game ineligible from appearing on the SS14 hub, specially if you
             // disable sandboxing.
            ContentStart.StartLibrary(args, new GameControllerOptions()
            {
                // DEVNOTE: Your options here.
                Sandboxing = false,
            });
            */
        }
    }
}