using System;
using System.Linq;
using Synapse;
using Synapse.Api;
using Synapse.Api.Enum;
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
            Server.Get.Events.Player.PlayerCuffTargetEvent += OnCuff;
            Server.Get.Events.Player.PlayerSetClassEvent += OnSetClass;
            Server.Get.Events.Player.PlayerDropAmmoEvent += DropAmmo;
            Server.Get.Events.Player.PlayerReloadEvent += ReloadWeapon;
        }

        private void ReloadWeapon(Synapse.Api.Events.SynapseEventArguments.PlayerReloadEventArgs ev)
        {
            if (ev.Player.RoleID == 56)
                foreach (var ammo in (AmmoType[])Enum.GetValues(typeof(AmmoType)))
                {
                    ev.Player.AmmoBox[ammo] = InventorySystem.Configs.InventoryLimits.GetAmmoLimit(null, (ItemType)ammo);
                    MEC.Timing.CallDelayed(5f, () => ev.Player.AmmoBox[ammo] = 0);
                }
        }

        private void DropAmmo(Synapse.Api.Events.SynapseEventArguments.PlayerDropAmmoEventArgs ev)
        {
            if (ev.Player.RoleID == 56) ev.Allow = false;
        }

        private void OnSetClass(Synapse.Api.Events.SynapseEventArguments.PlayerSetClassEventArgs ev)
        {
            if(ev.Player.RoleID == 56)
            {
                ev.Position = PluginClass.Config.Scp056SpawnPoint.Parse().Position;
                ev.Items = PluginClass.Config.Items.Select(x => x.Parse()).ToList();
            }
        }

        private void OnCuff(Synapse.Api.Events.SynapseEventArguments.PlayerCuffTargetEventArgs ev)
        {
            if(ev.Target.RoleID == 56)
            {
                foreach (var enumType in (AmmoType[])typeof(AmmoType).GetEnumValues())
                    ev.Target.AmmoBox[enumType] = 0;
            }
        }

        private void OnSpawn(Synapse.Api.Events.SynapseEventArguments.SpawnPlayersEventArgs ev)
        {
            if (ev.SpawnPlayers.Count >= PluginClass.Config.RequiredPlayers)
            {
                if (UnityEngine.Random.Range(1f, 100f) <= PluginClass.Config.SpawnChanche)
                {
                    var playerspair = PluginClass.Config.ReplaceScp ? ev.SpawnPlayers.Where(x => IsScpID(x.Value)) : ev.SpawnPlayers.Where(x => !IsScpID(x.Value));

                    if (playerspair.Count() == 0)
                        return;

                    System.Collections.Generic.KeyValuePair<Player, int> pair;


                    if (PluginClass.Config.ReplaceScp && PluginClass.Config.Replace079 && playerspair.Count() == 2 && playerspair.Any(x => x.Value == (int)RoleType.Scp079))
                        pair = playerspair.FirstOrDefault(x => x.Value == (int)RoleType.Scp079);
                    else
                        pair = playerspair.ElementAt(UnityEngine.Random.Range(0, playerspair.Count()));

                    ev.SpawnPlayers[pair.Key] = 56;
                }
            }
        }

        private bool IsScpID(int id) => id == (int)RoleType.Scp173 || id == (int)RoleType.Scp049 || id == (int)RoleType.Scp0492 || id == (int)RoleType.Scp079 || id == (int)RoleType.Scp096 || id == (int)RoleType.Scp106 || id == (int)RoleType.Scp93953 || id == (int)RoleType.Scp93989;

        private void OnDeath(Synapse.Api.Events.SynapseEventArguments.PlayerDeathEventArgs ev)
        {
            if (ev.Killer == null || ev.Killer == ev.Victim) return;

            if (ev.Victim.RoleID == 56)
                ev.Killer.SendBroadcast(7, PluginClass.PluginTranslation.ActiveTranslation.Killed056);
            else if (ev.Killer.RoleID == 56)
                ev.Victim.OpenReportWindow(PluginClass.PluginTranslation.ActiveTranslation.KilledBy056);
        }

        private void OnKeyPress(Synapse.Api.Events.SynapseEventArguments.PlayerKeyPressEventArgs ev)
        {
            if (ev.Player.RoleID != 56) return;

            RoleType role;

            switch (ev.KeyCode)
            {
                case KeyCode.Alpha5: role = RoleType.ClassD; break;

                case KeyCode.Alpha6: role = RoleType.Scientist; break;

                case KeyCode.Alpha7: role = RoleType.FacilityGuard; break;

                case KeyCode.Alpha8: role = RoleType.NtfSergeant; break;

                case KeyCode.Alpha9: role = RoleType.ChaosRifleman; break;

                case KeyCode.Alpha0:
                    var targets = Server.Get.GetPlayers(x => x.RealTeam == Team.MTF || x.RealTeam == Team.CDP || x.RealTeam == Team.RSC).Count;
                    ev.Player.SendBroadcast(7, PluginClass.PluginTranslation.ActiveTranslation.Targets.Replace("%targets%",targets.ToString()));
                    return;

                default: return;
            }

            (ev.Player.CustomRole as Scp056PlayerScript).SwapRole(role);
        }
    }
}
