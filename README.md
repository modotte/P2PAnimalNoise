# P2PAnimalNoise (Stardew Valley SMAPI mod)

Press a button to play an animal noise of your choice while playing (more than 10 type).

This mod was directly inspired & adapted from [PressToQuack](https://github.com/DraconisLeonidas/PressToQuack) but my other motivation was also to see how could I use F# to develop a more than simple
"hello world" demo mod.

> Note: I do not host this mod anywhere else but here.

## Download

https://github.com/modotte/P2PAnimalNoise/releases

## Development Requirements

- Stardew Valley v1.5+ installed (only tested on v1.5.6)
- SMAPI v3+ installed (only tested on v3.17.2)
- .NET Core 5.0 or 6.0

### Instructions

- git clone https://github.com/modotte/SVAnimalNoise into a folder.
- Change ***GamePath*** property inside of **P2PAnimalNoise.fsproj** file to reflect your Stardew Valley installation folder.
- Run `dotnet build --configuration Release`. Remember, ***DO NOT*** omit/skip `--configuration Release` option when building for test run.


### See Also

- [dnMerge](https://github.com/CCob/dnMerge) - MSBuild plugin that enables assemblies to be merged (which what makes this F# template mod possible to be loaded by SMAPI). 
- [SMAPI configuration info](https://github.com/Pathoschild/SMAPI/blob/develop/docs/technical/mod-package.md#custom-game-path)
- [Stardew Valley's F# starter template mod](https://github.com/modotte/SVFsharpExampleMod)