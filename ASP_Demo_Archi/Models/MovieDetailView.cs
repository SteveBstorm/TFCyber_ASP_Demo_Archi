using ASP_Demo_Archi_DAL.Models;

namespace ASP_Demo_Archi.Models
{
    public class MovieDetailView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public Person Realisator { get; set; }
    }
}
