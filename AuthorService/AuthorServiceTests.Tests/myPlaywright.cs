using Microsoft.Playwright;
using Xunit;

public class PlaywrightTests
{
    [Fact]
    public async Task TestBrowserLaunch()
    {
    
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();
        

        await page.GotoAsync("https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test");

    
        var title = await page.TitleAsync();
        Assert.Equal("Example Domain", title);
 
        
        await browser.CloseAsync();
    }
}

