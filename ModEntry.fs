namespace P2PAnimalNoise

open StardewModdingAPI
open StardewValley
open GenericModConfigMenu
open FSharp.Collections


[<RequireQualifiedAccess>]
module Constant =
    [<Literal>]
    let GenericModConfigMenuId = "spacechase0.GenericModConfigMenu"

    let Noise = "Duck's quack"

type ModConfig() =
    member val NoiseButton: SButton = SButton.Q with get, set
    member val Noise: string = Constant.Noise with get, set

module Noise =
    let Animals =
        Map
            [ ("Duck's quack", "Duck")
              ("Cat's meow", "cat")
              ("Cow's moo", "cow")
              ("Cricket's chirp", "crickets")
              ("Crow's caw", "crow")
              ("Dog's bark", "dog_bark")
              ("Dog's whine", "dogWhining")
              ("Dog's pant", "dog_pant")
              ("Fly's buzz", "flybuzzing")
              ("Goat's maah", "goat")
              ("Monkey's chatter", "monkey1")
              ("Owl's hoot", "owl")
              ("Dog's howl", "dogs")
              ("Sheep's maah", "sheep")
              ("Seagull's caw", "seagulls")
              ("Rooster's cuckoo", "rooster")
              ("Pig's oink", "pig")
              ("Parrot's squawk", "parrot_squawk")
              ("Ostrich's boom", "Ostrich") ]

type ModEntry() =
    inherit Mod()
    member val private config: ModConfig option = None with get, set

    member private this.SetupConfig _ =
        let configMenu =
            this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>(Constant.GenericModConfigMenuId)

        if configMenu.GetType() |> isNull then
            ()
        else
            configMenu.Register(
                this.ModManifest,
                (fun () -> this.config <- Some(ModConfig())),
                (fun () -> this.Helper.WriteConfig(this.config.Value)),
                false
            )

            configMenu.AddKeybind(
                this.ModManifest,
                (fun () -> this.config.Value.NoiseButton),
                (fun x -> this.config.Value.NoiseButton <- x),
                (fun () -> "Noise keybind"),
                (fun () -> "Bind a key button to play the sound in-game."),
                ""
            )

            configMenu.AddTextOption(
                this.ModManifest,
                (fun () -> this.config.Value.Noise),
                (fun x -> this.config.Value.Noise <- x),
                (fun () -> "Noise"),
                (fun () -> "Various (default) animal noises. Scroll down the list to see more options."),
                Noise.Animals |> Map.keys |> Seq.toArray,
                null,
                ""
            )

    override this.Entry(helper: IModHelper) =
        this.config <- this.Helper.ReadConfig<ModConfig>() |> Some
        helper.Events.GameLoop.GameLaunched.Add(this.SetupConfig)
        helper.Events.Input.ButtonPressed.Add(fun e ->
            if Context.IsPlayerFree then
                if e.Button = this.config.Value.NoiseButton then
                    Game1.currentLocation.playSound (Noise.Animals |> Map.find this.config.Value.Noise))
