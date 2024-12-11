<div>
  <h1>Stock Squeeze Analyzer</h1>
  <a href="https://www.nuget.org/packages/StockSqueezeAnalyzer/"> 
   <img src="https://img.shields.io/nuget/dt/StockSqueezeAnalyzer"
   alt="Nuget downloads" 
   data-canonical-src="https://img.shields.io/nuget/dt/StockSqueezeAnalyzer?color=2da44e&amp;label=nuget%20downloads&amp;logo=nuget"
   style="max-width: 100%;">
  </a>
</div> 

## Dependencies

| StockSqueezeAnalyzer | .NET 9 |
|----------------------|--------|
| HtmlAgilityPack       1.11.71 |

## Install

```nuget
with .NET CLI 

dotnet add package StockSqueezeAnalyzer

with Package Manager

NuGet\Install-Package StockSqueezeAnalyzer

with Package Reference

<PackageReference Include="StockSqueezeAnalyzer" Version="1.0.0" />
```

## Setup

**Step 1:** Import the namespace

```cs
using StockSqueezeAnalyzer.Services;
```

## Use

```cs 
var result = await StockScraper.GetStockDataAsync("AAPL");
```

 
 
