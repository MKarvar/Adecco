using FluentValidation;

namespace NasaImageLibrary.Applicationservice.Queries
{
    public class SearchFilesWithPaginationQuery : PaginationQuery
    {
        public SearchFilesQuery GetUsersQuery { get; set; }

        public class SearchFilesWithPaginationQueryValidator : AbstractValidator<SearchFilesWithPaginationQuery>
        {
            public SearchFilesWithPaginationQueryValidator(PaginationQueryValidator baseValidator)
            {
                RuleFor(c => c).SetValidator(baseValidator);
            }
        }
    }
}
