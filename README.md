# P2PAnimalNoise (Stardew Valley SMAPI mod)

Press a button to play an animal sound while playing (over 15 different noises).

This mod is inspired by [PressToQuack](https://github.com/DraconisLeonidas/PressToQuack) mod.

## Download

> Note: I do not host this mod anywhere else but here.

https://github.com/modotte/P2PAnimalNoise/releases

## Installation (for users)

See [INSTALL.md](https://github.com/modotte/P2PAnimalNoise/blob/main/INSTALL.md) file.

## Notes

- This mod is untested in multiplayer mode.

## Development Requirements

- Stardew Valley v1.5+ installed (only tested on v1.5.6)
- SMAPI v3+ installed (only tested on v3.17.2)
- .NET Core 5.0 or 6.0

### Instructions

1. `git clone https://github.com/modotte/P2PAnimalNoise` into a folder.
2. Change ***GamePath*** property inside of **P2PAnimalNoise.fsproj** file to 
  reflect your Stardew Valley installation folder path.
3. Run `dotnet build --configuration Release`. Remember, ***DO NOT*** omit/skip 
  `--configuration Release` option when building for test run.


## See Also

- [dnMerge](https://github.com/CCob/dnMerge) - MSBuild plugin that enables assemblies to be merged (which what makes this F# mod possible to be loaded by SMAPI). 
- [SMAPI configuration info](https://github.com/Pathoschild/SMAPI/blob/develop/docs/technical/mod-package.md#custom-game-path)
- [Stardew Valley's F# starter template mod](https://github.com/modotte/SVFsharpExampleMod)
