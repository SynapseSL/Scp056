# Scp056
Scp056 is a Scp which fights on the side of the other Scp's and tries to kill all Humans (except for Chaos).
His special ability is that he imitate a Human perfect which mean he can talk to Humans and even change his role so that no one would think that he is an Scp and then can he attack from behind.

# Used Keys
Scp056 uses the [key press](https://github.com/SynapseSL/Synapse/wiki/KeyBind-System) system of Synapse which means Scp056 can quickly change his Role by pressing a key.
| Key | Function |
| :-------------: | :------ |
| Alpha1 | Change the Role to ClassD |
| Alpha2 | Change the Role to Scientist |
| Alpha3 | Change the Role to Guard |
| Alpha4 | Change the Role to MTF |
| Alpha5 | Change the Role to Chaos |
| Alpha6 | Show's the remaining targets |

# Command
If the Player doen't have installed the key press system then he can change his Role with a command
| Command | Function |
| :-------------: | :------ |
| .056 | Gives a list of all 056 Command |
| .056 targets | Gives a number of how many targets are left |
| .056 class D | Change the Role to ClassD |
| .056 class S | Change the Role to Scientist |
| .056 class G | Change the Role to Guard |
| .056 class M | Change the Role to MTF |
| .056 class C | Change the Role to Chaos |

# Config
| ConfigName | Type | Description |
| :-------------: | :---------: | :------ |
| scp056SpawnPoint | [MapPoint](https://github.com/SynapseSL/Synapse/wiki/Command-List#synapse-commands) | The Position where Scp056 should spawn |
| ff | Boolean | If Scp056 can Hurt other Scp's |
| scp056Health | Float | The Amount of Health Scp056 have |
| items | ItemList | The Items which Scp056 gets when he spawn |
| spawnchanche | Float | The chanche that Scp056 spawns |
| requiredPlayers | Integer | The Amount of Players needed before Scp056 can spawn|
| replacescp | Boolean | If set to true Scp056 will be spawned instead of an Scp |

Default Configuration for Scp056
```
[Scp056]
{
scp056SpawnPoint:
  room: HCZ_Room3ar
  x: -1.79200006
  y: 1.33001697
  z: -0.00400558906
ff: false
scp056Health: 150
items:
- iD: 23
  durabillity: 35
  sight: 0
  barrel: 0
  other: 0
  xSize: 1
  ySize: 1
  zSize: 1
- iD: 14
  durabillity: 35
  sight: 0
  barrel: 0
  other: 0
  xSize: 1
  ySize: 1
  zSize: 1
- iD: 4
  durabillity: 35
  sight: 0
  barrel: 0
  other: 0
  xSize: 1
  ySize: 1
  zSize: 1
spawnChanche: 50
requiredPlayers: 3
replaceScp: false
}
```

# Translation
Scp056 also supports the Translation System of Synapse so that you can easily change the Translation of the Plugin

Default:
```
<color=blue><b>You are now</b></color> <color=red><b>Scp</b></color> <color=blue><b>056</b></color>
There still exist %targets% more Targets to kill for you
<color=blue><b>You have killed</b></color> <color=red><b>Scp</b></color> <color=black><b>056</b></color>
<color=blue><b>You are killed by</b></color> <color=red><b>Scp</b></color> <color=black><b>056</b></color>
```
