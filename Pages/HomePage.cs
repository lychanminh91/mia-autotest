using Microsoft.Playwright;

public class HomePage
{

    public readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public ILocator OnlineHighSchoolBanner => _page.Locator("//a[contains(text(),\"Online High School\")]");
    public ILocator OnlineHighSchoolLink => _page.GetByText("Online High School");

}