using Robust.Shared;
using Robust.Shared.Configuration;

namespace Content.Shared
{
    // DEVNOTE: This is the same as SS14's CCVars. Except it's not named CCVars as that name is 
    // hot garbage.
    [CVarDefs]
    public sealed class GameConfigVars: CVars
    {
        // Declare persistent game config variables here.
        // ```
        // public static readonly CVarDef<SerializableType>
        //     VariableName = CVarDef.Create("namespace.varname", default_value, CVar.TYPE | CVar.OTHERTYPE)
        // ``` 
        // This is a good spot to store your database config, among other things.

        public static readonly CVarDef<bool>
            DummyCVarForTemplate = CVarDef.Create("dummy.whydoineedthis", true, CVar.ARCHIVE);
    }
}