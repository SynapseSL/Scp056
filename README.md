# Scp056
Scp056 is a Scp which fights on the side of the other Scp's and tries to kill all Humans (except for Chaos).
His special ability is that he imitate a Human perfect which mean he can talk to Humans and even change his role so that no one would think that he is an Scp.

# RoleInformation
RoleID: 56

RoleName : Scp056

# KeyBind
Scp056 uses the [key press](https://github.com/SynapseSL/Synapse/wiki/KeyBind-System) system of Synapse which means Scp056 can quickly change his Role by pressing a key.
| Key | Function |
| :-------------: | :------ |
| KeyPad0 | Displays the amount of targets left |
| KeyPad1 | Change the Role to ClassD |
| KeyPad2 | Change the Role to Scientist |
| KeyPad3 | Change the Role to Guard |
| KeyPad4 | Change the Role to NtfSergeant |
| KeyPad5 | Change the Role to ChaosRepressor |
| KeyPad6 | Change the Role to Scp049 |
| KeyPad7 | Change the Role to Scp173 |
| KeyPad8 | Change the Role to Scp096 |
| KeyPad9 | Change the Role to Scp939 |

# Command
If the Player doesn't have installed the key press system then he can change his Role with a command
| Command | Function |
| :-------------: | :------ |
| .056 | Gives a list of all 056 Command |
| .056 targets | Gives a number of how many targets are left |
| .056 class RoleName | Change the Role to the specified class |

# Config
|         ConfigName          |          Type           | Description                                                        |
|:---------------------------:|:-----------------------:|:-------------------------------------------------------------------|
|     scp056Configuration     | Scp056RoleConfiguration | The basic role information for SCP-056                             |
|        allowedRoles         |    List<RoleTypeID>     | A list of all allowed roles that 056 can swap to                   |
|             ff              |         Boolean         | If Scp056 can Hurt other Scp's                                     |
| enableDefaultSpawnBehaviour |         Boolean         | When true the plugin will spawn 056 when the requirements are meet |
|         spawnChance         |          float          | The chance of 056 spawning into the round                          |
|       requiredPlayers       |         Integer         | The required amount of players needed before 056 can spawn         |
|        replaceScp           |        Boolean          | When true one Scp less will spawn when 056 spawns                  |

Default Configuration for Scp056
```yml
[Scp 056]
scp056Configuration:
# The Role that the Player spawns as
  role: Tutorial
  # The Role that is Visible for other Humans at the start of the Round
  visibleRole: FacilityGuard
  ownRole: None
  # The Role SCP-056 becomes when he Escapes
  escapeRole: 0
  health: 200
  maxHealth: 200
  artificialHealth: 0
  maxArtificialHealth: 75
  possibleSpawns:
  - roomName: HeavyArmory
    position:
      x: -1.79999995
      y: 1.35000002
      z: 0
    rotation:
      x: 0
      y: -90
      z: 0
  possibleInventories:
  - items:
    - chance: 100
      provideFully: true
      iD: 14
      durability: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
    - chance: 100
      provideFully: true
      iD: 34
      durability: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
    - chance: 100
      provideFully: true
      iD: 7
      durability: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
    - chance: 100
      provideFully: true
      iD: 23
      durability: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
    - chance: 100
      provideFully: true
      iD: 26
      durability: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
    - chance: 100
      provideFully: true
      iD: 36
      durability: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
    - chance: 100
      provideFully: true
      iD: 12
      durability: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
    ammo:
      ammo5: 0
      ammo7: 0
      ammo9: 60
      ammo12: 0
      ammo44: 0
  scale:
    x: 1
    y: 1
    z: 1
allowedRoles:
- ClassD
- Scientist
- FacilityGuard
- ChaosConscript
- ChaosMarauder
- ChaosRepressor
- ChaosRifleman
- NtfCaptain
- NtfPrivate
- NtfSergeant
- NtfSpecialist
- Scp049
- Scp096
- Scp106
- Scp173
- Scp0492
- Scp939
# If Enabled Scp056 can Hurt Scps(Guns,Generator,FemurBreaker,etc.)
ff: false
# If Disabled the entire Spawn logic will be skipped and all configs below become useless. Use this when you use another Plugin to spawn Roles
enableDefaultSpawnBehaviour: true
# The Chanche of which Scp056 spawns
spawnChance: 50
# The Amount of Players Required in order to have the Chanche that 056 can spawn
requiredPlayers: 3
# If Enabled a Scp will become Scp056.If Disabled a Human will become Scp056
replaceScp: false
```
