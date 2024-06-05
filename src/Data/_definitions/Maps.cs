namespace BTTDRichDiscordPresence.Data;

using System.Collections.Generic;

/// <summary>
/// Defines the available maps in the game.
/// </summary>
public static class Maps
{
    private static Dictionary<int, MapRecord> InternalMaps { get; } = new()
    {
        { -1, new(-1, "Main Menu") },
        { 1,  new(1,  "Recreation Yard") },
        { 2,  new(2,  "Main Building") },
        { 3,  new(3,  "Main Building") },
        { 4,  new(4,  "Cell Block A") },
        { 5,  new(5,  "Cell Block A") },
        { 6,  new(6,  "Cell Block B") },
        { 7,  new(7,  "Cell Block B") },
        { 8,  new(8,  "Cell A207") },
        { 9,  new(9,  "Cell A103") },
        { 10, new(10, "Bathroom") },
        { 11, new(11, "Boxing Ring") },
        { 12, new(12, "General Building") },
        { 13, new(13, "Barbershop") },
        { 14, new(14, "Chapel") },
        { 15, new(15, "Cafeteria") },
        { 16, new(16, "Hiding Place") },
        { 17, new(17, "Infirmary") },
        { 18, new(18, "Segregation") },
        { 19, new(19, "Laundry Room") },
        { 20, new(20, "Sewage Treatment Room") },
        { 21, new(21, "Kitchen") },
        { 22, new(22, "Guard's Room") },
        { 23, new(23, "Roof Site") },
        { 24, new(24, "Warden's Office") },
        { 25, new(25, "Visit Room") },
        { 26, new(26, "Conjugal Visit Room") },
        { 27, new(27, "Court") },
        { 28, new(28, "Pipe Area") },
        { 29, new(29, "Central Garden") },
        { 30, new(30, "Sewage Pipe") },
        { 31, new(31, "Sewer") },
        { 32, new(32, "Mixing Room") },
        { 33, new(33, "Mailroom") },
        { 34, new(34, "Visit Room") },
        { 35, new(35, "Apartment Block") },
        { 36, new(36, "College Dorm") },
        { 37, new(37, "Main Building") },
        { 38, new(38, "Inmate Property Storeroom") },
        { 39, new(39, "Back Room Club") },
        { 50, new(50, "Rooftop Tool Shed") },
        { 51, new(51, "Fallen Angels") },
        { 52, new(52, "Bathroom") },
        { 53, new(53, "Private Room") },
        { 54, new(54, "Backstage Corridor") },
        { 55, new(55, "Dressing Room") },
        { 56, new(56, "Inner Hall") },
        { 57, new(57, "Chaplain's Lounge") },
        { 58, new(58, "Kitchen Cellar") },
        { 59, new(59, "Cooking Room") },
        { 60, new(60, "Operating Room") },
        { 61, new(61, "Electrical Room") },
        { 62, new(62, "House in the Suburbs") },
        { 63, new(63, "Road in the Suburbs") },
        { 64, new(64, "Visitation Corridor") },
        { 65, new(65, "Ground Behind Infirmary") },
        { 66, new(66, "Prison Cell Tower") },
        { 67, new(67, "Drain Depths") },
        { 68, new(68, "TV Building") },
        { 69, new(69, "Hospital Ward") },
        { 70, new(70, "City Cemetery") },
        { 71, new(71, "Apartment Block") },
        { 72, new(72, "Border Checkpoints") },
        { 79, new(79, "Fighter's Room") },
        { 80, new(80, "VIP Box") },
        { 81, new(81, "Boxing Ring") },
        { 82, new(82, "Casino Alley") },
    };

    /// <summary>
    /// Attempts to get a map by its ID.
    /// </summary>
    /// <param name="id">Map identifier.</param>
    /// <returns><see cref="MapRecord"/> if id is found, <c>null</c> otherwise.</returns>
    public static MapRecord? TryGet(int id)
    {
        return InternalMaps.TryGetValue(id, out var map) ? map : null;
    }

    /// <summary>
    /// Gets a <see cref="MapRecord"/> by its ID.
    /// </summary>
    /// <param name="id">Map identifier.</param>
    /// <returns><see cref="MapRecord"/> corresponding to the <paramref name="id"/> provided.</returns>
    public static MapRecord Get(int id) => InternalMaps[id];
}