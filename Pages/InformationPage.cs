using Microsoft.Playwright;

public class InformationPage
{

    public readonly IPage _page;

    public InformationPage(IPage page)
    {
        _page = page;
    }

    public ILocator FirstNextButton => _page.Locator("//button[@elname=\"next\"]").First;
    public ILocator FirstNameField => _page.Locator("//input[@elname=\"First\" and @name=\"Name\"]");
    public ILocator LastNameField => _page.Locator("//input[@elname=\"Last\" and @name=\"Name\"]");
    public ILocator EmailField => _page.Locator("#Email-arialabel");
    public ILocator FlagDropDown => _page.Locator("//div[@class=\"flag-container\"]");
    public ILocator PhoneNumberField => _page.Locator("//input[@name=\"PhoneNumber\"]");
    public ILocator SecondParentDropdown => _page.Locator("//span[@class=\"select2-selection select2-selection--single select2FormCont\"]").First;
    public ILocator SecondParentOption => _page.Locator("//input[@class=\"select2-search__field\"]");
    public ILocator SocialChannelBox => _page.Locator("//span[@class=\"multiAttType cusChoiceSpan\"]").First;
    public ILocator StartDateDatePicker => _page.Locator("//input[@id=\"Date-date\"]");
    public ILocator SecondNextButton => _page.Locator("//ul[@page_no=\"2\"]//button[@elname=\"next\"]");

    public async Task SelectCustomDropdownOption(string attributeValue)
    {
        await FlagDropDown.IsVisibleAsync();
        await FlagDropDown.ClickAsync();
        await _page.ClickAsync($"//li[@data-dial-code='{attributeValue}']");
    }

    public async Task FillInfo(string firstname, string lastname, string email, string phoneCode, string phoneNumber, string secondParentOption)
    {
        await FirstNameField.FillAsync(firstname);
        await LastNameField.FillAsync(lastname);
        await EmailField.FillAsync(email);
        await SelectCustomDropdownOption(phoneCode);
        await PhoneNumberField.FillAsync(phoneNumber);
        await SecondParentDropdown.ClickAsync();
        await SecondParentOption.FillAsync(secondParentOption);
        await _page.Keyboard.PressAsync("Enter");
        await SocialChannelBox.ClickAsync();
        await StartDateDatePicker.ClickAsync();
        await _page.Keyboard.PressAsync("Enter");
        await SecondNextButton.ClickAsync();
    }

}