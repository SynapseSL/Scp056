using Synapse;
using Synapse.Api.Plugin;
using System.Collections.Generic;
using Synapse.Translation;

namespace Scp056
{
    [PluginInformation(
        Author = "Dimenzio",
        Description = "A Plugin which adds the new Role Scp056 to the game",
        LoadPriority = 1,
        Name = "Scp056",
        SynapseMajor = 2,
        SynapseMinor = 5,
        SynapsePatch = 0,
        Version = "v.1.1.3"
        )]
    public class PluginClass : AbstractPlugin
    {
        private static PluginClass pclass;

        [Synapse.Api.Plugin.Config(section = "Scp056")]
        public static Config Config;

        [SynapseTranslation]
        public static SynapseTranslation<PluginTranslation> PluginTranslation;

        public override void Load()
        {
            Server.Get.RoleManager.RegisterCustomRole<Scp056PlayerScript>();
            pclass = this;
            PluginTranslation.AddTranslation(new Scp056.PluginTranslation());
            PluginTranslation.AddTranslation(new Scp056.PluginTranslation
            {
                Spawn = "<color=blue><b>Du bist jetzt</b></color> <color=red><b>SCP</b></color> <color=blue><b>056</b></color>\\nDein Ziel ist es alle Menschen zu töten\\nDeine besondere Fähigkeit ist es dass du mit dem .056 Command in der ö-Konsole deine Aussehen ändern kannst\\nDrücke Esc um das Fenster zu schließen",
                Targets = "Es existieren noch %targets% Lebewesen welche du töten musst",
                Killed056 = "<color=blue><b>Du hast</b></color> <color=red><b>SCP</b></color> <color=black><b>056 <color=blue>getötet</color></b></color>",
                KilledBy056 = "<color=blue><b>Du wurdest umgebracht von</b></color> <color=red><b>SCP</b></color> <color=black><b>056</b></color>",
            }, "GERMAN");

            new EventHandlers();
        }
    }
}
