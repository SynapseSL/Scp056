using Synapse;
using Synapse.Command;
using System.Linq;

namespace Scp056
{
    [CommandInformations(
        Name = "scp056",
        Aliases = new[] { "056" },
        Description = "An Command for Scp056 to swap his Roles",
        Permission = "none",
        Platforms = new[] { Platform.ClientConsole },
        Usage = ".056 class d/s/c/m/g or .056 targets"
        )]
    public class Scp056Command : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (context.Arguments.Count < 1)
                context.Arguments = new System.ArraySegment<string>(new[] { "" });

            if(context.Player.RoleID != 56)
            {
                result.Message = "You are Not Scp056";
                result.State = CommandResultState.Error;
                return result;
            }

            switch (context.Arguments.First().ToLower())
            {
                case "class":
                    if(context.Arguments.Count < 2)
                        context.Arguments = new System.ArraySegment<string>(new[] { "class","" });

                    RoleType role;

                    switch (context.Arguments.ElementAt(1).ToLower())
                    {
                        case "d": role = RoleType.ClassD; break;
                        case "s": role = RoleType.Scientist; break;
                        case "c": role = RoleType.ChaosInsurgency; break;
                        case "m": role = RoleType.NtfLieutenant; break;
                        case "g": role = RoleType.FacilityGuard; break;

                        default:
                            result.Message = "You have to enter a valid letter" +
                                "\nD => D-Personnel" +
                                "\nS => Scientist" +
                                "\nC => Chaos" +
                                "\nM => Mtf Lieutnant" +
                                "\nG => Guard";
                            result.State = CommandResultState.Error;
                            return result;
                    }

                    context.Player.ChangeRoleAtPosition(role);
                    context.Player.Ammo5 = 999;
                    context.Player.Ammo7 = 999;
                    context.Player.Ammo9 = 999;
                    context.Player.MaxHealth = PluginClass.Config.Scp056Health;
                    result.Message = "You succesfully swaped your Role";
                    result.State = CommandResultState.Ok;
                    return result;

                case "targets":
                    var targets = Server.Get.GetPlayers(x => x.RealTeam == Team.MTF || x.RealTeam == Team.CDP || x.RealTeam == Team.RSC).Count;
                    result.Message = PluginClass.GetTranslation("targets").Replace("%targets%", targets.ToString());
                    result.State = CommandResultState.Ok;
                    return result;

                default:
                    result.State = CommandResultState.Error;
                    result.Message = "Please type one of these 056 commands in:" +
                        "\n.056 class D => Changes your Role to a D-Personnel" +
                        "\n.056 class S => Changes your Role to a Scientist" +
                        "\n.056 class C => Changes your Role to a Chaos" +
                        "\n.056 class M => Changes your Role to a Mtf Lieutnant" +
                        "\n.056 class G => Changes your Role to a Guard" +
                        "\n.056 targets displays you how many targets are left";
                    return result;
            }
        }
    }
}
