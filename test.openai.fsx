#r "nuget: FsHttp"

open FsHttp
open FsHttp.Data


http {
    POST "https://regres.in/api/users"
    CacheControl "no-cache"
    body
    jsonSerialize {|
        name = "morpheus"
        job = "leader"
    |}
}
|> Request.send


let data = ""

http {
    POST "https://api.openai.com/v1/chat/completions"
    AuthorizationBearer "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"
    Accept "application/json"
    CacheControl "no-cache"
    body
    ContentType "application/json"
    jsonSerialize data
}