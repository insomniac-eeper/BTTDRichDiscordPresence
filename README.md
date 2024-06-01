# Rich Discord Presence for Back to the Dawn

## Description
A [BepInEx](https://github.com/BepInEx/BepInEx) plugin that adds rich discord presence support for the game [Back to the Dawn](https://store.steampowered.com/app/1735700/Back_to_the_Dawn/).

## Features
![Starting Game Presence](./image%20assets/Readme/StartDRP.png)

### Game location

At the time of writing I have not added any other location images so unfortunately it will only show the main menu as the large image.

**Please refer to [Asset Status](#asset-status) for the latest state of available images.**

![Showing In-Game Location](./image%20assets/Readme/LocationDRP.png)

### Playing as

#### Playing as Thomas
![Showing playing as character](./image%20assets/Readme/LocationDRP.png)

#### Playing as Bob
![Showing playing as different character 1](./image%20assets/Readme/PlayingAsDRP1.png)

#### Playing as Reed
![Showing playing as different character 2](./image%20assets/Readme/PlayingAsDRP2.png)

### Save DateTime
![Showing in-game time](./image%20assets/Readme/LocationDRP.png)

### Battle Detection
![Showing battle](./image%20assets/Readme/BattleDRP.png)

## Important Remarks

The integration makes use of a Discord application in order to refer to assest (as opposed to using links).
This means that any asset must be uploaded to the appropriate Discord app and the associations references explicitly defined in the mod must be maintained.

Refer to the [Asset Status](#asset-status) section to see the current state of images.

## Installation

This is a Bepinex plugin which can be installed by being placed in the <BTTDGameDir>/BepInEx/plugins directory after running the game with BepInEx installed. 
Please refer to [Installing BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html) for this.


## Usage

Make sure that Discord is running as well. The connect/reconnect resiliency and logic isn't phenomenal so it helps to have Discord running for the entirety of this.

### Windows
Things should work out of the box.

### Linux
Your mileage may vary, it appears that the native Discord client works just fine (provided you define a RPC bridge, if needed). If you are using a solution that relies on [arrpc](https://arrpc.openasar.dev/) you may find that the game process detectables trumps this mod (refer to [detectables.json](https://github.com/OpenAsar/arrpc/blob/main/src/process/detectable.json)).

## Getting things to build

- Modify GameDir in Common.props to point to your game install location
  - I should move this to csproj.user at some point...
- Download [v2.5.6 of the discord GameSDK](https://discord.com/developers/docs/game-sdk/getting-started).
  - Place the csharp library files into external/discordsdk/csharp
  - Place the contents of lib/x86_64 into external/discordsdk/native

- Note that project build will try to copy plugin DLL to the BepInEx plugin directory **but will not copy discord sdk native dll**. This needs to be done manually until an extra build task is added.

## Planned Features
- [ ] Minigame detection
- [ ] More detailed battle information
- [ ] Gang association informations

## Asset Status

| Identifier | Type | Status | Image |
|------------|------|--------|-------|
|main_menu| MapAsset | ✔️ | !["Main Menu"](./image%20assets/Discord%20App%20Assets/main_menu.png) |
|map_recreation_yard| MapAsset | ❌ | |
|map_main_building| MapAsset | ❌ | |
|map_main_building| MapAsset | ❌ | |
|map_cell_block_a| MapAsset | ❌ | |
|map_cell_block_a| MapAsset | ❌ | |
|map_cell_block_b| MapAsset | ❌ | |
|map_cell_block_b| MapAsset | ❌ | |
|map_cell_a207| MapAsset | ❌ | |
|map_cell_a103| MapAsset | ❌ | |
|map_bathroom| MapAsset | ❌ | |
|map_boxing_ring| MapAsset | ❌ | |
|map_general_building| MapAsset | ❌ | |
|map_barbershop| MapAsset | ❌ | |
|map_chapel| MapAsset | ❌ | |
|map_cafeteria| MapAsset | ❌ | |
|map_hiding_place| MapAsset | ❌ | |
|map_infirmary| MapAsset | ❌ | |
|map_segregation| MapAsset | ❌ | |
|map_laundry_room| MapAsset | ❌ | |
|map_sewage_treatment_room| MapAsset | ❌ | |
|map_kitchen| MapAsset | ❌ | |
|map_guards_room| MapAsset | ❌ | |
|map_roof_site| MapAsset | ❌ | |
|map_wardens_office| MapAsset | ❌ | |
|map_visit_room| MapAsset | ❌ | |
|map_conjugal_visit_room| MapAsset | ❌ | |
|map_court| MapAsset | ❌ | |
|map_pipe_area| MapAsset | ❌ | |
|map_central_garden| MapAsset | ❌ | |
|map_sewage_pipe| MapAsset | ❌ | |
|map_sewer| MapAsset | ❌ | |
|map_mixing_room| MapAsset | ❌ | |
|map_mailroom| MapAsset | ❌ | |
|map_visit_room| MapAsset | ❌ | |
|map_apartment_block| MapAsset | ❌ | |
|map_college_dorm| MapAsset | ❌ | |
|map_main_building| MapAsset | ❌ | |
|map_inmate_property_storeroom| MapAsset | ❌ | |
|map_back_room_club| MapAsset | ❌ | |
|map_rooftop_tool_shed| MapAsset | ❌ | |
|map_fallen_angels| MapAsset | ❌ | |
|map_bathroom| MapAsset | ❌ | |
|map_private_room| MapAsset | ❌ | |
|map_backstage_corridor| MapAsset | ❌ | |
|map_dressing_room| MapAsset | ❌ | |
|map_inner_hall| MapAsset | ❌ | |
|map_chaplains_lounge| MapAsset | ❌ | |
|map_kitchen_cellar| MapAsset | ❌ | |
|map_cooking_room| MapAsset | ❌ | |
|map_operating_room| MapAsset | ❌ | |
|map_electrical_room| MapAsset | ❌ | |
|map_house_in_the_suburbs| MapAsset | ❌ | |
|map_road_in_the_suburbs| MapAsset | ❌ | |
|map_visitation_corridor| MapAsset | ❌ | |
|map_ground_behind_infirmary| MapAsset | ❌ | |
|map_prison_cell_tower| MapAsset | ❌ | |
|map_drain_depths| MapAsset | ❌ | |
|map_tv_building| MapAsset | ❌ | |
|map_hospital_ward| MapAsset | ❌ | |
|map_city_cemetery| MapAsset | ❌ | |
|map_apartment_block| MapAsset | ❌ | |
|map_border_checkpoints| MapAsset | ❌ | |
|map_fighters_room| MapAsset | ❌ | |
|map_vip_box| MapAsset | ❌ | |
|map_boxing_ring| MapAsset | ❌ | |
|map_casino_alley| MapAsset | ❌ | |
|character_thomas| CharacterAsset | ✔️ | !["Thomas"](./image%20assets/Discord%20App%20Assets/character_thomas.png) |
|character_reed| CharacterAsset | ✔️ | !["Reed"](./image%20assets/Discord%20App%20Assets/character_reed.png) |
|character_bob| CharacterAsset | ✔️ | !["Bob"](./image%20assets/Discord%20App%20Assets/character_bob.png)|