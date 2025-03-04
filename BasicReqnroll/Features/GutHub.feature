Feature: GitHub

Simple tests for testing purposes

@mytag
Scenario: Sign Up on GitHub
	Given I can browse to GitHub home page
	When I enter my email address "a@b.com"
	And I click the Sign Up Button
	Then The Sign Up page is displayed

Scenario: This test will fail
	Given I can browse to GitHub home page
	When I enter my email address "a@b.com"
	And I click the Sign Up Button
	Then This test will fail