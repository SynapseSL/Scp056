using Synapse.Translation;

namespace Scp056
{
    public class PluginTranslation : IPluginTranslation
    {
        public string Spawn { get; set; } = "<color=blue><b>You are now</b></color> <color=red><b>SCP</b></color> <color=blue><b>056</b></color>\\nYour goal is it to kill all Humans\\nYour special abillity is that you can use the .056 command in your Console to swap your class\\nPress esc to close";

        public string Targets { get; set; } = "There still exist %targets% more Targets to kill for you";

        public string Killed056 { get; set; } = "<color=blue><b>You have killed</b></color> <color=red><b>SCP</b></color> <color=black><b>056</b></color>";

        public string KilledBy056 { get; set; } = "<color=blue><b>You are killed by</b></color> <color=red><b>SCP</b></color> <color=black><b>056</b></color>";
    }
}
