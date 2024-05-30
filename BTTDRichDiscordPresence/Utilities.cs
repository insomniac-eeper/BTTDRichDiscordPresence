namespace BTTDRichDiscordPresence;

/// <summary>
/// Useful utilities for the plugin.
/// </summary>
public static class Utilities
{
    /// <summary>
    /// Transforms map name to map slug (lowercase, underscores instead of spaces).
    /// </summary>
    /// <param name="mapName">Natural syntax map name.</param>
    /// <returns>
    /// Slug of natural map name with underscores instead of spaces, lowercase, and single quotes removed.
    /// </returns>
    public static string MapNameToMapSlug(string mapName)
    {
        return mapName
            .Replace(' ', '_')
            .Remove('\'')
            .ToLower();
    }
}