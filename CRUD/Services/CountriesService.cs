using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries = [];
    public CountryResponse AddCountry(CountryAddRequest countryAddRequest)
    {
        ArgumentNullException.ThrowIfNull(countryAddRequest);
        ArgumentNullException.ThrowIfNull(countryAddRequest.CountryName);

        if (_countries.Any(c => c.Name == countryAddRequest.CountryName))
        {
            throw new ArgumentException("Country already in list");
        }

        Country country = countryAddRequest.ToCountry();
        _countries.Add(country);

        return country.ToCountryResponse();
    }

    public List<CountryResponse> GetAllCountries()
    {
        return _countries.ConvertAll(c => c.ToCountryResponse());
    }
}
