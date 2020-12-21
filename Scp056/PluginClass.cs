using Synapse;
using Synapse.Api.Plugin;
using System.Collections.Generic;

namespace Scp056
{
    [PluginInformation(
        Author = "Dimenzio",
        Description = "An Plugin which adds the new Role Scp056 to the game",
        LoadPriority = 1,
        Name = "Scp056",
        SynapseMajor = SynapseController.SynapseMajor,
        SynapseMinor = SynapseController.SynapseMinor,
        SynapsePatch = SynapseController.SynapsePatch,
        Version = "v.1.1.1"
        )]
    public class PluginClass : AbstractPlugin
    {
        private static PluginClass pclass;

        [Synapse.Api.Plugin.Config(section = "Scp056")]
        public static Config Config;

        public override void Load()
        {
            Server.Get.RoleManager.RegisterCustomRole<Scp056PlayerScript>();
            pclass = this;
            var trans = new Dictionary<string, string>
            {
                {"spawn","<color=blue><b>You are now</b></color> <color=red><b>SCP</b></color> <color=blue><b>056</b></color>\nYour goal is it to kill all Humans\nYour special abillity is that you can use the .056 command in your Console to swap your class\nPress esc to close" },
                {"targets","There still exist %targets% more Targets to kill for you" },
                {"killed035","<color=blue><b>You have killed</b></color> <color=red><b>SCP</b></color> <color=black><b>056</b></color>" },
                {"killedby035","<color=blue><b>You are killed by</b></color> <color=red><b>SCP</b></color> <color=black><b>056</b></color>" }
            };
            Translation.CreateTranslations(trans);

            new EventHandlers();
        }

        internal static string GetTranslation(string key) => pclass.Translation.GetTranslation(key);
    }
}
