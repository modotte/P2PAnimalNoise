namespace Literarium

open System
open Microsoft.Xna.Framework
open StardewModdingAPI
open StardewModdingAPI.Events
open StardewModdingAPI.Utilities
open StardewValley
open StardewValley.Menus

type ModConfig() =
    member val NoiseButton: SButton = SButton.Q with get, set

type ModEntry() =
    inherit Mod()
    member val private config: ModConfig option = None with get, set

    override this.Entry(helper: IModHelper) =
        this.config <- this.Helper.ReadConfig<ModConfig>() |> Some
        helper.Events.GameLoop.GameLaunched.Add(fun e -> this.OnGameLaunched(e))

    member private this.OnGameLaunched(e: GameLaunchedEventArgs) =
        this.Monitor.Log("Mod loaded", LogLevel.Debug)
