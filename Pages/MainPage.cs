using OpenQA.Selenium;
using SeleniumAutomation.UiCore;

namespace SeleniumAutomation.Pages;

public class MainPage
{
    private static Element VacanciesLink => new(By.CssSelector("a[href='https://jobs.devby.io']"));
    private static Element WishesPopupXButton => new (By.XPath("//button[contains(@class,'wishes-popup')]"));
    private const string VacanciesItemsBy = "//div[@data-gtm-track='vacancies-informer']//li";
    private const string VacanciesItemsTitlesBy = VacanciesItemsBy + "//span";
    private const string VacanciesItemsCountersBy = VacanciesItemsBy + "//a";

    public void ClickVacanciesLink()
    {
        VacanciesLink.Click();
        if(WishesPopupXButton.Displayed)
            WishesPopupXButton.Click();
    }

    public Dictionary<string, int> GetVacanciesTitlesAndCounts()
    {
        var items = new Elements(By.XPath(VacanciesItemsBy));
        var titles = new Elements(By.XPath(VacanciesItemsTitlesBy));
        var counters = new Elements(By.XPath(VacanciesItemsCountersBy));

        var infoDict = new Dictionary<string, int>();

        for (var i = 0; i < items.Count; i++)
        {
            var title = titles.GetText(i);
            var count = int.Parse(counters.GetAttributeValue(i));

            infoDict.Add(title, count);
        }

        var sortedDict = infoDict.OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        return sortedDict;
    }
}