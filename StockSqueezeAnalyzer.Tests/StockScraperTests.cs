using StockSqueezeAnalyzer.Services;
using FluentAssertions;

namespace StockSqueezeAnalyzer.Tests;

public class StockScraperTests
{
    [Fact]
    public async Task Should_Be_Correct_Parsed_Data()
    {
        // Act
        var stock = await StockScraper.GetStockDataAsync("AAPL");

        // Assert
        stock.Should().NotBeNull();
        stock.Name.Should().Be("Apple Inc");
        stock.Ticker.Should().Be("AAPL");
        stock.Price.Should().BeGreaterOrEqualTo(0);

        stock.ShortInterestRatioDaysToCover.Should().BeGreaterOrEqualTo(0);
        stock.ShortPercentOfFloat.Should().BeGreaterOrEqualTo(0);
        stock.ShortPercentIncreaseDecrease.Should().BeGreaterOrEqualTo(0);
        stock.ShortInterestCurrentSharesShort.Should().BeGreaterOrEqualTo(0);
        stock.SharesFloat.Should().BeGreaterOrEqualTo(0);
        stock.ShortInterestPriorSharesShort.Should().BeGreaterOrEqualTo(0);
        stock.PercentFrom52WkHigh.Should().BeGreaterOrEqualTo(0);
        stock.PercentFrom50DayMa.Should().BeGreaterOrEqualTo(0);
        stock.PercentFrom200DayMa.Should().BeGreaterOrEqualTo(0);
        stock.PercentFrom52WkLow.Should().BeGreaterOrEqualTo(0);
        stock.N52WeekPerformance.Should().BeGreaterOrEqualTo(0);
        stock.TradingVolumeTodayVsAvg.Should().BeGreaterOrEqualTo(0);
        stock.TradingVolumeToday.Should().BeGreaterOrEqualTo(0);
        stock.TradingVolumeAverage.Should().BeGreaterOrEqualTo(0);
        stock.MarketCap.Should().BeGreaterOrEqualTo(0);
        stock.PercentOwnedByInsiders.Should().BeGreaterOrEqualTo(0);
        stock.PercentOwnedByInstitutions.Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task Should_Throws_Exception_Null_When_Ticker_Value_Is_Not_Provided()
    {
        // Arrange
        var ticker = string.Empty;

        // Act & Assert:
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await StockScraper.GetStockDataAsync(ticker);
        });
    }
    
    [Fact]
    public async Task Should_Return_Null_If_Ticker_Value_Is_Incorrect()
    {
        // Act
        var stock = await StockScraper.GetStockDataAsync("$Some invalid ticker");

        // Assert
        stock.Should().BeNull();
    }
}