namespace Literarium

open StardewModdingAPI
open StardewModdingAPI.Events
open StardewValley
open GenericModConfigMenu


module Constants =
    [<Literal>]
    let GenericModConfigMenuId = "spacechase0.GenericModConfigMenu"

type ModConfig() =
    member val NoiseButton: SButton = SButton.Q with get, set

type ModEntry() =
    inherit Mod()
    member val private config: ModConfig option = None with get, set

    member private this.SetupConfig(e: GameLaunchedEventArgs) =
        let configMenu =
            this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>(Constants.GenericModConfigMenuId)

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
            (fun () -> "Noise Button"),
            (fun () -> ""),
            ""
        )

    member this.OnButtonPressed(e: ButtonPressedEventArgs) =
        if Context.IsPlayerFree then
            if e.Button = this.config.Value.NoiseButton then
                Game1.currentLocation.playSound ("Duck")

    override this.Entry(helper: IModHelper) =
        this.config <- this.Helper.ReadConfig<ModConfig>() |> Some
        helper.Events.GameLoop.GameLaunched.Add(fun e -> this.SetupConfig(e))
        helper.Events.Input.ButtonPressed.Add(fun e -> this.OnButtonPressed(e))
