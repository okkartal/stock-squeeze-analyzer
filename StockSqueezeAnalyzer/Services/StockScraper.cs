using HtmlAgilityPack;
using System.Text.RegularExpressions;
using StockSqueezeAnalyzer.Models;


namespace StockSqueezeAnalyzer.Services;

public abstract class StockScraper
{
    private static readonly HttpClient Client;

    static StockScraper()
    {
        Client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    private static string ToCamelCase(string input)
    {
        return Regex.Replace(input, "(?:^|\\s)([a-z])", m => m.Groups[1].Value.ToUpper())
            .Replace(" ", "")
            .Replace("%", "Percent");
    }

    private static double? ParseValue(string value)
    {
        value = Regex.Replace(value, @"[\s%,\$]", "");
        return double.TryParse(value, out var result) ? result : (double?)null;
    }

    private static Stock ParseStockData(string htmlContent)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(htmlContent);

        var rows = doc.DocumentNode.SelectNodes("//div[@class='inner_box_2']//table/tr");

        if (rows == null || rows.Count < 3 || rows[0].InnerText.ToLower().Trim().Replace("$","") .Contains("not available - try again") )return null!;

        var stock = new Stock();
       
        foreach (var row in rows.Skip(3))
        {
            var cells = row.SelectNodes("td");
          
            if (cells == null || cells.Count < 2) continue;

            var key = ToCamelCase(cells[0].InnerText.Trim());
            var value = ParseValue(cells[1].InnerText);

            if (!string.IsNullOrEmpty(key) && value.HasValue)
            {
                typeof(Stock).GetProperty(key)?.SetValue(stock, value);
            }
        }

        var innerText = rows[0].SelectSingleNode("td[2]")?.InnerText;
        
        if (innerText == null) return stock;
        
        stock.Price = ParseValue(innerText) ?? 0;
        stock.Name = rows[0].SelectSingleNode("td")?.InnerText?.Trim() ?? "";
        stock.Ticker = rows[1].SelectSingleNode("td")?.InnerText?.Trim() ?? "";

        return stock;
    }
    
    public static async Task<Stock> GetStockDataAsync(string ticker)
    {
        if (string.IsNullOrEmpty(ticker))
        {
            throw new ArgumentException("Ticker cannot be null or empty.", nameof(ticker));
        }
        
        var url = $"https://shortsqueeze.com/?symbol={ticker}";

        try
        {
            var response = await Client.GetStringAsync(url);
            return ParseStockData(response);
        }
        catch (Exception ex)
        {
            await Console.Error.WriteLineAsync($"An error occurred: {ex.Message}");
            return null!;
        }
    }
}