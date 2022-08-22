using System;
using System.Collections.Generic;
using System.ComponentModel;
using Neuron.Core.Meta;
using Syml;
using Synapse3.SynapseModule.Config;
using Synapse3.SynapseModule.Map.Rooms;
using UnityEngine;

namespace Scp056;

[Automatic]
[Serializable]
[DocumentSection("Scp 056")]
public class Scp056Config : IDocumentSection
{
    [Description("The MapPoint where Scp056 should Spawn")]
    public RoomPoint Scp056SpawnPoint { get; set; } =
        new("HeavyArmory", new Vector3(-1.792f, 1.33f, -0.004f), Vector3.zero);

    [Description("If Enabled Scp056 can Hurt Scps(Guns,Generator,FemurBreaker,etc.)")]
    public bool Ff { get; set; } = false;

    [Description("The Amount of Health Scp056 has")]
    public int Scp056Health { get; set; } = 150;

    [Description("The Inventory Scp056 spawns with")]
    public SerializedPlayerInventory Inventory { get; set; } = new()
    {
        Ammo = new SerializedAmmo()
        {
            Ammo9 = 90,
        },
        Items = new List<SerializedPlayerItem>()
        {
            new((uint)ItemType.GunFSP9, 40, 0, Vector3.one, 100, true),
            new((uint)ItemType.KeycardGuard, 0f, 0, Vector3.one, 100, false)
        }
    };

    [Description("The Chanche of which Scp056 spawns")]
    public float SpawnChance { get; set; } = 50;

    [Description("The Amount of Players Required in order to have the Chanche that 056 can spawn")]
    public int RequiredPlayers { get; set; } = 3;

    [Description("If Enabled a Scp will become Scp056.If Disabled a Human will become Scp056")]
    public bool ReplaceScp { get; set; } = false;

    [Description("Prevnts the scenario that only 056 and 079 spawns together")]
    public bool Replace079 { get; set; } = true;
}

