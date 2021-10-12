namespace Api.Unit.Test.Controllers

open System.Threading
open FsUnit
open FSharp.Control.Tasks.V2
open Microsoft.AspNetCore.Mvc
open NUnit.Framework
open Tilia.Web.Controllers.Shared
open Tilia.Web.Controllers.SignUp
open Api.Unit.Test.Mocks.SignUpMediatorMock
open Api.Unit.Test.Stubs.Stubs

[<TestFixture>]
type SignUpControllerTest() =
    inherit ControllerTest<SignUpController>()
    let mutable response : ActionResult = null

    member private this.mediator = Mediator()

    member private this.controller =
        SignUpController(this.mediator, this.Logger.Object)

    [<Test; Order(0)>]
    member this.RegisterNonExistingUser_ShouldReturnCreatedStatus() =
        task {
            let! r = this.controller.SignUp(signUpRequestStub, CancellationToken.None)
            response <- r
            HaveBeenCalledMock()
            response |> should be ofExactType<CreatedResult>
        }

    [<Test; Order(3)>]
    member this.RegisterNonExistingUser_ShouldReturnTheToken() =
        response |> should not' (equal null)
        let okResponse = response :?> CreatedResult

        let authResponse =
            okResponse.Value :?> AuthenticationResponse

        authResponse.Token |> should be (sameAs tokenStub)
