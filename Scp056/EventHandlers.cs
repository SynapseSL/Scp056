using MEC;
using Synapse;
using Synapse.Api;
using System.Linq;
using UnityEngine;

namespace Scp056
{
    public class EventHandlers
    {
        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerKeyPressEvent += OnKeyPress;
            Server.Get.Events.Player.PlayerDeathEvent += OnDeath;
            Server.Get.Events.Round.SpawnPlayersEvent += OnSpawn;
        }

        private void OnSpawn(Synapse.Api.Events.SynapseEventArguments.SpawnPlayersEventArgs ev)
        {
            if (Server.Get.GetPlayers(x => !x.OverWatch).Count >= PluginClass.Config.RequiredPlayers)
            {
                if (UnityEngine.Random.Range(1f, 100f) < PluginClass.Config.SpawnChanche)
                {
                    var playerspair = PluginClass.Config.ReplaceScp ? ev.SpawnPlayers.Where(x => IsScpID(x.Value)) : ev.SpawnPlayers.Where(x => !IsScpID(x.Value));

                    if (playerspair.Count() == 0)
                        return;

                    var pair = playerspair.ElementAt(UnityEngine.Random.Range(0, playerspair.Count()));

                    ev.SpawnPlayers[pair.Key] = 56;
                }
            }
        }

        private bool IsScpID(int id) => id == (int)RoleType.Scp173 || id == (int)RoleType.Scp049 || id == (int)RoleType.Scp0492 || id == (int)RoleType.Scp079 || id == (int)RoleType.Scp096 || id == (int)RoleType.Scp106 || id == (int)RoleType.Scp93953 || id == (int)RoleType.Scp93989;

        private void OnDeath(Synapse.Api.Events.SynapseEventArguments.PlayerDeathEventArgs ev)
        {
            if(ev.Victim.RoleID == 56)
                Map.Get.AnnounceScpDeath("0 5 6");

            if (ev.Killer == ev.Victim) return;

            if(ev.Victim.RoleID == 56)
            {
                ev.Killer.SendBroadcast(7, PluginClass.GetTranslation("killed035"));
            }
            else if(ev.Killer.RoleID == 56)
                ev.Victim.SendBroadcast(7, PluginClass.GetTranslation("killedby035"));
        }

        private void OnKeyPress(Synapse.Api.Events.SynapseEventArguments.PlayerKeyPressEventArgs ev)
        {
#if DEBUG
            if(ev.KeyCode == KeyCode.Alpha7) ev.Player.CustomRole = new Scp056PlayerScript();
#endif
            if (ev.Player.RoleID != 56) return;

            RoleType role;

            switch (ev.KeyCode)
            {
                case KeyCode.Alpha1: role = RoleType.ClassD; break;

                case KeyCode.Alpha2: role = RoleType.Scientist; break;

                case KeyCode.Alpha3: role = RoleType.FacilityGuard; break;

                case KeyCode.Alpha4: role = RoleType.NtfLieutenant; break;

                case KeyCode.Alpha5: role = RoleType.ChaosInsurgency; break;

                case KeyCode.Alpha6:
                    var targets = Server.Get.GetPlayers(x => x.RealTeam == Team.MTF || x.RealTeam == Team.CDP || x.RealTeam == Team.RSC).Count;
                    ev.Player.SendBroadcast(7, PluginClass.GetTranslation("targets").Replace("%targets%",targets.ToString()));
                    return;

                default: return;
            }

            ev.Player.ChangeRoleAtPosition(role);
            ev.Player.Ammo5 = 999;
            ev.Player.Ammo7 = 999;
            ev.Player.Ammo9 = 999;
        }
    }
}
