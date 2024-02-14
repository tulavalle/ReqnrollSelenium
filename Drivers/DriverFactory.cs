using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ReqnrollSelenium.Drivers;
public class DriverFactory
{
    public static IConfigurationRoot? Configuration { get; set; }

    protected DriverFactory() { }

    public static IWebDriver GetDriver()
    {
        var directoryDefaultProject = Environment.CurrentDirectory;
        Configuration = GetAppSettingsConfig.Configuration;
        GetAppSettingsConfig.Initialize(directoryDefaultProject);

        string? browser = Configuration != null
            ? Configuration["driverSettings:browser"]
            : throw new Exception("Não foi possível ler o appsettings. Verifique.");

        if (browser != null)
        {
            return browser.ToUpper() switch
            {
                "CHROME" => new ChromeDriver(),
                "EDGE" => new EdgeDriver(),
                "FIREFOX" => new FirefoxDriver(),
                _ => throw new Exception($"O browser '{browser}' não está implementado. Verifique."),
            };
        }

        throw new Exception("O valor do browser é nulo. Verifique suas configurações.");
    }
}

