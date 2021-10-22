using System.Collections.Generic;
using Synapse.Api;

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

            Player.OpenReportWindow(PluginClass.PluginTranslation.ActiveTranslation.Spawn.Replace("\\n","\n"));
        }

        public override void DeSpawn() => Map.Get.AnnounceScpDeath("0 5 6");

        public void SwapRole(RoleType role)
        {
            Player.ChangeRoleAtPosition(role);
            Player.MaxHealth = PluginClass.Config.Scp056Health;
        }
    }
}
