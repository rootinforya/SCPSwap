using Neuron.Core.Plugins;
using Synapse3.SynapseModule;

namespace SCPSwap
{
    [Plugin(
        Author = "rootinforya",
        Description = "Adds .scpswap command",
        Name = "SCPSwap",
        Version = "1.0.0"
    )]
    public class SCPSwap : ReloadablePlugin<SCPSwapConfig, SCPSwapTranslation>
    {
        public override void EnablePlugin()
        {
            Logger.Info(this.Translation.pluginLoaded);
        }
    }
}