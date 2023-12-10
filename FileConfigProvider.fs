namespace CoreSystem.Configuration

open System
open System.IO
open System.Text.Json

module FileConfigProvider = 

    let configPath = @".\.security"

    let writeFile<'T> (settings:'T) = 
        let options = JsonSerializerOptions(WriteIndented = true)
        let keyJSON = JsonSerializer.Serialize(settings, options)
        File.WriteAllText(configPath, keyJSON)

    let readFile<'T> : Result<'T, string> = 
        try
            let json = File.ReadAllText(configPath)
            Ok (JsonSerializer.Deserialize<'T>(json))
        with
        | :? JsonException -> Error "JSONException"
        | :? IOException -> Error "IOException" 