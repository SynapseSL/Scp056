using System;
using System.Collections.Generic;
using System.ComponentModel;
using Neuron.Core.Meta;
using Syml;
using Synapse3.SynapseModule.Config;
using Synapse3.SynapseModule.Map.Rooms;
using Synapse3.SynapseModule.Role;
using UnityEngine;

namespace Scp056;

[Automatic]
[Serializable]
[DocumentSection("Scp 056")]
public class Scp056Config : IDocumentSection
{
    public Scp056RoleConfiguration Scp056Configuration { get; set; } = new()
    {
        Health = 200,
        MaxHealth = 200,
        VisibleRole = RoleType.FacilityGuard,
        Role = RoleType.Tutorial,
        Unit = "Human SCP",
        UnitId = 7,
        ArtificialHealth = 0,
        MaxArtificialHealth = 75,
        EscapeRole = 0,
        PossibleSpawns = new[]
        {
            new RoomPoint("HeavyArmory", new Vector3(-1.8f, 1.35f, -0f), new Vector3(0f, -90f, 0f))
        },
        PossibleInventories = new[]
        {
            new SerializedPlayerInventory()
            {
                Items = new List<SerializedPlayerItem>()
                {
                    new()
                    {
                        ID = 14
                    },
                    new()
                    {
                        ID = 34
                    },
                    new()
                    {
                        ID = 7,
                    },
                    new()
                    {
                        ID = 23,
                        ProvideFully = true,
                    },
                    new()
                    {
                        ID = 26
                    },
                    new()
                    {
                        ID = 36
                    },
                    new()
                    {
                        ID = 12
                    }
                },
                Ammo = new SerializedAmmo()
                {
                    Ammo9 = 60,
                }
            }
        }
    };

    public List<RoleType> AllowedRoles { get; set; } = new List<RoleType>()
    {
        RoleType.ClassD,
        RoleType.Scientist,
        RoleType.FacilityGuard,
        RoleType.ChaosConscript,
        RoleType.ChaosMarauder,
        RoleType.ChaosRepressor,
        RoleType.ChaosRifleman,
        RoleType.NtfCaptain,
        RoleType.NtfPrivate,
        RoleType.NtfSergeant,
        RoleType.NtfSpecialist,
        RoleType.Scp049,
        RoleType.Scp096,
        RoleType.Scp106,
        RoleType.Scp173,
        RoleType.Scp0492,
        RoleType.Scp93953,
        RoleType.Scp93989
    };

    [Description("If Enabled Scp056 can Hurt Scps(Guns,Generator,FemurBreaker,etc.)")]
    public bool Ff { get; set; } = false;

    [Description("If Disabled the entire Spawn logic will be skipped and all configs below become useless. Use this when you use another Plugin to spawn Roles")]
    public bool EnableDefaultSpawnBehaviour { get; set; } = true;

    [Description("The Chanche of which Scp056 spawns")]
    public float SpawnChance { get; set; } = 50;

    [Description("The Amount of Players Required in order to have the Chanche that 056 can spawn")]
    public int RequiredPlayers { get; set; } = 3;

    [Description("If Enabled a Scp will become Scp056.If Disabled a Human will become Scp056")]
    public bool ReplaceScp { get; set; } = false;

    [Description("Prevnts the scenario that only 056 and 079 spawns together")]
    public bool Replace079 { get; set; } = true;
    
    public class Scp056RoleConfiguration : IAbstractRoleConfig
    {
        [Description("The Role that is Visible for other SCP's")]
        public RoleType VisibleRoleForScp { get; set; } = RoleType.Scp0492;
        [Description("The Role that the Player spawns as")]
        public RoleType Role { get; set; }
        [Description("The Role that is Visible for other Humans at the start of the Round")]
        public RoleType VisibleRole { get; set; }
        [Description("The Role SCP-056 becomes when he Escapes")]
        public uint EscapeRole { get; set; }
        public float Health { get; set; }
        public float MaxHealth { get; set; }
        public float ArtificialHealth { get; set; }
        public float MaxArtificialHealth { get; set; }
        public RoomPoint[] PossibleSpawns { get; set; }
        public SerializedPlayerInventory[] PossibleInventories { get; set; }
        [Description("The UnitId which should be assigned to SCP-056 (like the Unit list for Mtf's at the top right which would be 2)")]
        public byte UnitId { get; set; }
        [Description("The Unit Name of SCP-056")]
        public string Unit { get; set; }
    }
}

