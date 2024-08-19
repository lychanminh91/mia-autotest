using Microsoft.Playwright;

public class PlaywrightDriver
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    public IBrowserContext BrowserContext { get; private set; }
    public IPage Page { get; private set; }

    public async Task<IPage> InitializeAsync(string browserType)
    {
        // _playwright = await Playwright.CreateAsync();

        _browser = browserType.ToLower() switch
        {
            "chrome" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
            "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
            _ => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
        };

        BrowserContext = await _browser.NewContextAsync();
        Page = await BrowserContext.NewPageAsync();
        return Page;
    }

    public async Task CloseAsync()
    {
        await Page.CloseAsync();
        await BrowserContext.CloseAsync();
        await _browser.CloseAsync();
    }
}