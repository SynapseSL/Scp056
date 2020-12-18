using MEC;
using Synapse.Api;

namespace Scp056
{
    public class Scp056PlayerScript : Synapse.Api.Roles.Role
    {
        public override System.Collections.Generic.List<Team> GetEnemys() => new System.Collections.Generic.List<Team> { Team.CDP, Team.MTF, Team.RSC };

        public override System.Collections.Generic.List<Team> GetFriends()
        {
            if (PluginClass.Config.ff)
                return new System.Collections.Generic.List<Team> { };
            return new System.Collections.Generic.List<Team> { Team.SCP };
        }

        public override int GetRoleID() => 56;

        public override string GetRoleName() => "Scp056";

        public override Team GetTeam() => Team.SCP;

        public override void Spawn()
        {
            Player.RoleType = RoleType.FacilityGuard;
            Timing.CallDelayed(0.5f, () => Player.Position = PluginClass.Config.Scp056SpawnPoint.Parse().Position);

            Player.Inventory.Clear();

            foreach (var item in PluginClass.Config.Items)
                Player.Inventory.AddItem(item.Parse());

            Player.Health = PluginClass.Config.Scp056Health;
            Player.MaxHealth = PluginClass.Config.Scp056Health;

            Player.Ammo5 = 999;
            Player.Ammo7 = 999;
            Player.Ammo9 = 999;

            Player.OpenReportWindow(PluginClass.GetTranslation("spawn"));
        }
    }
}
