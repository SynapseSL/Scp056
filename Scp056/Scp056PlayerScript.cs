using System.Collections.Generic;
using Neuron.Core.Meta;
using Synapse3.SynapseModule.Enums;
using Synapse3.SynapseModule.Map;
using Synapse3.SynapseModule.Role;

namespace Scp056;

[Automatic]
[Role(
    Name = "Scp056",
    Id = 56,
    TeamId = (int)Team.SCP
)]
public class Scp056PlayerScript : SynapseRole
{
    private readonly Scp056Plugin _plugin;
    private readonly CassieService _cassie;

    public Scp056PlayerScript(Scp056Plugin plugin, CassieService cassie)
    {
        _plugin = plugin;
        _cassie = cassie;
    }
        
    public override List<uint> GetEnemiesID() => new() { (int)Team.CDP, (int)Team.MTF, (int)Team.RSC };

    public override List<uint> GetFriendsID() => _plugin.Config.Ff ? new List<uint>() : new List<uint> { (uint)Team.SCP };

    public override void SpawnPlayer(bool spawnLite)
    {
        if(spawnLite) return;
        
        Player.ChangeRoleLite(RoleType.FacilityGuard);
        Player.Position = _plugin.Config.Scp056SpawnPoint.GetMapPosition();
        var rot = _plugin.Config.Scp056SpawnPoint.GetMapRotation();
        Player.PlayerRotation = new PlayerMovementSync.PlayerRotation(rot.x, rot.y);
        Player.Health = _plugin.Config.Scp056Health;
        Player.MaxHealth = _plugin.Config.Scp056Health;
        _plugin.Config.Inventory.Apply(Player);
        Player.SendWindowMessage(_plugin.Translation.Get(Player).Spawn.Replace("\\n", "\n"));
    }

    public override void DeSpawn(DespawnReason reason)
    {
        if (reason is DespawnReason.Death or DespawnReason.Leave)
            _cassie.AnnounceScpDeath("056", CassieSettings.DisplayText, CassieSettings.Glitched, CassieSettings.Noise);
    }

    public void SwapRole(RoleType role)
    {
        Player.ChangeRoleLite(role);
        Player.MaxHealth = _plugin.Config.Scp056Health;
    }
}