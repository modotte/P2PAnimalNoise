namespace Literarium

open System
open Microsoft.Xna.Framework
open StardewModdingAPI
open StardewModdingAPI.Events
open StardewModdingAPI.Utilities
open StardewValley
open StardewValley.Menus


module Constants =
    [<Literal>]
    let GenericModConfigMenuId = "spacechase0.GenericModConfigMenu"

type ModConfig() =
    member val NoiseButton: SButton = SButton.Q with get, set

type IGenericModConfigMenuAPI =
    abstract member Register: IManifest * Action * Action * bool -> unit

    abstract member AddKeyBind:
        IManifest * Func<SButton> * Action<SButton> * Func<string> * Func<string> * string -> unit

type ModEntry() =
    inherit Mod()
    member val private config: ModConfig option = None with get, set

    member private this.SetupConfig(e: GameLaunchedEventArgs) =
        let configMenu =
            this.Helper.ModRegistry.GetApi<IGenericModConfigMenuAPI>(Constants.GenericModConfigMenuId)

        if configMenu.GetType() |> isNull then
            ()

        configMenu.Register(
            this.ModManifest,
            (fun () -> this.config <- Some(new ModConfig())),
            (fun () -> this.Helper.WriteConfig(this.config.Value)),
            false
        )

        configMenu.AddKeyBind(
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
