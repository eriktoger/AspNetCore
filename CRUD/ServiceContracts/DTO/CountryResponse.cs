using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class for returning a country
    /// </summary>
    public class CountryResponse : IEquatable<CountryResponse>
    {
        public string Name { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CountryResponse other = (CountryResponse)obj;
            return Id == other.Id;
        }
        public bool Equals(CountryResponse? other)
        {
            if (other == null)
            {
                return false;
            }
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse { Id = country.Id, Name = country.Name };
        }
    }
}

