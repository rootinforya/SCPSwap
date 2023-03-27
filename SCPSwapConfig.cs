using System;
using System.Collections.Generic;
using System.ComponentModel;
using Neuron.Core.Meta;
using PlayerRoles;
using Syml;
using Synapse3.SynapseModule.Config;
using Synapse3.SynapseModule.Map.Rooms;
using Synapse3.SynapseModule.Role;
using UnityEngine;
using YamlDotNet.Serialization;

namespace SCPSwap
{
    [Automatic]
    [Serializable]
    [DocumentSection("SCPSwap")]
    public class SCPSwapConfig : IDocumentSection
    {
        public IDictionary<int, int> roleList = new Dictionary<int, int>()
        {
            {173, 0},
            {106, 3},
            {049, 5},
            {079, 7},
            {096, 9},
            {939, 16}
        };
    }
}