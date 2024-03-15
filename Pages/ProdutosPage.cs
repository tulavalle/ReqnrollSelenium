namespace ReqnrollSelenium.Pages
{
    public class ProdutosPage(IWebDriver driver)
    {
        public IWebElement AppLogo { get { return driver.FindElement(By.ClassName("app_logo")); } }

        public string GetTextPage()
        {
            return AppLogo.Text;
        }
    }
}
