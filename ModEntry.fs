namespace Literarium

open System
open Microsoft.Xna.Framework
open StardewModdingAPI
open StardewModdingAPI.Events
open StardewModdingAPI.Utilities
open StardewValley

type public ModEntry() =
    inherit Mod()

    override this.Entry(helper: IModHelper) =
        helper.Events.Input.ButtonPressed.Add(fun (e) -> this.OnButtonPressed(e))

    member private this.OnButtonPressed(e: ButtonPressedEventArgs) =
        if not Context.IsWorldReady then
            ()
        else
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}", LogLevel.Debug)
