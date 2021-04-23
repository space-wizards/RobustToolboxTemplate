using System.Globalization;
using Robust.Shared.ContentPack;
using Robust.Shared.IoC;
using Robust.Shared.Localization;

// DEVNOTE: Games that want to be on the hub are FORCED use the "Content." prefix for assemblies they want to load.
namespace Content.Shared
{
    public class EntryPoint : GameShared
    {
        // IoC services shared between the client and the server go here...
        
        // See line 23. Controls the default game culture and language.
        // Robust calls this culture, but you might find it more fitting to call it the game
        // language. Robust doesn't support changing this mid-game. Load your config file early
        // if you want that.
        private const string Culture = "en-US";

        public override void PreInit()
        {
            IoCManager.InjectDependencies(this);

            // Default to en-US.
            // DEVNOTE: If you want your game to be multiregional at runtime, you'll need to 
            // do something more complicated here.
            IoCManager.Resolve<ILocalizationManager>().LoadCulture(new CultureInfo(Culture));
            // TODO: Document what else you might want to put here
        }

        public override void Init()
        {
            // TODO: Document what you put here
        }

        public override void PostInit()
        {
            base.PostInit();
            // DEVNOTE: You might want to put special init handlers for, say, tiles here.
            // TODO: Document what else you might want to put here
        }
    }
}