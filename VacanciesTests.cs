using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomation.UiCore;

namespace SeleniumAutomation;

[TestClass]
public class VacanciesTests : TestBase
{
    [TestMethod]
    public void VacanciesListedOnMainPage_MatchesWithVacanciesPage()
    {
        NavigateToDevBy();

        // Get All Vacancies and Counts
        var vacanciesFromManePage = MainPage.GetVacanciesTitlesAndCounts();

        // Navigate To Vacancies Page
        MainPage.ClickVacanciesLink();

        // Verify Vacancies Counter Value matches Vacancies listed on the Page
        Assert.AreEqual(VacanciesPage.GetVacanciesCount(), VacanciesPage.GetVacanciesItemsCount());

        // Verify Vacancies from Main Page matches Vacancies from Vacancies Page
        var vacanciesFromVacanciesPage = VacanciesPage.GetVacanciesTitlesAndCounts();

        Assert.AreEqual(vacanciesFromManePage, vacanciesFromVacanciesPage); // Test Fails because 1 item is not listed on Vacancies Page
    }
}