using FluentValidation;

namespace NasaImageLibrary.Applicationservice.Queries
{
    public class ExternalSearchFilesQuery 
    {
        public string q { get; set; }
        public string year_start { get; set; }
        public string year_end { get; set; }
        public string media_type => "image";
        public int page { get; set; }
    }

}
