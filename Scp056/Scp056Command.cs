using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Player;

namespace Scp056;

[Automatic]
[SynapseCommand(
    CommandName = "Scp056",
    Aliases = new[] { "056" },
    Description = "A Command for SCP-056 to swap his Role",
    Platforms = new[] { CommandPlatform.PlayerConsole }
)]
public class Scp056Command : SynapseCommand
{
    private readonly PlayerService _player;
    private readonly Scp056Plugin _plugin;

    public Scp056Command(PlayerService player, Scp056Plugin plugin)
    {
        _player = player;
        _plugin = plugin;
    }

    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
            context.Arguments = new[] { "" };

        if (context.Player.RoleID != 56)
        {
            result.Response = "You are Not Scp056";
            result.StatusCode = CommandStatusCode.Forbidden;
            return;
        }

        switch (context.Arguments[0].ToLower())
        {
            case "class":
                if (context.Arguments.Length < 2)
                    context.Arguments = new[] { "class", "" };

                RoleType role;

                switch (context.Arguments[1].ToLower())
                {
                    case "d":
                        role = RoleType.ClassD;
                        break;
                    case "s":
                        role = RoleType.Scientist;
                        break;
                    case "c":
                        role = RoleType.ChaosRifleman;
                        break;
                    case "m":
                        role = RoleType.NtfSergeant;
                        break;
                    case "g":
                        role = RoleType.FacilityGuard;
                        break;

                    default:
                        result.Response = "You have to enter a valid letter" +
                                          "\nD => D-Personnel" +
                                          "\nS => Scientist" +
                                          "\nC => Chaos" +
                                          "\nM => Mtf Lieutnant" +
                                          "\nG => Guard";
                        result.StatusCode = CommandStatusCode.Ok;
                        return;
                }

                (context.Player.CustomRole as Scp056PlayerScript)?.SwapRole(role);
                result.Response = "You successfully swapped your Role";
                result.StatusCode = CommandStatusCode.Ok;
                return;

            case "targets":
                var targets = _player
                    .GetPlayers(x => x.TeamID is (uint)Team.MTF or (uint)Team.CDP or (uint)Team.RSC).Count;

                result.Response = _plugin.Translation.Get(context.Player).Targets
                    .Replace("%targets%", targets.ToString());

                result.StatusCode = CommandStatusCode.Ok;
                return;

            default:
                result.StatusCode = CommandStatusCode.Ok;
                result.Response = "Please type one of these 056 commands in:" +
                                  "\n.056 class D => Changes your Role to a D-Personnel" +
                                  "\n.056 class S => Changes your Role to a Scientist" +
                                  "\n.056 class C => Changes your Role to a Chaos" +
                                  "\n.056 class M => Changes your Role to a Mtf Lieutnant" +
                                  "\n.056 class G => Changes your Role to a Guard" +
                                  "\n.056 targets displays you how many targets are left";
                return;
        }
    }
}  