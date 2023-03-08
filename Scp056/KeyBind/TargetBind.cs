using Neuron.Core.Meta;
using Ninject;
using PlayerRoles;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.KeyBind;
using Synapse3.SynapseModule.Player;
using UnityEngine;

namespace Scp056.KeyBind;

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad0,
    CommandDescription = "Displays the number of targets for SCP-056",
    CommandName = "Scp056Targets"
    )]
public class TargetBind : Synapse3.SynapseModule.KeyBind.KeyBind
{
    [Inject]
    public PlayerService PlayerService { get; set; }
    
    [Inject]
    public Scp056Plugin Plugin { get; set; }
    
    public override void Execute(SynapsePlayer player)
    {
        if (player.RoleID != 56) return;

        var targets = PlayerService.GetPlayers(x =>
            x.TeamID is (uint)Team.FoundationForces or (uint)Team.ClassD or (uint)Team.Scientists).Count;

        player.SendBroadcast(
            Plugin.Translation.Get(player).Targets.Replace("%targets%", targets.ToString()), 7);
    }
}