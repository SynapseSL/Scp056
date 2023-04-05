using Neuron.Core.Meta;
using Ninject;
using Synapse3.SynapseModule.KeyBind;
using Synapse3.SynapseModule.Player;
using UnityEngine;

namespace Scp056.KeyBind;

[Automatic]
[KeyBind(
    Bind = KeyCode.V,
    CommandName = "Scp056 ScpVoiceChat",
    CommandDescription = "Toggles the SCP-Voice Chat for SCP-056"
    )]
public class ScpVoiceChatBind : Synapse3.SynapseModule.KeyBind.KeyBind
{
    [Inject]
    public Scp056Plugin Plugin { get; set; }
    
    public override void Execute(SynapsePlayer player)
    {
        if (player.RoleID != 56 || player.CustomRole is not Scp056PlayerScript script) return;
        script.ScpChat = !script.ScpChat;
        var trans = player.GetTranslation(Plugin.Translation);
        player.SendHint(script.ScpChat ? trans.ActivatedScpChat : trans.DeactivatedScpChat);
    }
}