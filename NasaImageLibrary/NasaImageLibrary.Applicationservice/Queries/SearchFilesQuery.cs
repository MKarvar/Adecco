using FluentValidation;

namespace NasaImageLibrary.Applicationservice.Queries
{
    public class SearchFilesQuery 
    {
        public string SearchPhrase { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        //public string media_type => "image";
    }

    public class SearchFileQueryValidator : AbstractValidator<SearchFilesQuery>
    {
       
        public SearchFileQueryValidator()
        {
            RuleFor(c => c.StartYear)
                .Matches("^(?:\\d{4}|)$").WithMessage($"StartYear is not valid.");
            RuleFor(c => c.EndYear)
                .Matches("^(?:\\d{4}|)$").WithMessage($"EndYear is not valid.");
        }
    }
}
