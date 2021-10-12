Feature: Signup
In order to have access to the api features
As an unregistered person
I want to register as new user in the server

  Scenario: A valid unregistered user
    Given an empty database
    And I send a POST request to "/api/auth/signUp" with body:
    """
    {
      "username": "Bob",
      "email": "bob@bobmail.bob",
      "password": "passbob"
    }
    """
    Then the response status code should be 201

  Scenario: A invalid user request with no email
    Given I send a POST request to "/api/auth/signUp" with body:
    """
    {
      "username": "Bob",
      "password": "passbob"
    }
    """
    Then the response status code should be 400

  Scenario: A repeated email user
    Given an empty database
    And the following user already exists:
    """
    {
      "name": "Bob",
      "email": "bob@bobmail.bob",
      "password": "passbob"
    }
    """
    When I send a POST request to "/api/auth/signUp" with body:
    """
    {
      "username": "Bob",
      "email": "bob@bobmail.bob",
      "password": "passbob"
    }
    """
    Then the response status code should be 400
