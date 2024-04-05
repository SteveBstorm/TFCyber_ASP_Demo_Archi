using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;

namespace ASP_Demo_Archi.Models
{
    public class PersonDetailView : Person
    {
        public List<Movie> Filmographie { get; set; }

    }
}
