using System.Diagnostics.CodeAnalysis;
using Microsoft.Playwright.MSTest;

namespace PlayWright.Tests;

[TestClass]
public class FirstTest : PageTest
{

    private HomePage _homePage;
    private InformationPage _infoPage;
    private BasePage _basePage;
    private MOHSPage _mohspage;

    [TestInitialize]
    public void Initialize()
    {
        _homePage = new HomePage(Page);
        _infoPage = new InformationPage(Page);
        _mohspage = new MOHSPage(Page);
    }

    [TestMethod]
    //Happy case
    public async Task FillInfo()
    {
        await Page.GotoAsync(ConfigReader.GetBaseUrl());
        await _homePage.OnlineHighSchoolLink.ClickAsync();
        await _mohspage.ApplySchoolButton.ClickAsync();
        await Page.Locator("//button[@elname=\"next\"]").First.ClickAsync();
        await _infoPage.FillInfo("minh", "ly", "minh@minh.com", "84", "353727800", "No");
        await Expect(Page.Locator("//span[contains(text(),\"How many students would you like to enroll?\")]")).ToBeVisibleAsync();
    }


    [TestMethod]
    //Invalid email
    public async Task InvalidEmailSubmission()
    {
        await Page.GotoAsync(ConfigReader.GetBaseUrl());
        await _homePage.OnlineHighSchoolLink.ClickAsync();
        await _mohspage.ApplySchoolButton.ClickAsync();
        await Page.Locator("//button[@elname=\"next\"]").First.ClickAsync();
        await _infoPage.FillInfo("minh", "ly", "minh@minh");
        await Expect(Page.Locator("#error-Email")).ToBeVisibleAsync();
    }
}