using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represent business logic for manipulating Country entity
/// </summary>
public interface ICountriesService
{
    CountryResponse AddCountry(CountryAddRequest countryAddRequest);
    List<CountryResponse> GetAllCountries();
}
