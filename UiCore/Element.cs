using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomation.UiCore;

public class Element
{
    private readonly IWebDriver _driver;
    private readonly By _locator;
    private readonly WebDriverWait _wait;

    public Element(By locator)
    {
        _driver = TestBase.Driver;
        _locator = locator;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    private IWebElement WaitTillClickable()
    {
        return _wait.Until(ExpectedConditions.ElementToBeClickable(_locator));
    }

    private IWebElement WaitTillDisplayed()
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(_locator));
    }

    private IWebElement WaitTillExist()
    {
        return _wait.Until(ExpectedConditions.ElementExists(_locator));
    }

    public bool Displayed => WaitTillDisplayed().Displayed;

    public string Text => WaitTillExist().Text;

    public void Click()
    {
        WaitTillClickable().Click();
    }
}