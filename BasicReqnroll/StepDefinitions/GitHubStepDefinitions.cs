namespace BasicReqnroll.StepDefinitions
{
    using OpenQA.Selenium;
    using System;

    [Binding]
    public sealed class GitHubStepDefinitions
    {
        // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef

        private readonly IWebDriver webDriver;

        private const string WebURL = "https://github.com";
        private const string EmailId = "hero_user_email";
        private const string SignUpParentElementId = "FormControl--:Rjahb:";
        private const string SignUpButtonClassName = "Primer_Brand__Button-module__Button___lDruK";
        private const string SignUpLabelClassName = "signups-rebrand__container-h1";
        private const string SignUpLabelUIText = "Create your free account";

        public GitHubStepDefinitions(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        [Given("I can browse to GitHub home page")]
        public void GivenICanBrowseToGitHubHomePage()
        {
            this.webDriver.Navigate().GoToUrl(WebURL);
        }

        [When("I enter my email address {string}")]
        public void WhenIEnterMyEmailAddress(string emailAddress)
        {
            var foundElement = this.webDriver.FindElement(By.Id(EmailId));
            foundElement.SendKeys(emailAddress);
        }

        [When("I click the Sign Up Button")]
        public void WhenIClickTheSignUpButton()
        {
            var foundElement = this.webDriver.FindElement(By.Id(SignUpParentElementId));
            var buttonSignUp = foundElement.FindElement(By.ClassName(SignUpButtonClassName));
            buttonSignUp.Click();
        }

        [Then("The Sign Up page is displayed")]
        public void ThenTheSignUpPageIsDisplayed()
        {
            var foundElement = this.webDriver.FindElement(By.ClassName(SignUpLabelClassName));
            Assert.AreEqual(foundElement.Text, SignUpLabelUIText);
        }

        [Then("This test will fail")]
        public void ThenThisTestWillFail()
        {
            var foundElement = this.webDriver.FindElement(By.ClassName("ThisClassDoesntExists"));
        }

    }
}
