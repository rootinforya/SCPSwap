using System;
using Neuron.Core.Meta;
using Neuron.Modules.Configs.Localization;

namespace SCPSwap
{
    [Automatic]
    [Serializable]
    public class SCPSwapTranslation : Translations<SCPSwapTranslation>
    {
        public string pluginLoaded = "SCP Swap has finished loading.";
        public string scpSwapRequest1 = "wants to change role with you. Type";
        public string scpSwapRequest2 = "to accept.";
    }
}