using Microsoft.Playwright;

public class MOHSPage
{

    public readonly IPage _page;

    public MOHSPage(IPage page)
    {
        _page = page;
    }

    public ILocator ApplySchoolButton => _page.Locator("//a[contains(text(),\"Apply to Our School\")]");


}