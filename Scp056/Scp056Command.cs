using System;
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
            result.Response = _plugin.Translation.Get(context.Player).NotScp056;
            result.StatusCode = CommandStatusCode.Forbidden;
            return;
        }

        switch (context.Arguments[0].ToLower())
        {
            case "targets":
                var targets = _player
                    .GetPlayers(x => x.TeamID is (uint)Team.MTF or (uint)Team.CDP or (uint)Team.RSC).Count;

                result.Response = _plugin.Translation.Get(context.Player).Targets
                    .Replace("%targets%", targets.ToString());

                result.StatusCode = CommandStatusCode.Ok;
                return;
            
            case "class":
                if (context.Arguments.Length < 2)
                    context.Arguments = new[] { "class", "" };

                if (Enum.TryParse<RoleType>(context.Arguments[1], out var role))
                {
                    (context.Player.CustomRole as Scp056PlayerScript)?.SwapRole(role);
                    result.Response = _plugin.Translation.Get(context.Player).ChangedRole
                        .Replace("%role%", role.ToString());
                    result.StatusCode = CommandStatusCode.Ok;
                    return;
                }
                goto default;

            default:
                result.Response = _plugin.Translation.SelectRole;
                foreach (var possibleRole in _plugin.Config.AllowedRoles)
                {
                    result.Response += "\n.056 class " + possibleRole;
                }
                result.StatusCode = CommandStatusCode.Ok;
                return;
        }
    }
}  