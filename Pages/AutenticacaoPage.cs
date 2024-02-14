using OpenQA.Selenium;

namespace ReqnrollSelenium.Pages
{
    public class AutenticacaoPage(IWebDriver driver)
    {
        public IWebElement Username { get { return driver.FindElement(By.CssSelector("[data-test='username']")); } }
        public IWebElement Password { get { return driver.FindElement(By.CssSelector("[data-test='password']")); } }
        public IWebElement LoginButton { get { return driver.FindElement(By.CssSelector("[data-test='login-button']")); } }

        public void SetValuesAutenticationAndClickLoginButton(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
            ClickLoginButton();
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        private void SetUsername(string value)
        {
            Username.SendKeys(value);
        }
        private void SetPassword(string value)
        {
            Password.SendKeys(value);
        }
    }
}
