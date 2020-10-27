using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Scp056
{
    public class Config : AbstractConfigSection
    {
        [Description("The MapPoint where Scp056 should Spawn")]
        public SerializedMapPoint Scp056SpawnPoint = new SerializedMapPoint("HCZ_Room3ar", -1.792f, 1.330017f, -0.004005589f);

        [Description("If Enabled Scp056 can Hurt Scps(Guns,Generator,FemurBreaker,etc.)")]
        public bool ff = false;

        [Description("The Amount of Health Scp056 has")]
        public int Scp056Health = 150;

        [Description("The Items Scp056 spawns with")]
        public List<SerializedItem> Items = new List<SerializedItem>()
        {
            new SerializedItem((int)ItemType.GunMP7,35,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Medkit,35,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.KeycardGuard,35,0,0,0,Vector3.one),
        };

        [Description("The Chanche of which Scp056 spawns")]
        public float SpawnChanche = 50;

        [Description("The Amount of Players Required in order to have the Chanche that 056 can spawn")]
        public int RequiredPlayers = 3;

        [Description("If Enabled a Scp will become Scp056.If Disabled a Human will become Scp056")]
        public bool ReplaceScp = false;
    }
}
