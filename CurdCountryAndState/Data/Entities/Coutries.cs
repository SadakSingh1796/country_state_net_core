using System.ComponentModel.DataAnnotations;

namespace CurdCountryAndState.Data.Entities
{
    public class Coutries
    {
        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Country Name is required")]
        public string CountryName { get; set; }

        // Navigation property to access the associated states
        //public ICollection<States> State { get; set; }

    }
}
