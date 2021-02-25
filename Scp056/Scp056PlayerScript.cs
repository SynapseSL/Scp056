using Synapse.Api;
using System.Collections.Generic;

namespace Scp056
{
    public class Scp056PlayerScript : Synapse.Api.Roles.Role
    {
        public override List<int> GetEnemiesID() => new List<int> { (int)Team.CDP, (int)Team.MTF, (int)Team.RSC };

        public override List<int> GetFriendsID() => PluginClass.Config.ff ? new List<int>() : new List<int> { (int)Team.SCP };

        public override int GetRoleID() => 56;

        public override string GetRoleName() => "Scp056";

        public override int GetTeamID() => (int)Team.SCP;

        public override void Spawn()
        {
            Player.RoleType = RoleType.FacilityGuard;

            Player.Health = PluginClass.Config.Scp056Health;
            Player.MaxHealth = PluginClass.Config.Scp056Health;

            Player.Ammo5 = 999;
            Player.Ammo7 = 999;
            Player.Ammo9 = 999;

            Player.OpenReportWindow(PluginClass.PluginTranslation.ActiveTranslation.Spawn.Replace("\\n","\n"));
        }

        public override void DeSpawn()
        {
            if (RoleType.Scp079.GetPlayers().Count > 0)
                NineTailedFoxAnnouncer.CheckForZombies(Player.gameObject);

            Map.Get.AnnounceScpDeath("0 5 6");

            Player.Ammo5 = 0;
            Player.Ammo7 = 0;
            Player.Ammo9 = 0;
        }

        public void SwapRole(RoleType role)
        {
            Player.ChangeRoleAtPosition(role);
            Player.Ammo5 = 999;
            Player.Ammo7 = 999;
            Player.Ammo9 = 999;
            Player.MaxHealth = PluginClass.Config.Scp056Health;
        }
    }
}
