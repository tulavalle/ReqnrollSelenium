namespace ReqnrollSelenium.Pages
{
    public class ProductsPage(IWebDriver driver)
    {
        public IWebElement AppLogo { get { return driver.FindElement(By.ClassName("app_logo")); } }

        public string GetTextPage()
        {
            return AppLogo.Text;
        }
    }
}
