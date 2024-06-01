namespace BTTDRichDiscordPresence.Data;

using System.Collections.Generic;

public static class Assets
{

    private static Dictionary<int, string> _mapAssetIdentifiers { get; } = new()
    {
        { -1, "main_menu" },
        { 1, "map_recreation_yard" },
        { 2, "map_main_building" },
        { 3, "map_main_building" },
        { 4, "map_cell_block_a" },
        { 5, "map_cell_block_a" },
        { 6, "map_cell_block_b" },
        { 7, "map_cell_block_b" },
        { 8, "map_cell_a207" },
        { 9, "map_cell_a103" },
        { 10, "map_bathroom" },
        { 11, "map_boxing_ring" },
        { 12, "map_general_building" },
        { 13, "map_barbershop" },
        { 14, "map_chapel" },
        { 15, "map_cafeteria" },
        { 16, "map_hiding_place" },
        { 17, "map_infirmary" },
        { 18, "map_segregation" },
        { 19, "map_laundry_room" },
        { 20, "map_sewage_treatment_room" },
        { 21, "map_kitchen" },
        { 22, "map_guards_room" },
        { 23, "map_roof_site" },
        { 24, "map_wardens_office" },
        { 25, "map_visit_room" },
        { 26, "map_conjugal_visit_room" },
        { 27, "map_court" },
        { 28, "map_pipe_area" },
        { 29, "map_central_garden" },
        { 30, "map_sewage_pipe" },
        { 31, "map_sewer" },
        { 32, "map_mixing_room" },
        { 33, "map_mailroom" },
        { 34, "map_visit_room" },
        { 35, "map_apartment_block" },
        { 36, "map_college_dorm" },
        { 37, "map_main_building" },
        { 38, "map_inmate_property_storeroom" },
        { 39, "map_back_room_club" },
        { 50, "map_rooftop_tool_shed" },
        { 51, "map_fallen_angels" },
        { 52, "map_bathroom" },
        { 53, "map_private_room" },
        { 54, "map_backstage_corridor" },
        { 55, "map_dressing_room" },
        { 56, "map_inner_hall" },
        { 57, "map_chaplains_lounge" },
        { 58, "map_kitchen_cellar" },
        { 59, "map_cooking_room" },
        { 60, "map_operating_room" },
        { 61, "map_electrical_room" },
        { 62, "map_house_in_the_suburbs" },
        { 63, "map_road_in_the_suburbs" },
        { 64, "map_visitation_corridor" },
        { 65, "map_ground_behind_infirmary" },
        { 66, "map_prison_cell_tower" },
        { 67, "map_drain_depths" },
        { 68, "map_tv_building" },
        { 69, "map_hospital_ward" },
        { 70, "map_city_cemetery" },
        { 71, "map_apartment_block" },
        { 72, "map_border_checkpoints" },
        { 79, "map_fighters_room" },
        { 80, "map_vip_box" },
        { 81, "map_boxing_ring" },
        { 82, "map_casino_alley" },
    };

    private static Dictionary<int, string> _characterAssetIdentifiers { get; } = new()
    {
        // Characters
        { 1, "character_thomas" },
        { 11017, "character_reed" },
        { 11026, "character_reed"},
        { 25, "character_bob" },
    };

    public static string GetCharacterAssetString(CharacterRecord characterRecord)
    {
        if (characterRecord is null) return string.Empty;
        return _characterAssetIdentifiers[characterRecord.Id];
    }

    public static string GetMapAssetString(MapRecord mapRecord)
    {
        return _mapAssetIdentifiers[mapRecord.Id];
    }
}