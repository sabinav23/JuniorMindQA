Feature: PlanItPokerApi
	Simple api request tests for login feature

	@mytag
Scenario: Email and password are correct 
	Given the first input is "mailnou273@gmail.com"
	And the second input is "planit273"
	When making a post request 
	Then the status code should be "OK"

	@mytag
Scenario: Email is invalid
	Given the first input is "mailnou27@gmail.com"
	And the second input is "planit273"
	When making a post request 
	Then the status code should be "Bad Request"
	And the message should be "Invalid email adress."

	@mytag
Scenario: Password is invalid
	Given the first input is "mailnou273@gmail.com"
	And the second input is "planit27"
	When making a post request 
	Then the status code should be "Bad Request"
	And the message should be "You have provided invalid credentials."

	@mytag
Scenario: Email is missing
	Given the first input is ""
	And the second input is "planit273"
	When making a post request 
	Then the status code should be "Internal Server Error"
	And the message should be "An error has occurred."

	@mytag
Scenario: Password is missing
	Given the first input is "mailnou273@gmail.com"
	And the second input is ""
	When making a post request 
	Then the status code should be "Internal Server Error"
	And the message should be "An error has occurred."

	@mytag
Scenario: Email and password are both invalid
	Given the first input is "mailnou27@gmail.com"
	And the second input is "planit27"
	When making a post request 
	Then the status code should be "Bad Request"
	And the message should be "You have provided invalid credentials."

	@mytag
Scenario: Email has special characters
	Given the first input is "mailno!u27@gmail.com"
	And the second input is "planit273"
	When making a post request 
	Then the status code should be "Bad Request"
	And the message should be "You have provided invalid credentials."

	@mytag
Scenario: Password has special characters
	Given the first input is "mailnou273@gmail.com"
	And the second input is "pla!nit273"
	When making a post request 
	Then the status code should be "Bad Request"
	And the message should be "You have provided invalid credentials."

	@mytag
Scenario: When email and password are empty
	Given the first input is ""
	And the second input is ""
	When making a post request 
	Then the status code should be "Internal Server Error"
	And the message should be "An error has occurred."

	@mytag
Scenario: When email in long
	Given the first input is "fredbvdfsnvlsdnvjsalbnvjuhdsfabvhlsabvshdabvsdbvsdbvsbvslbvsjhbvbvbvbvbvbvbvbvhdsbvcasbvcaslbvashblvasjbvlajsvbdjhsbvsabvhjsbvcbnhjsdbvcsdhjbvcjhdsbvsabvcsajnvsdjnvshdbvsfhdljvbdsrfvjlbdsavlfdsnvfesurbvsdarugvbrasdlhfurhfrughvbrugvedvhnreuljhve"
	And the second input is "planit273"
	When making a post request 
	Then the status code should be "Bad Request"
	And the message should be "You have provided invalid credentials."

		@mytag
Scenario: When all room data is valid 
	Given the name is "Camera Test"
	And the cardSetType is 1
	And the haveStories is true
	And the confirmSkip is true
	And the showVotingToObservers is false
	And the autoReveal is false
	And the changeVote is true
	And the countdownTimer is false
	And the countdownTimerValue is 30
	When making a post request
	Then the status code should be "OK"