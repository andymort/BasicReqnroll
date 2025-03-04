Feature: GitHub

Simple calculator for adding two numbers

@mytag
Scenario: Sign Up on GitHub
	Given I can browse to GitHub home page
	When I enter my email address "a@b.com"
	And I click the Sign Up Button
	Then The Sign Up page is displayed