namespace Content.Server;

internal static class ServerContentIoC
{
    public static void Register()
    {
        // DEVNOTE: IoCManager registrations for the server go here and only here.
        IoCManager.Register<LocalHostConGroup>();
    }
}