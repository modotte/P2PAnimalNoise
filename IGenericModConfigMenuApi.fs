namespace GenericModConfigMenu

open System
open StardewModdingAPI

type IGenericModConfigMenuApi =
    abstract member Register: IManifest * Action * Action * bool -> unit

    abstract member AddKeybind:
        IManifest * Func<SButton> * Action<SButton> * Func<string> * Func<string> * string -> unit
