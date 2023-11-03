using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace CurdCountryAndState.Data.Entities
{
    public class States
    {
        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "State Name is required")]
        public string StateName { get; set; }

        // Foreign key property to relate to the Country
        public int CountryId { get; set; }

        // Navigation property to access the associated country
        //public Coutries Country { get; set; }
    }
}
