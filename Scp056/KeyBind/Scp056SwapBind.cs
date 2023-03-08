using PlayerRoles;
using Synapse3.SynapseModule.Player;

namespace Scp056.KeyBind;

public abstract class Scp056SwapBind : Synapse3.SynapseModule.KeyBind.KeyBind
{
    public abstract RoleTypeId SwapRole { get; }
    
    public override void Execute(SynapsePlayer player)
    {
        if (player.RoleID != 56) return;
        (player.CustomRole as Scp056PlayerScript)?.SwapRole(SwapRole);
    }
}