using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_Archi.Models
{
    public class PersonCreateForm
    {
        [Required]
        [DisplayName("Prénom")]
        public string Firstname { get; set; }

        [Required]
        [DisplayName("Nom de famille")]
        public string Lastname { get; set; }

        [DisplayName("Lien pour photo")]
        public string PictureUrl { get; set; }
    }
}
