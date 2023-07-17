using Microsoft.Playwright;
/*
 * Example of parsing dynamic page using Playwright
 */
class Program
{
    static async Task Main(string[] args)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        // Your code to interact with the page goes here
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.google.com/search?q=c%23&rlz=1C1SQJL_enUA881UA881&oq=c%23&aqs=chrome.0.69i59l3j0i512j69i65l3j69i58.949j0j7&sourceid=chrome&ie=UTF-8");
        
        // TODO::Should add filtering headers and links couse not all elements match one to one from two xpath queries
        
        var h3Elements = await page.QuerySelectorAllAsync("xpath=//div[@class='yuRUbf']//h3");
        var linkElements = await page.QuerySelectorAllAsync("xpath=//div[@class='yuRUbf']//a");
        
        // Trying to group results (see to-do note above)
        Tuple<IReadOnlyList<IElementHandle>, IReadOnlyList<IElementHandle>> titleToElement =
            new Tuple<IReadOnlyList<IElementHandle>, IReadOnlyList<IElementHandle>>(h3Elements, linkElements);
        var results = new Dictionary<string, string>();
        for (int i = 0; i < titleToElement.Item1.Count; i++)
        {
            string h3Content = await titleToElement.Item1[i].TextContentAsync();
            string aContent = await titleToElement.Item2[i].GetAttributeAsync("href");
            results.Add(h3Content, aContent);
        }
        foreach (var result in results)
        {
            Console.WriteLine($@"{result.Key} : {result.Value}");
        }
        
        // Results "as is"
        foreach (var h3Element in h3Elements)
        {
            // Do something with each <h3> element
            string textContent = await h3Element.TextContentAsync();
            Console.WriteLine(textContent);
        }
        foreach (var linkElement in linkElements)
        {
            // Do something with each <h3> element
            string textContent = await linkElement.GetAttributeAsync("href");
            Console.WriteLine(textContent);
        }
        await browser.CloseAsync();
    }
}