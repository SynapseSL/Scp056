using Neuron.Core.Plugins;
using Synapse3.SynapseModule;

namespace Scp056;

[Plugin(
    Name = "SCP-056",
    Author = "Dimenzio",
    Description = "Adds the Role SCP-056 to the game",
    Version = "3.0.0"
)]
public class Scp056Plugin : ReloadablePlugin<Scp056Config, Scp056Translation>
{
    public EventHandler EventHandler { get; private set; }

    public override void EnablePlugin()
    {
        EventHandler = Synapse.GetAndBind<EventHandler>();
        Logger.Info("Loaded SCP-056 Plugin");
    }
}