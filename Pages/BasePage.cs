using Microsoft.Playwright;

public abstract class BasePage
{
    protected IPage _page;

    public BasePage(IPage page)
    {
        _page = page;
    }

    public async Task<string> GetPageTitleAsync()
    {
        return await _page.TitleAsync();
    }

    public async Task Navigate(string url)
    {
        await _page.GotoAsync(url);
    }

}
