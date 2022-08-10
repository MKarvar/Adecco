using NasaImageLibrary.Applicationservice.Queries;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NasaImageLibrary.Test
{
    public class GetImageTests
    {
        private const string sampleSearchPhrase = "SamplePhrase";
        //[Theory]
        //[InlineData("start" , "1888")]
        //[InlineData("start", "end")]
        //[InlineData("", "end")]
        //public void SearchImages_ShouldThrowApplicationServiceException_WhenYearIsInvalid(string startYear, string endYear)
        //{
        //    Assert.Throws<Exception>(() => new SearchFilesQuery() { SearchPhrase = sampleSearchPhrase, StartYear = startYear, EndYear = endYear });
        //}
    }
}
