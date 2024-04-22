using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace CRUDTest
{

    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }
        [Fact]
        public void AddCountry_NullCountry()
        {
            CountryAddRequest? request = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = _countriesService.AddCountry(request!);
            });

        }

        [Fact]
        public void AddCountry_DuplicatedCountryName()
        {
            CountryAddRequest? request1 = new() { CountryName = "Sweden" };
            CountryAddRequest? request2 = new() { CountryName = "Sweden" };

            _ = _countriesService.AddCountry(request1);
            Assert.Throws<ArgumentException>(() =>
            {
                _ = _countriesService.AddCountry(request2);
            });

        }

        [Fact]
        public void AddCountry_Success()
        {
            string countryName = "Sweden";
            CountryAddRequest? request1 = new() { CountryName = countryName };


            CountryResponse response = _countriesService.AddCountry(request1);

            Assert.Equal(countryName, response.Name);
            Assert.NotEqual(Guid.Empty, response.Id);
        }

        [Fact]
        public void AddCountry_NameIsNull()
        {

            CountryAddRequest? request = new() { CountryName = null };

            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = _countriesService.AddCountry(request);
            });


        }

        [Fact]
        public void GetAllCountries_GetTwoCountries()
        {

            CountryAddRequest? request1 = new() { CountryName = "Sweden" };
            CountryAddRequest? request2 = new() { CountryName = "Denmark" };
            CountryResponse response1 = _countriesService.AddCountry(request1);
            CountryResponse response2 = _countriesService.AddCountry(request2);

            List<CountryResponse> result = _countriesService.GetAllCountries();

            Assert.Equal(2, result.Count);
            Assert.Equal(response1, result[0]);
            Assert.Equal(response2, result[1]);
        }
    }
}