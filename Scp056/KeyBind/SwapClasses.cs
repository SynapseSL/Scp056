using Neuron.Core.Meta;
using PlayerRoles;
using Synapse3.SynapseModule.KeyBind;
using UnityEngine;

namespace Scp056.KeyBind;

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad1,
    CommandDescription = "Swaps to D-Class as 056",
    CommandName = "ClassDSwap"
)]
public class ClassD : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.ClassD;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad2,
    CommandDescription = "Swaps to Scientist as 056",
    CommandName = "ScientistSwap"
)]
public class Scientist : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.Scientist;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad3,
    CommandDescription = "Swaps to Guard as 056",
    CommandName = "GuardSwap"
)]
public class Guard : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.FacilityGuard;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad4,
    CommandDescription = "Swaps to NTF as 056",
    CommandName = "NtfSwap"
)]
public class Ntf : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.NtfSergeant;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad5,
    CommandDescription = "Swaps to Chaos as 056",
    CommandName = "ChaosSwap"
)]
public class Chaos : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.ChaosRepressor;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad6,
    CommandDescription = "Swaps to Scp049 as 056",
    CommandName = "Scp049Swap"
)]
public class Scp049 : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.Scp049;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad7,
    CommandDescription = "Swaps to Scp173 as 056",
    CommandName = "Scp173Swap"
)]
public class Scp173 : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.Scp173;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad8,
    CommandDescription = "Swaps to Scp096 as 056",
    CommandName = "Scp096Swap"
)]
public class Scp096 : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.Scp096;
}

[Automatic]
[KeyBind(
    Bind = KeyCode.Keypad9,
    CommandDescription = "Swaps to Scp939 as 056",
    CommandName = "Scp939Swap"
)]
public class Scp939 : Scp056SwapBind
{
    public override RoleTypeId SwapRole => RoleTypeId.Scp939;
}