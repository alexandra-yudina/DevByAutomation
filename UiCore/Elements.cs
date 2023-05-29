using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomation.UiCore;

public class Elements
{
    private readonly IWebDriver _driver;
    private readonly By _locator;
    private readonly WebDriverWait _wait;

    public Elements(By locator)
    {
        _driver = TestBase.Driver;
        _locator = locator;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    public IList<IWebElement> WaitForElements()
    {
        return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_locator));
    }
    public int Count
    {
        get
        {
            var elements = WaitForElements();
            return elements.Count;
        }
    }

    public IList<IWebElement> CurrentElements => WaitForElements();

    public string GetText(int index)
    {
        var elements = CurrentElements;
        if (index >= 0 && index < elements.Count)
        {
            return elements[index].Text;
        }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public string GetAttributeValue(int index)
    {
        var elements = CurrentElements;
        if (index >= 0 && index < elements.Count)
        {
            return elements[index].GetAttribute("data-label");
        }
        throw new ArgumentOutOfRangeException(nameof(index));
    }
}