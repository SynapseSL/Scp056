using System;
using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Ninject;
using PlayerRoles;
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
    [Inject]
    public PlayerService Player { get; set; }
    
    [Inject]
    public Scp056Plugin Plugin { get; set; }

    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
            context.Arguments = new[] { "" };

        if (context.Player.RoleID != 56)
        {
            result.Response = Plugin.Translation.Get(context.Player).NotScp056;
            result.StatusCode = CommandStatusCode.Forbidden;
            return;
        }

        switch (context.Arguments[0].ToLower())
        {
            case "voice":
                if (context.Player.CustomRole is not Scp056PlayerScript script)
                {
                    result.StatusCode = CommandStatusCode.Error;
                    result.Response =
                        "Somehow you are SCP-056 without a Script? Please Report this to an administrator that he should check his Plugin files";
                    return;
                }
                script.ScpChat = !script.ScpChat;
                var trans = context.Player.GetTranslation(Plugin.Translation);
                result.Response = script.ScpChat ? trans.ActivatedScpChat : trans.DeactivatedScpChat;
                return;
            
            case "targets":
                var targets = Player
                    .GetPlayers(x => x.TeamID is (uint)Team.FoundationForces or (uint)Team.ClassD or (uint)Team.Scientists).Count;

                result.Response = Plugin.Translation.Get(context.Player).Targets
                    .Replace("%targets%", targets.ToString());

                result.StatusCode = CommandStatusCode.Ok;
                return;
            
            case "class":
                if (context.Arguments.Length < 2)
                    context.Arguments = new[] { "class", "" };

                if (Enum.TryParse<RoleTypeId>(context.Arguments[1], out var role))
                {
                    (context.Player.CustomRole as Scp056PlayerScript)?.SwapRole(role);
                    result.Response = Plugin.Translation.Get(context.Player).ChangedRole
                        .Replace("%role%", role.ToString());
                    result.StatusCode = CommandStatusCode.Ok;
                    return;
                }
                goto default;

            default:
                result.Response = Plugin.Translation.Commands;
                foreach (var possibleRole in Plugin.Config.AllowedRoles)
                {
                    result.Response += "\n.056 class " + possibleRole;
                }

                result.Response += "\n.056 targets";
                result.Response += "\n.056 voice";
                result.StatusCode = CommandStatusCode.Ok;
                return;
        }
    }
}  