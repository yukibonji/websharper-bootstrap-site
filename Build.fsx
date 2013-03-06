#r "packages/FAKE.1.74.127.0/tools/FakeLib.dll"

open Fake

let Root = __SOURCE_DIRECTORY__
let ( +/ ) a b = System.IO.Path.Combine(a, b)

let Projects =
    !+ (Root +/ "*" +/ "*.csproj")
    ++ (Root +/ "*" +/ "*.fsproj")
    |> Scan

Target "Build" <| fun () ->
    tracefn "Building"
    MSBuildRelease "" "Build" Projects
    |> ignore

Target "Clean" <| fun () ->
    tracefn "Cleaning"
    MSBuildRelease "" "Clean" Projects
    |> ignore

RunTargetOrDefault "Build"
