using JetBrains.Annotations;
using Robust.Server.ServerStatus;
using Robust.Shared.ContentPack;
using Robust.Shared.Timing;

// DEVNOTE: Games that want to be on the hub can change their namespace prefix in the "manifest.yml" file.
namespace Content.Server;

[UsedImplicitly]
public sealed class EntryPoint : GameServer
{
    public override void Init()
    {
        base.Init();
        
        var factory = Dependencies.Resolve<IComponentFactory>();

        factory.DoAutoRegistrations();

        foreach (var ignoreName in IgnoredComponents.List)
        {
            factory.RegisterIgnore(ignoreName);
        }

        ServerContentIoC.Register(Dependencies);

        IoCManager.BuildGraph();
            
        factory.GenerateNetIds();

        // DEVNOTE: This is generally where you'll be setting up the IoCManager further.
    }

    public override void PostInit()
    {
        base.PostInit();
        // DEVNOTE: Can also initialize IoC stuff more here.
    }

    public override void Update(ModUpdateLevel level, FrameEventArgs frameEventArgs)
    {
        base.Update(level, frameEventArgs);
        // DEVNOTE: Game update loop goes here. Usually you'll want some independent GameTicker.
    }
}