namespace Api.Unit.Test.Controllers

open Microsoft.Extensions.Logging
open Moq

type ControllerTest<'T> (logger: Mock<ILogger<'T>>) =
    member this.Logger = logger
    new() = ControllerTest(Mock<ILogger<'T>>())
