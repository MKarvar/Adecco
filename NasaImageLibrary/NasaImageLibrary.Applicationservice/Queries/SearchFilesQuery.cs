using FluentValidation;

namespace NasaImageLibrary.Applicationservice.Queries
{
    public class SearchFilesQuery 
    {
        public string SearchPhrase { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string MediaType => "Image";
    }

    public class SearchFileQueryValidator : AbstractValidator<SearchFilesQuery>
    {
        //int minValidYear = 1800;
        //int maxValidYear = DateTime.Now.Year;
        public SearchFileQueryValidator()
        {
            RuleFor(c => c.StartYear)
                .Matches("^(?:\\d{4}|)$").WithMessage($"StartYear is not valid.");
            RuleFor(c => c.EndYear)
                .Matches("^(?:\\d{4}|)$").WithMessage($"EndYear is not valid.");

            //RuleFor(x => x.StartYear)
            //   .Custom((x, context) =>
            //   {
            //       if (!string.IsNullOrWhiteSpace(x) && (!(int.TryParse(x, out int value)) || value < minValidYear || value > maxValidYear))
            //       {
            //           context.AddFailure($"{x} is not valid.");
            //       }
            //   });
            //RuleFor(x => x.EndYear)
            //  .Custom((x, context) =>
            //  {
            //      if (!string.IsNullOrWhiteSpace(x) && (!(int.TryParse(x, out int value)) || value < minValidYear || value > maxValidYear))
            //      {
            //          context.AddFailure($"{x} is not valid.");
            //      }
            //  });
        }
    }
}
