using Robust.Shared.ContentPack;
using Robust.Shared.Interfaces.Configuration;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.Interfaces.Map;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;

namespace Content.Client
{
    public class EntryPoint: GameClient
    {
        public override void Init()
        {
            var factory = IoCManager.Resolve<IComponentFactory>();
            var prototypes = IoCManager.Resolve<IPrototypeManager>();

            factory.DoAutoRegistrations();

            foreach (var ignoreName in IgnoredComponents.List)
            {
                factory.RegisterIgnore(ignoreName);
            }

            foreach (var ignoreName in IgnoredPrototypes.List)
            {
                prototypes.RegisterIgnore(ignoreName);
            }

            ClientContentIoC.Register();

            IoCManager.BuildGraph();

            // DEVNOTE: This is generally where you'll be setting up the IoCManager further.

            IoCManager.InjectDependencies(this);
        }

        public override void PostInit()
        {
            base.PostInit();

            // DEVNOTE: Further setup, this is the spot you should start trying to connect to the server from.
        }

        public override void Update(ModUpdateLevel level, FrameEventArgs frameEventArgs)
        {
            base.Update(level, frameEventArgs);
            // DEVNOTE: Game update loop goes here. Usually you'll want some independent GameTicker.
        }
    }

    
}