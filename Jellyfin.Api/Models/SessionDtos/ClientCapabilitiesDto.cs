using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Jellyfin.Data.Enums;
using Jellyfin.Extensions.Json.Converters;
using MediaBrowser.Model.Dlna;
using MediaBrowser.Model.Session;

namespace Jellyfin.Api.Models.SessionDtos;

/// <summary>
/// Client capabilities dto.
/// </summary>
public class ClientCapabilitiesDto
{
    /// <summary>
    /// Gets or sets the list of playable media types.
    /// </summary>
    [JsonConverter(typeof(JsonCommaDelimitedArrayConverterFactory))]
    public IReadOnlyList<MediaType> PlayableMediaTypes { get; set; } = Array.Empty<MediaType>();

    /// <summary>
    /// Gets or sets the list of supported commands.
    /// </summary>
    [JsonConverter(typeof(JsonCommaDelimitedArrayConverterFactory))]
    public IReadOnlyList<GeneralCommandType> SupportedCommands { get; set; } = Array.Empty<GeneralCommandType>();

    /// <summary>
    /// Gets or sets a value indicating whether session supports media control.
    /// </summary>
    public bool SupportsMediaControl { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether session supports a persistent identifier.
    /// </summary>
    public bool SupportsPersistentIdentifier { get; set; }

    /// <summary>
    /// Gets or sets the device profile.
    /// </summary>
    public DeviceProfile? DeviceProfile { get; set; }

    /// <summary>
    /// Gets or sets the app store url.
    /// </summary>
    public string? AppStoreUrl { get; set; }

    /// <summary>
    /// Gets or sets the icon url.
    /// </summary>
    public string? IconUrl { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    // TODO: Remove after 10.9
    [Obsolete("Unused")]
    [DefaultValue(false)]
    public bool? SupportsContentUploading { get; set; } = false;

    // TODO: Remove after 10.9
    [Obsolete("Unused")]
    [DefaultValue(false)]
    public bool? SupportsSync { get; set; } = false;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Convert the dto to the full <see cref="ClientCapabilities"/> model.
    /// </summary>
    /// <returns>The converted <see cref="ClientCapabilities"/> model.</returns>
    public ClientCapabilities ToClientCapabilities()
    {
        return new ClientCapabilities
        {
            PlayableMediaTypes = PlayableMediaTypes,
            SupportedCommands = SupportedCommands,
            SupportsMediaControl = SupportsMediaControl,
            SupportsPersistentIdentifier = SupportsPersistentIdentifier,
            DeviceProfile = DeviceProfile,
            AppStoreUrl = AppStoreUrl,
            IconUrl = IconUrl
        };
    }
}
