# Currency Converter
The currency conversion library. The package can convert `decimal` or `MoneyAmount` values from one currency to another. It can process single or batched rates. 

## Usage
```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCurrencyConversionFactory(new ConversionBufferOptions
        {
            DefaultBuffer = 0.005m;
            ExceptionalPairs = new Dictionary<(Currencies, Currencies), decimal>
            {
                { (Currencies.USD, Currencies.EUR), 1m },
                { (Currencies.EUR, Currencies.USD), 1m }
            }
        });
        
        ...
    }
}


public class Class1
{
    public Class1(ICurrencyConverterFactory converterFactory)
    {
        _converterFactory = converterFactory;
    }
    
    
    public void Convert()
    {
        ...
        
        var converter = _converterFactory.Create(in rate, sourceCurrency, targetCurrency);
        var results = converter.Convert(values);
        
        ...
    }
}
```


## Automation

New package version is automatically published to [github packages](https://github.com/features/packages) after changes in master branch.


## Dependencies

The project depends on following packages: 
* `HappyTravel.Money`


## Dependent projects update

All projects referencing the package should be updated at one time to preserve consistency
