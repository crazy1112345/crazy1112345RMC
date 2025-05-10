using Content.Shared.Clothing.EntitySystems;
using Content.Shared.Inventory;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared.Clothing.Components;

/// <summary>
///     Allow players to change clothing sprite to any other clothing prototype.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
[Access(typeof(SharedDisguiseItemSystem))]
public sealed partial class DisguiseItemComponent : Component
{
    /// <summary>
    ///     Filter possible disguise options by their slot flag.
    /// </summary>
    [ViewVariables(VVAccess.ReadOnly)]
    [DataField(required: true)]
    public SlotFlags Slot;

    /// <summary>
    ///     EntityPrototype id that disguise item is trying to mimic.
    /// </summary>
    [ViewVariables(VVAccess.ReadOnly)]
    [DataField(required: true), AutoNetworkedField]
    public EntProtoId? Default;

    /// <summary>
    ///     Current user that wears disguise clothing.
    /// </summary>
    [ViewVariables]
    public EntityUid? User;

    /// <summary>
    ///     Filter possible disguise options by a tag in addition to WhitelistDisguise.
    /// </summary>
    [DataField]
    public string? RequireTag;
}

[Serializable, NetSerializable]
public sealed class DisguiseBoundUserInterfaceState : BoundUserInterfaceState
{
    public readonly SlotFlags Slot;
    public readonly string? SelectedId;
    public readonly string? RequiredTag;

    public DisguiseBoundUserInterfaceState(SlotFlags slot, string? selectedId, string? requiredTag)
    {
        Slot = slot;
        SelectedId = selectedId;
        RequiredTag = requiredTag;
    }
}

[Serializable, NetSerializable]
public sealed class DisguisePrototypeSelectedMessage : BoundUserInterfaceMessage
{
    public readonly string SelectedId;

    public DisguisePrototypeSelectedMessage(string selectedId)
    {
        SelectedId = selectedId;
    }
}

[Serializable, NetSerializable]
public enum DisguiseUiKey : byte
{
    Key
}
