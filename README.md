# Rich Discord Presence for Back to the Dawn

## Installation

This is a Bepinex plugin which can be installed by being placed in the <BTTDGameDir>/BepInEx/plugins directory after running the game with BepInEx installed. 
Please refer to [Installing BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html) for this.


## Usage

Make sure that Discord is running as well. The connect/reconnect resiliency and logic isn't phenomenal so it helps to have Discord running for the entirety of this.

### Windows
Things should work out of the box.

### Linux

## Getting things to build

- Modify GameDir in Common.props to point to your game install location
  - I should move this to csproj.user at some point...
- Download [v2.5.6 of the discord GameSDK](https://discord.com/developers/docs/game-sdk/getting-started).
  - Place the csharp library files into external/discordsdk/csharp
  - Place the contents of lib/x86_64 into external/discordsdk/native