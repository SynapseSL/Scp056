using System.Collections.Generic;
using Neuron.Core.Meta;
using PlayerRoles;
using Synapse3.SynapseModule.Enums;
using Synapse3.SynapseModule.Map;
using Synapse3.SynapseModule.Role;

namespace Scp056;

[Automatic]
[Role(
    Name = "Scp056",
    Id = 56,
    TeamId = (int)Team.SCPs
)]
public class Scp056PlayerScript : SynapseAbstractRole
{
    private readonly Scp056Plugin _plugin;
    private readonly CassieService _cassie;

    public Scp056PlayerScript(Scp056Plugin plugin, CassieService cassie)
    {
        _plugin = plugin;
        _cassie = cassie;
    }

    public bool ScpChat { get; set; } = false;
        
    public override List<uint> GetEnemiesID() => new() { (int)Team.ClassD, (int)Team.FoundationForces, (int)Team.Scientists };

    public override List<uint> GetFriendsID() => _plugin.Config.Ff ? new List<uint>() : new List<uint> { (uint)Team.SCPs };

    protected override IAbstractRoleConfig GetConfig() => _plugin.Config.Scp056Configuration;

    protected override void OnSpawn(IAbstractRoleConfig config)
    {
        Player.SendWindowMessage(_plugin.Translation.Get(Player).Spawn.Replace("\\n", "\n"));
        RemoveCustomDisplay();
    }

    protected override void OnDeSpawn(DeSpawnReason reason)
    {
        if (reason <= DeSpawnReason.Leave)
            _cassie.AnnounceScpDeath("056", CassieSettings.Glitched, CassieSettings.Noise);
    }

    public void SwapRole(RoleTypeId role)
    {
        if (!_plugin.Config.AllowedRoles.Contains(role)) return;

        Player.FakeRoleManager.VisibleRole = role;
        Player.SendHint(_plugin.Translation.ChangedRole.Replace("%role%", role.ToString()));
    }
}