using Content.Shared.Chat;
using Content.Shared.Tools;
using Robust.Shared.Audio;
using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.Radio.Components;

/// <summary>
///     This component is by entities that can contain encryption keys
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class EncryptionKeyHolderComponent : Component
{
    /// <summary>
    ///     Whether or not encryption keys can be removed from the headset.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("keysUnlocked")]
    [AutoNetworkedField]
    public bool KeysUnlocked = true;

    /// <summary>
    ///     The tool required to extract the encryption keys from the headset.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("keysExtractionMethod", customTypeSerializer: typeof(PrototypeIdSerializer<ToolQualityPrototype>))]
    [AutoNetworkedField]
    public string KeysExtractionMethod = "Screwing";

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("keySlots")]
    [AutoNetworkedField]
    public int KeySlots = 2;

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("keyExtractionSound")]
    [AutoNetworkedField]
    public SoundSpecifier KeyExtractionSound = new SoundPathSpecifier("/Audio/Items/pistol_magout.ogg");

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("keyInsertionSound")]
    [AutoNetworkedField]
    public SoundSpecifier KeyInsertionSound = new SoundPathSpecifier("/Audio/Items/pistol_magin.ogg");

    [ViewVariables]
    public Container KeyContainer = default!;
    public const string KeyContainerName = "key_slots";

    /// <summary>
    ///     Combined set of radio channels provided by all contained keys.
    /// </summary>
    [ViewVariables]
    [AutoNetworkedField]
    public HashSet<string> Channels = new();

    /// <summary>
    ///     This is the channel that will be used when using the default/department prefix (<see cref="SharedChatSystem.DefaultChannelKey"/>).
    /// </summary>
    [ViewVariables]
    [AutoNetworkedField]
    public string? DefaultChannel;
}
