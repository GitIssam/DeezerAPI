using Newtonsoft.Json;


namespace Deezer.BlindTest.Tools
   
{
    public class DeezerApp
    {

        public string GetDataFromApi(string url)
        {
            string result = "";

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);

            result = client.GetStringAsync(client.BaseAddress).Result;

            return result;

        }

        public List<Artist> GetArtistFromDeezer(string url)
        {
            List<Artist> artists = new List<Artist>();

            var json = GetDataFromApi(url);

            //etape 1 : Deserialisation dynamique des datas 

            var data = JsonConvert.DeserializeObject<dynamic>(json);

            //etape 2 : parcours des données 
            foreach (var artist in data["data"])
            {
                //etape 2a = Création d'un artiste
                var newArtist = new Artist();
                newArtist.Name = artist["name"];
                newArtist.Id = artist["id"];
                newArtist.Picture = artist["picture"];
                //etape 2b : ajout de l'artiste à la liste
                artists.Add(newArtist);

            }
            //artists = JsonConvert.DeserializeObject<List<Artist>>(GetDataFromApi(url));


            return artists;
        }

        public string InsertArtist()
        {
            string result = "";




            return result;
        }

    }
}