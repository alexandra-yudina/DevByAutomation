using OpenQA.Selenium;
using SeleniumAutomation.UiCore;

namespace SeleniumAutomation.Pages;

public class VacanciesPage
{
    private static Element VacanciesCounter => new(By.XPath("//div[contains(@class, 'count-text')]"));
    private static Elements VacanciesItems => new(By.XPath("//div[contains(@class,'vacancies-list-item--open')]"));

    private const string VacanciesItemsBy = "//div[@class='collections__list']//a";
    private const string VacanciesItemsCountersBy = VacanciesItemsBy + "//span";

    public string GetVacanciesCount()
    {
        var countText = VacanciesCounter.Text.Split(" ")[0];
        return countText;
    }

    public string GetVacanciesItemsCount()
    {
        return VacanciesItems.Count.ToString();
    }

    public Dictionary<string, int> GetVacanciesTitlesAndCounts()
    {
        var items = new Elements(By.XPath(VacanciesItemsBy));
        var counters = new Elements(By.XPath(VacanciesItemsCountersBy));

        var infoDict = new Dictionary<string, int>();

        for (var i = 0; i < items.Count; i++)
        {
            var title = items.GetText(i);
            var count = int.Parse(counters.GetText(i));

            infoDict.Add(title, count);
        }

        var sortedDict = infoDict.OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        return sortedDict;
    }
}