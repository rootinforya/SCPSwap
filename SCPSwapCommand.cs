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
        //TODO Remove collisions of the MOAI
        private SynapsePlayer moaiPlayer = null;
        public SynapseSchematic Platypus1 { get; set; }
        public SynapseSchematic Platypus2 { get; set; }
        public SynapseSchematic Platypus3 { get; set; }
        public SynapseSchematic Platypus4 { get; set; }
        public SynapseSchematic Platypus5 { get; set; }
        public SynapseSchematic Platypus6 { get; set; }
        public SynapseSchematic Platypus7 { get; set; }
        public SynapseSchematic Platypus8 { get; set; }
        public SynapseSchematic Platypus9 { get; set; }
        public SynapseSchematic Platypus10 { get; set; }
        public SynapseSchematic Platypus11 { get; set; }
        public SynapseSchematic Moai { get; set; }
        private bool isThere173 = false;

        [EventHandler]
        public void OnRoundStart(RoundStartEvent ev)
        {
            Timing.CallDelayed(0.02f, () =>
            {
                SCPSwapCommand.SwapList = new Dictionary<int, int>();
                moaiPlayer = null;
                isThere173 = false;

                Platypus1 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Scp173", new Vector3(6.5f, 12.5f, 12), Vector3.zero).GetMapPosition());
                Platypus2 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("LczCheckpointA", new Vector3(3.5f, 2, 5.5f), Vector3.zero).GetMapPosition());
                Platypus3 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("LczCheckpointB", new Vector3(-3, 2, 6), Vector3.zero).GetMapPosition());
                Platypus4 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Servers", new Vector3(0, 0, 0), Vector3.zero).GetMapPosition());
                Platypus5 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("LightArmory", new Vector3(1.5f, 1, 0), Vector3.zero).GetMapPosition());
                Platypus6 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("GateB", new Vector3(-5.5f, 1.2f, 0), Vector3.zero).GetMapPosition());
                Platypus7 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Scp372", new Vector3(5.5f, 1, 4), Vector3.zero).GetMapPosition());
                Platypus8 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Surface", new Vector3(128, -10, 20), Vector3.zero).GetMapPosition());
                Platypus9 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Surface", new Vector3(38, 1.4f, -36), Vector3.zero).GetMapPosition());
                Platypus10 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("MicroHid", new Vector3(-5.5f, 1, -4.5f), Vector3.zero).GetMapPosition());
                Platypus11 = Synapse.Get<SchematicService>().SpawnSchematic(101, new RoomPoint("Toilets", new Vector3(-3.5f, 1, -6), Vector3.zero).GetMapPosition());
                Moai = Synapse.Get<SchematicService>().SpawnSchematic(102, new RoomPoint("Scp173", new Vector3(18, 11.5f, 8), Vector3.zero).GetMapPosition());
                Moai.Scale = new Vector3(-1, -1, -1);

                foreach (SynapsePlayer player in Synapse.Get<PlayerService>().Players)
                {
                    if (player.RoleType == RoleTypeId.Scp173)
                    {
                        moaiPlayer = player;
                        Moai.HideFromPlayer(moaiPlayer);
                        isThere173 = true;
                    }
                }

                if (!isThere173)
                {
                    foreach (SynapsePlayer player in Synapse.Get<PlayerService>().Players)
                    {
                        if (player.TeamID == (uint)Team.SCPs)
                        {
                            moaiPlayer = player;
                            player.RoleID = (uint)RoleTypeId.Scp173;
                            Moai.HideFromPlayer(moaiPlayer);
                            isThere173 = true;
                            break;
                        }
                    }
                }

                Platypus1.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus2.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus3.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus4.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus5.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus6.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus7.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus8.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus9.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus10.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Platypus11.Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            });
        }

        [EventHandler]
        public void OnUpdate(UpdateEvent ev)
        {
            Platypus1.Rotation = Quaternion.Euler(0, Platypus1.Rotation.eulerAngles.y + 0.75f, 0);
            Platypus2.Rotation = Quaternion.Euler(0, Platypus2.Rotation.eulerAngles.y + 0.7f, 0);
            Platypus3.Rotation = Quaternion.Euler(0, Platypus3.Rotation.eulerAngles.y + 0.76f, 0);
            Platypus4.Rotation = Quaternion.Euler(0, Platypus4.Rotation.eulerAngles.y + 0.71f, 0);
            Platypus5.Rotation = Quaternion.Euler(0, Platypus5.Rotation.eulerAngles.y + 0.72f, 0);
            Platypus6.Rotation = Quaternion.Euler(0, Platypus6.Rotation.eulerAngles.y + 0.75f, 0);
            Platypus7.Rotation = Quaternion.Euler(0, Platypus7.Rotation.eulerAngles.y + 0.73f, 0);
            Platypus8.Rotation = Quaternion.Euler(0, Platypus8.Rotation.eulerAngles.y + 0.77f, 0);
            Platypus9.Rotation = Quaternion.Euler(0, Platypus9.Rotation.eulerAngles.y + 0.5f, 0);
            Platypus10.Rotation = Quaternion.Euler(0, Platypus10.Rotation.eulerAngles.y + 0.85f, 0);
            Platypus11.Rotation = Quaternion.Euler(0, Platypus11.Rotation.eulerAngles.y + 0.74f, 0);

            moaiPlayer.GiveEffect(Synapse3.SynapseModule.Enums.Effect.Invisible);
            moaiPlayer.GiveEffect(Synapse3.SynapseModule.Enums.Effect.Invigorated);
            Moai.Position = moaiPlayer.Position + new Vector3(0, 0.25f, 0);
            Moai.Rotation = Quaternion.Euler(180, moaiPlayer.RotationHorizontal - 90, 0);
        }

        [EventHandler]
        public void OnRespawn(SpawnTeamEvent ev)
        {
            if (ev.TeamId == (uint)Team.ChaosInsurgency)
            {
                foreach (SynapsePlayer player in ev.Players)
                {
                    player.FakeRoleManager.VisibleRole.RoleTypeId = RoleTypeId.ChaosRifleman;
                }
            }
            else
            {
                foreach (SynapsePlayer player in ev.Players)
                {
                    player.FakeRoleManager.VisibleRole.RoleTypeId = RoleTypeId.NtfSergeant;
                }
            }
        }

        [EventHandler]
        public void OnDeath(DeathEvent ev)
        {
            ev.Player.FakeRoleManager.Reset();
            if (ev.Player == moaiPlayer)
            {
                moaiPlayer = null;
                Moai.Destroy();
            }
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
            else if (Int32.TryParse(context.Arguments[0], out int _role) && _plugin.Config.roleList.ContainsKey(_role) && _role != 173)
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