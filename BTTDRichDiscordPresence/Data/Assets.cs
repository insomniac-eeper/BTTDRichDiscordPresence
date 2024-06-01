namespace BTTDRichDiscordPresence.Data;

using System.Collections.Generic;

public static class Assets
{
    private static Dictionary<string, string> _assetIdentifiers { get; } = new()
    {
        { "Main Menu", "main_menu" },
        { "Recreation Yard","map_recreation_yard" },
        { "Main Building", "map_main_building"},
        { "Cell Block A", "map_cell_block_a"},
        { "Cell Block B", "map_cell_block_b"},
        { "Cell A207", "map_cell_a207"},
        { "Cell A103", "map_cell_a103"},
        { "Bathroom", "map_bathroom" },
        { "Boxing Ring", "map_boxing_ring" },
        { "General Building", "map_general_building" },
        { "Barbershop", "map_barbershop" },
        { "Chapel", "map_chapel" },
        { "Cafeteria", "map_cafeteria" },
        { "Hiding Place", "map_hiding_place" },
        { "Infirmary", "map_infirmary" },
        { "Segregation", "map_segregation" },
        { "Laundry Room", "map_laundry_room" },
        { "Sewage Treatment Room", "map_sewage_treatment_room" },
        { "Kitchen", "map_kitchen" },
        { "Guard's Room", "map_guards_room" },
        { "Roof Site", "map_roof_site" },
        { "Warden's Office", "map_wardens_office" },
        { "Visit Room", "map_visit_room" },
        { "Conjugal Visit Room", "map_conjugal_visit_room" },
        { "Court", "map_court" },
        { "Pipe Area", "map_pipe_area" },
        { "Central Garden", "map_central_garden" },
        { "Sewage Pipe", "map_sewage_pipe" },
        { "Sewer", "map_sewer" },
        { "Mixing Room", "map_mixing_room" },
        { "Mailroom", "map_mailroom" },
        { "Visit Room", "map_visit_room" },
        { "Apartment Block", "map_apartment_block" },
        { "College Dorm", "map_college_dorm" },
        { "Main Building", "map_main_building" },
        { "Inmate Property Storeroom", "map_inmate_property_storeroom" },
        { "Back Room Club", "map_back_room_club" },
        { "Rooftop Tool Shed", "map_rooftop_tool_shed" },
        { "Fallen Angels", "map_fallen_angels" },
        { "Bathroom", "map_bathroom" },
        { "Private Room", "map_private_room" },
        { "Backstage Corridor", "map_backstage_corridor" },
        { "Dressing Room", "map_dressing_room" },
        { "Inner Hall", "map_inner_hall" },
        { "Chaplain's Lounge", "map_chaplains_lounge" },
        { "Kitchen Cellar", "map_kitchen_cellar" },
        { "Cooking Room", "map_cooking_room" },
        { "Operating Room", "map_operating_room" },
        { "Electrical Room", "map_electrical_room" },
        { "House in the Suburbs", "map_house_in_the_suburbs" },
        { "Road in the Suburbs", "map_road_in_the_suburbs" },
        { "Visitation Corridor", "map_visitation_corridor" },
        { "Ground Behind Infirmary", "map_ground_behind_infirmary" },
        { "Prison Cell Tower", "map_prison_cell_tower" },
        { "Drain Depths", "map_drain_depths" },
        { "TV Building", "map_tv_building" },
        { "Hospital Ward", "map_hospital_ward" },
        { "City Cemetery", "map_city_cemetery" },
        { "Apartment Block", "map_apartment_block" },
        { "Border Checkpoints", "map_border_checkpoints" },
        { "Fighter's Room", "map_fighters_room" },
        { "VIP Box", "map_vip_box" },
        { "Boxing Ring", "map_boxing_ring" },
        { "Casino Alley", "map_casino_alley" },
        { "Thomas", "character_thomas" },
        { "Reed", "character_reed" },
        { "Bob", "character_bob" },
    };

    public static string GetCharacterAssetString(CharacterRecord characterRecord)
    {
        return _assetIdentifiers[characterRecord.Name];
    }

    public static string GetMapAssetString(MapRecord mapRecord)
    {
        return _assetIdentifiers[mapRecord.Name];
    }
}