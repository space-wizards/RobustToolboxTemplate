using Robust.Server;

namespace Content.Server
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ContentStart.Start(args);
            
            /*
             // DEVNOTE: If you want to use RobustToolbox as a library, use the method below instead.
            ContentStart.StartLibrary(args);
            */
        }
    }
}