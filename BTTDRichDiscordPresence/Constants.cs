namespace BTTDRichDiscordPresence;

using System.Collections.Generic;

/// <summary>
/// General constants for the plugin.
/// </summary>
/// <remarks>
/// This class needs to be split into multiple classes that define constants according to their domain.
/// </remarks>
internal static class Constants
{
    /// <summary>
    /// Discord Application ID with name and assets;
    /// </summary>
    internal static long AppId { get; } = 1245657071815364680;

    /// <summary>
    /// Maximum number of retries when failing to connect.
    /// </summary>
    internal static int MaxRetries { get; } = 5;

    /// <summary>
    /// Delay between retries in milliseconds.
    /// </summary>
    internal static int RetryDelay { get; } = 5000;

    /// <summary>
    /// Mapping of map ids to map names.
    /// </summary>
    internal static Dictionary<int, string> MapNames { get; } = new()
    {
        { -1, "Main Menu" },
        { 1, "Recreation Yard" },
        { 2, "Main Building" },
        { 3, "Main Building" },
        { 4, "Cell Block A" },
        { 5, "Cell Block A" },
        { 6, "Cell Block B" },
        { 7, "Cell Block B" },
        { 8, "Cell A207" },
        { 9, "Cell A103" },
        { 10, "Bathroom" },
        { 11, "Boxing Ring" },
        { 12, "General Building" },
        { 13, "Barbershop" },
        { 14, "Chapel" },
        { 15, "Cafeteria" },
        { 16, "Hiding Place" },
        { 17, "Infirmary" },
        { 18, "Segregation" },
        { 19, "Laundry Room" },
        { 20, "Sewage Treatment Room" },
        { 21, "Kitchen" },
        { 22, "Guard's Room" },
        { 23, "Roof Site" },
        { 24, "Warden's Office" },
        { 25, "Visit Room" },
        { 26, "Conjugal Visit Room" },
        { 27, "Court" },
        { 28, "Pipe Area" },
        { 29, "Central Garden" },
        { 30, "Sewage Pipe" },
        { 31, "Sewer" },
        { 32, "Mixing Room" },
        { 33, "Mailroom" },
        { 34, "Visit Room" },
        { 35, "Apartment Block" },
        { 36, "College Dorm" },
        { 37, "Main Building" },
        { 38, "Inmate Property Storeroom" },
        { 39, "Back Room Club" },
        { 50, "Rooftop Tool Shed" },
        { 51, "Fallen Angels" },
        { 52, "Bathroom" },
        { 53, "Private Room" },
        { 54, "Backstage Corridor" },
        { 55, "Dressing Room" },
        { 56, "Inner Hall" },
        { 57, "Chaplain's Lounge" },
        { 58, "Kitchen Cellar" },
        { 59, "Cooking Room" },
        { 60, "Operating Room" },
        { 61, "Electrical Room" },
        { 62, "House in the Suburbs" },
        { 63, "Road in the Suburbs" },
        { 64, "Visitation Corridor" },
        { 65, "Ground Behind Infirmary" },
        { 66, "Prison Cell Tower" },
        { 67, "Drain Depths" },
        { 68, "TV Building" },
        { 69, "Hospital Ward" },
        { 70, "City Cemetery" },
        { 71, "Apartment Block" },
        { 72, "Border Checkpoints" },
        { 79, "Fighter's Room" },
        { 80, "VIP Box" },
        { 81, "Boxing Ring" },
        { 82, "Casino Alley" },
    };
}