namespace Api.Unit.Test.Stubs

open Tilia.Web.Controllers.SignUp

module Stubs =

    let tokenStub = "test_token"

    let signUpRequestStub =
        SignUpRequest("test", "test@example.com", "testPassword")
