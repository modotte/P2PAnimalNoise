namespace Literarium

open StardewModdingAPI
open StardewModdingAPI.Events
open StardewValley
open GenericModConfigMenu
open FSharp.Collections


module Constant =
    [<Literal>]
    let GenericModConfigMenuId = "spacechase0.GenericModConfigMenu"

module Noise =
    let Animals = Map [ ("Quack", "Duck"); ("Meow", "cat"); ("Moo", "cow") ]

type ModConfig() =
    member val NoiseButton: SButton = SButton.Q with get, set
    member val NoiseKind: string = "Quack" with get, set

type ModEntry() =
    inherit Mod()
    member val private config: ModConfig option = None with get, set

    member private this.SetupConfig(e: GameLaunchedEventArgs) =
        let configMenu =
            this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>(Constant.GenericModConfigMenuId)

        if configMenu.GetType() |> isNull then
            ()

        configMenu.Register(
            this.ModManifest,
            (fun () -> this.config <- Some(new ModConfig())),
            (fun () -> this.Helper.WriteConfig(this.config.Value)),
            false
        )

        configMenu.AddKeybind(
            this.ModManifest,
            (fun () -> this.config.Value.NoiseButton),
            (fun x -> this.config.Value.NoiseButton <- x),
            (fun () -> "Noise keybind"),
            (fun () -> ""),
            ""
        )

        configMenu.AddTextOption(
            this.ModManifest,
            (fun () -> this.config.Value.NoiseKind),
            (fun x -> this.config.Value.NoiseKind <- x),
            (fun () -> "Noise kind"),
            (fun () -> ""),
            Noise.Animals |> Map.keys |> Seq.toArray,
            null,
            ""
        )

    override this.Entry(helper: IModHelper) =
        this.config <- this.Helper.ReadConfig<ModConfig>() |> Some
        helper.Events.GameLoop.GameLaunched.Add(fun e -> this.SetupConfig(e))

        helper.Events.Input.ButtonPressed.Add(fun e ->
            if Context.IsPlayerFree then
                if e.Button = this.config.Value.NoiseButton then
                    Game1.currentLocation.playSound (Noise.Animals |> Map.find this.config.Value.NoiseKind))
