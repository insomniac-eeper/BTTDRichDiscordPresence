namespace BTTDRichDiscordPresence.Data;
using System.Collections.Generic;

public static class Maps
{
    private static Dictionary<int, MapRecord> _maps { get; } = new()
    {
        { -1, new("Main Menu") },
        { 1, new("Recreation Yard") },
        { 2, new("Main Building") },
        { 3, new("Main Building") },
        { 4, new("Cell Block A") },
        { 5, new("Cell Block A") },
        { 6, new("Cell Block B") },
        { 7, new("Cell Block B") },
        { 8, new("Cell A207") },
        { 9, new("Cell A103") },
        { 10, new("Bathroom") },
        { 11, new("Boxing Ring") },
        { 12, new("General Building") },
        { 13, new("Barbershop") },
        { 14, new("Chapel") },
        { 15, new("Cafeteria") },
        { 16, new("Hiding Place") },
        { 17, new("Infirmary") },
        { 18, new("Segregation") },
        { 19, new("Laundry Room") },
        { 20, new("Sewage Treatment Room") },
        { 21, new("Kitchen") },
        { 22, new("Guard's Room") },
        { 23, new("Roof Site") },
        { 24, new("Warden's Office") },
        { 25, new("Visit Room") },
        { 26, new("Conjugal Visit Room") },
        { 27, new("Court") },
        { 28, new("Pipe Area") },
        { 29, new("Central Garden") },
        { 30, new("Sewage Pipe") },
        { 31, new("Sewer") },
        { 32, new("Mixing Room") },
        { 33, new("Mailroom") },
        { 34, new("Visit Room") },
        { 35, new("Apartment Block") },
        { 36, new("College Dorm") },
        { 37, new("Main Building") },
        { 38, new("Inmate Property Storeroom") },
        { 39, new("Back Room Club") },
        { 50, new("Rooftop Tool Shed") },
        { 51, new("Fallen Angels") },
        { 52, new("Bathroom") },
        { 53, new("Private Room") },
        { 54, new("Backstage Corridor") },
        { 55, new("Dressing Room") },
        { 56, new("Inner Hall") },
        { 57, new("Chaplain's Lounge") },
        { 58, new("Kitchen Cellar") },
        { 59, new("Cooking Room") },
        { 60, new("Operating Room") },
        { 61, new("Electrical Room") },
        { 62, new("House in the Suburbs") },
        { 63, new("Road in the Suburbs") },
        { 64, new("Visitation Corridor") },
        { 65, new("Ground Behind Infirmary") },
        { 66, new("Prison Cell Tower") },
        { 67, new("Drain Depths") },
        { 68, new("TV Building") },
        { 69, new("Hospital Ward") },
        { 70, new("City Cemetery") },
        { 71, new("Apartment Block") },
        { 72, new("Border Checkpoints") },
        { 79, new("Fighter's Room") },
        { 80, new("VIP Box") },
        { 81, new("Boxing Ring") },
        { 82, new("Casino Alley") },
    };

    public static MapRecord? TryGet(int id)
    {
        return _maps.TryGetValue(id, out var map) ? map : null;
    }

    public static MapRecord Get(int id) => _maps[id];
}