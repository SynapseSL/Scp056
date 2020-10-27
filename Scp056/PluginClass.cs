using Synapse;
using Synapse.Api.Plugin;
using System.Collections.Generic;

namespace Scp056
{
    [PluginInformation(
        Author = "Dimenzio",
        Description = "An Plugin which adds the new Role Scp056 to the game",
        LoadPriority = int.MinValue,
        Name = "Scp056",
        SynapseMajor = 2,
        SynapseMinor = 0,
        SynapsePatch = 0,
        Version = "v.1.0.0"
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
                {"spawn","<color=blue><b>You are now</b></color> <color=red><b>Scp</b></color> <color=blue><b>056</b></color>" },
                {"targets","There still exist %targets% more Targets to kill for you" },
                {"killed035","<color=blue><b>You have killed</b></color> <color=red><b>Scp</b></color> <color=black><b>056</b></color>" },
                {"killedby035","<color=blue><b>You are killed by</b></color> <color=red><b>Scp</b></color> <color=black><b>056</b></color>" }
            };
            Translation.CreateTranslations(trans);

            new EventHandlers();
        }

        internal static string GetTranslation(string key) => pclass.Translation.GetTranslation(key);
    }
}
