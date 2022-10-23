# SVFSharpExampleMod

Crazy weather mod

A Stardew Valley starter mod template for F# project instead of C#.
Example was translated from [here](https://stardewvalleywiki.com/Modding:Modder_Guide/Get_Started). 

## Development Requirements

- Stardew Valley v1.5+ installed (only tested on v1.5.6)
- SMAPI v3+ installed (only tested on v3.17.2)
- .NET Core 5.0 or 6.0

### Instructions

- git clone https://github.com/modotte/SVFSharpExampleMod into a folder.
- Change ***GamePath*** property inside of **SVFSharpExampleMod.fsproj** file to reflect your Stardew Valley installation folder.
- Run `dotnet build --configuration Release`. Remember, ***DO NOT*** omit/skip `--configuration Release` option when building for test run.


### See Also

- [dnMerge](https://github.com/CCob/dnMerge) - MSBuild plugin that enables assemblies to be merged (which what makes this F# template mod possible to be loaded by SMAPI). 
- [SMAPI configuration info](https://github.com/Pathoschild/SMAPI/blob/develop/docs/technical/mod-package.md#custom-game-path)
