using Synapse;
using Synapse.Api.Plugin;
using Synapse.Translation;

namespace Scp056
{
    [PluginInformation(
        Author = "Dimenzio",
        Description = "A Plugin which adds the new Role Scp056 to the game",
        LoadPriority = 1,
        Name = "Scp056",
        SynapseMajor = 2,
        SynapseMinor = 7,
        SynapsePatch = 1,
        Version = "v.1.1.5"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "Scp056")]
        public static PluginConfig Config;

        [SynapseTranslation]
        public static SynapseTranslation<PluginTranslation> PluginTranslation;

        public override void Load()
        {
            Server.Get.RoleManager.RegisterCustomRole<Scp056PlayerScript>();
            PluginTranslation.AddTranslation(new Scp056.PluginTranslation());
            PluginTranslation.AddTranslation(new Scp056.PluginTranslation
            {
                Spawn = "<color=blue><b>Du bist jetzt</b></color> <color=red><b>SCP</b></color> <color=blue><b>056</b></color>\\nDein Ziel ist es alle Menschen zu töten\\nDeine besondere Fähigkeit ist es dass du mit dem .056 Command in der ö-Konsole deine Aussehen ändern kannst\\nDrücke Esc um das Fenster zu schließen",
                Targets = "Es existieren noch %targets% Lebewesen welche du töten musst",
                Killed056 = "<color=blue><b>Du hast</b></color> <color=red><b>SCP</b></color> <color=black><b>056 <color=blue>getötet</color></b></color>",
                KilledBy056 = "<color=blue><b>Du wurdest umgebracht von</b></color> <color=red><b>SCP</b></color> <color=black><b>056</b></color>",
            }, "GERMAN");
            //Feel free to ask me or create a PR in order to add more languages

            new EventHandlers();
        }
    }
}
