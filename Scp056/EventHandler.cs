using System.Linq;
using Synapse3.SynapseModule.Events;
using Synapse3.SynapseModule.Player;
using UnityEngine;

namespace Scp056;

public class EventHandler
{
    private readonly Scp056Plugin _plugin;
    private readonly PlayerService _player;

    public EventHandler(PlayerEvents playerEvents, RoundEvents roundEvents, PlayerService player,
        Scp056Plugin plugin)
    {
        _player = player;
        _plugin = plugin;

        playerEvents.KeyPress.Subscribe(KeyPress);
        playerEvents.Death.Subscribe(Death);
        roundEvents.FirstSpawn.Subscribe(FirstSpawn);
    }

    private void FirstSpawn(FirstSpawnEvent ev)
    {
        if (ev.PlayerAndRoles.Count < _plugin.Config.RequiredPlayers) return;
        if (UnityEngine.Random.Range(1f, 100f) > _plugin.Config.SpawnChance) return;

        var possiblePlayers = _plugin.Config.ReplaceScp
            ? ev.PlayerAndRoles.Where(x => IsScpID(x.Value))
            : ev.PlayerAndRoles.Where(x => !IsScpID(x.Value));

        if (possiblePlayers.Count() == 0)
            return;

        System.Collections.Generic.KeyValuePair<SynapsePlayer, uint> pair;


        if (_plugin.Config.ReplaceScp && _plugin.Config.Replace079 && possiblePlayers.Count() == 2 &&
            possiblePlayers.Any(x => x.Value == (int)RoleType.Scp079))
            pair = possiblePlayers.FirstOrDefault(x => x.Value == (uint)RoleType.Scp079);
        else
            pair = possiblePlayers.ElementAt(UnityEngine.Random.Range(0, possiblePlayers.Count()));

        ev.PlayerAndRoles[pair.Key] = 56;
    }

    private bool IsScpID(uint id) => id is (int)RoleType.Scp173 or (int)RoleType.Scp049 or (int)RoleType.Scp0492
        or (int)RoleType.Scp079 or (int)RoleType.Scp096 or (int)RoleType.Scp106 or (int)RoleType.Scp93953
        or (int)RoleType.Scp93989;

    private void Death(DeathEvent ev)
    {
        if (ev.Attacker == null || ev.Attacker == ev.Player) return;

        if (ev.Player.RoleID == 56)
            ev.Attacker.SendBroadcast(_plugin.Translation.Get(ev.Attacker).Killed056, 7);
        else if (ev.Attacker.RoleID == 56)
            ev.Player.SendWindowMessage(_plugin.Translation.Get(ev.Player).KilledBy056);
    }

    private void KeyPress(KeyPressEvent ev)
    {
        if (ev.Player.RoleID != 56) return;

        RoleType role;

        switch (ev.KeyCode)
        {
            case KeyCode.Alpha5:
                role = RoleType.ClassD;
                break;

            case KeyCode.Alpha6:
                role = RoleType.Scientist;
                break;

            case KeyCode.Alpha7:
                role = RoleType.FacilityGuard;
                break;

            case KeyCode.Alpha8:
                role = RoleType.NtfSergeant;
                break;

            case KeyCode.Alpha9:
                role = RoleType.ChaosRifleman;
                break;

            case KeyCode.Alpha0:
                var targets = _player
                    .GetPlayers(x => x.TeamID is (uint)Team.MTF or (uint)Team.CDP or (uint)Team.RSC).Count;

                ev.Player.SendBroadcast(
                    _plugin.Translation.Get(ev.Player).Targets.Replace("%targets%", targets.ToString()), 7);
                return;

            default: return;
        }

        (ev.Player.CustomRole as Scp056PlayerScript)?.SwapRole(role);
    }
}