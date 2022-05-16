using Xunit;
using Deezer.BlindTest.Tools;
using Newtonsoft.Json;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            DeezerApp call = new DeezerApp();
            var url = "http://api.deezer.com/2.0/search/artist?q=Beth%20Hart";
            var result = call.GetDataFromApi(url);

            //try

            Assert.NotNull(result);

            Artist artist = JsonConvert.DeserializeObject<Artist>(result);

            //try

            Assert.NotNull(artist);

            var results = call.GetArtistFromDeezer(url);

            Assert.Equal(8, results.Count);


        }

        [Fact]
        public void TestMethodGetArtists()
        {

            DeezerApp call = new DeezerApp();
            var url = "http://api.deezer.com/2.0/search/artist?q=Beth%20Hart";

            var results = call.GetArtistFromDeezer(url);


            Assert.Equal(8, results.Count);
        }
    }
}