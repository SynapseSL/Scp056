﻿using Synapse;
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
            Server.Get.Events.Player.PlayerCuffTargetEvent += OnCuff;
            Server.Get.Events.Player.PlayerSetClassEvent += OnSetClass;
            Server.Get.Events.Player.PlayerDropAmmoEvent += DropAmmo;
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
                ev.Target.Ammo5 = 0;
                ev.Target.Ammo7 = 0;
                ev.Target.Ammo9 = 0;
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
                case KeyCode.Alpha1: role = RoleType.ClassD; break;

                case KeyCode.Alpha2: role = RoleType.Scientist; break;

                case KeyCode.Alpha3: role = RoleType.FacilityGuard; break;

                case KeyCode.Alpha4: role = RoleType.NtfLieutenant; break;

                case KeyCode.Alpha5: role = RoleType.ChaosInsurgency; break;

                case KeyCode.Alpha6:
                    var targets = Server.Get.GetPlayers(x => x.RealTeam == Team.MTF || x.RealTeam == Team.CDP || x.RealTeam == Team.RSC).Count;
                    ev.Player.SendBroadcast(7, PluginClass.PluginTranslation.ActiveTranslation.Targets.Replace("%targets%",targets.ToString()));
                    return;

                default: return;
            }

            (ev.Player.CustomRole as Scp056PlayerScript).SwapRole(role);
        }
    }
}
