namespace Content.Server;

internal static class ServerContentIoC
{
    public static void Register(IDependencyCollection dependencies)
    {
        // DEVNOTE: IoCManager registrations for the server go here and only here.
        dependencies.Register<LocalHostConGroup>();
    }
}