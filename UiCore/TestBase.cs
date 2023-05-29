using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.Pages;

namespace SeleniumAutomation.UiCore;

public class TestBase
{
    internal static IWebDriver Driver;
    private const string DriverPath = @"..\SeleniumAutomation";
    private const string DevByUrl = "https://devby.io";

    public MainPage MainPage = new();
    public VacanciesPage VacanciesPage = new();

    [TestInitialize]
    public void TestInitialize()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--incognito");
        Driver = new ChromeDriver(DriverPath, options);
    }

    public void NavigateToDevBy()
    {
        Driver.Navigate().GoToUrl(DevByUrl);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        Driver.Close();
        Driver.Quit();
    }
}