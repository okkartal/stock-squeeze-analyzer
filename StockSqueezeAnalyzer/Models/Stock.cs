namespace StockSqueezeAnalyzer.Models;

public class Stock
{   public double ShortInterestRatioDaysToCover { get; set; }
    public double ShortPercentOfFloat { get; set; }
    public double ShortPercentIncreaseDecrease { get; set; }
    public double ShortInterestCurrentSharesShort { get; set; }
    public double SharesFloat { get; set; }
    public double ShortInterestPriorSharesShort { get; set; }
    public double PercentFrom52WkHigh { get; set; }
    public double PercentFrom50DayMa { get; set; }
    public double PercentFrom200DayMa { get; set; }
    public double PercentFrom52WkLow { get; set; }
    public double N52WeekPerformance { get; set; }
    public double TradingVolumeTodayVsAvg { get; set; }
    public double TradingVolumeToday { get; set; }
    public double TradingVolumeAverage { get; set; }
    public double MarketCap { get; set; }
    public double PercentOwnedByInsiders { get; set; }
    public double PercentOwnedByInstitutions { get; set; }
    public double Price { get; set; }
    public string? Name { get; set; }
    public string? Ticker { get; set; }
}