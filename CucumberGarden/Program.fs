module CucumberGarden.Main

open System
open Nancy.Bootstrappers.Windsor
open Nancy
open Nancy.Hosting.Self

type Bootstrapper() =
    inherit WindsorNancyBootstrapper()
    
    override this.ConfigureApplicationContainer container =
        container.AddFacility<Castle.Facilities.TypedFactory.TypedFactoryFacility>()
        |> ignore
    

type GardenModule() as self = 
    inherit NancyModule()
    do
      self.Get.["/"] <- fun _ -> "Hello" :> obj

[<EntryPoint>]
let main args = 
    let nancyHost = new NancyHost(new Uri("http://localhost:8888/nancy/"), new Uri("http://127.0.0.1:8888/nancy/"))
    nancyHost.Start()
    printfn "ready..."
    Console.ReadKey() |> ignore
    nancyHost.Stop()
    0
