using System;
using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using PlayerRoles;
using Synapse3.SynapseModule.Command;
using Neuron.Core.Events;
using Synapse3.SynapseModule.Events;
using MEC;
using System.Collections.Generic;
using Synapse3.SynapseModule.Map.Schematic;
using UnityEngine;
using Synapse3.SynapseModule.Map.Rooms;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Player;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Map.Objects;

namespace SCPSwap
{
    [Automatic]
    public class EventHandler : Listener
    {
        [EventHandler]
        public void OnRoundStart(RoundStartEvent ev)
        {
            Timing.CallDelayed(0.02f, () =>
            {
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
            });
        }
    }

    [Automatic]
    [SynapseCommand(
        CommandName = "SCPSwap",
        Aliases = new[] { "scpswap" },
        Description = "Lets you switch role with another already existing SCP",
        Platforms = new[] { CommandPlatform.PlayerConsole }
    )]
    public class SCPSwapCommand : SynapseCommand
    {
        public static Dictionary<int, int> SwapList { get; set; }
        private readonly SCPSwap _plugin;
        public SCPSwapCommand(SCPSwap plugin)
        {
            _plugin = plugin;
        }
        public override void Execute(SynapseContext context, ref CommandResult result)
        {
            if (context.Player.TeamID != (byte)Team.SCPs)
            {
                result.Response = "You are not an SCP";
            }
            else if (Int32.TryParse(context.Arguments[0], out int _role) && _plugin.Config.roleList.ContainsKey(_role))
            {
                if (SwapList.ContainsKey(context.Player.PlayerId))
                    SwapList.Remove(context.Player.PlayerId);
                SwapList.Add(context.Player.PlayerId, _plugin.Config.roleList[_role]);
                result.Response = "Request sent";

                foreach (SynapsePlayer player in Synapse.Get<PlayerService>().Players)
                {
                    if (SwapList[context.Player.PlayerId] == player.RoleID)
                    {
                        player.SendWindowMessage($"{context.Player.NickName}({context.Player.RoleName}) " +
                            $"{_plugin.Translation.scpSwapRequest1} .scpswap {context.Player.RoleName} " +
                            $"{_plugin.Translation.scpSwapRequest2}");
                        if (SwapList[player.PlayerId] == context.Player.RoleID)
                        {
                            player.RoleID = context.Player.RoleID;
                            context.Player.RoleID = (uint)SwapList[context.Player.PlayerId];
                            SwapList.Remove(context.Player.PlayerId);
                            SwapList.Remove(player.PlayerId);
                            result.Response = "SCPs swapped.";
                            result.StatusCode = CommandStatusCode.Ok;
                        }
                    }
                }
            }
            else
            {
                result.Response = "A problem occured";
                result.StatusCode = CommandStatusCode.Error;
            }
        }
    }
}