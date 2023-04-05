using System;
using Neuron.Core.Meta;
using Neuron.Modules.Configs.Localization;

namespace Scp056;

[Automatic]
[Serializable]
public class Scp056Translation : Translations<Scp056Translation>
{
    public string Spawn { get; set; } = "<b>You are now</b> <color=red><b>SCP</b></color> <color=blue><b>056</b></color>\\nYour goal is it to kill all Humans\\nYour special ability is that you can use the .056 command in your Console to swap your class\\nPress n to close";

    public string Targets { get; set; } = "There still exist %targets% more Targets to kill for you";

    public string Killed056 { get; set; } = "<b>You have killed</b> <color=red><b>SCP</b></color> <color=black><b>056</b></color>";

    public string KilledBy056 { get; set; } = "<color=blue><b>You were killed by</b></color> <color=red><b>SCP</b></color> <color=black><b>056</b></color>";

    public string ChangedRole { get; set; } = "You have successfully changed your Role to %role%";

    public string Commands { get; set; } = "You can use these commands:";

    public string NotScp056 { get; set; } = "You are not SCP-056";

    public string ActivatedScpChat { get; set; } = "You are now Speaking to all SCP's";

    public string DeactivatedScpChat { get; set; } = "You are now Speaking to Players in your proximity";
}