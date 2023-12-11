#load "FileConfigProvider.fs"

open CoreSystem.Configuration

type SecuritySettings = { OpenAPIKey:string }

let apiSettings = { OpenAPIKey = "test-1234567890" }
FileConfigProvider.writeFile<SecuritySettings> apiSettings

let newSettings = FileConfigProvider.readFile<SecuritySettings>
printfn "%A" newSettings

#r "nuget:FSharpPlus"

open FSharpPlus

let show r = printfn "%A" r;;
either show show newSettings
