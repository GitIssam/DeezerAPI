using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deezer.BlindTest.Tools
{
    public class Db
    {
        string _connectionString;

        SqlConnection _sqlConnection;

        public Db(string connectionString)

        {


            _sqlConnection = new SqlConnection(connectionString);


        }

        public int AddArtist(string artistName, string artistFirstName, string artistLastName)

        {
            int result = 1;

            try
            {
                // tester response est dans la base 
                string query = " SELECT Id(*) "
                    + " FROM Artist "
                    + " WHERE Content = '" + artistName + "'";
                // execute cette cmd 
                SqlCommand cmd = _sqlConnection.CreateCommand();
                cmd.CommandText = query;
                _sqlConnection.Open();

                // test du resultat
                if ((int)cmd.ExecuteScalar() == 0)
                {
                    query = "INSERT INTO [dbo].[ProjetFileRougeCorrection]([Id],[Name],[FirstName],[LastName]) VALUES (1 , " + artistName + " ," + artistFirstName + " , " + artistLastName + " )";

                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                result = 0;
            }

            return result;
        }

        //méthode qui permet de récuperer les games dans la bdd
        //c'est une liste de games donc public list
        public List<Game> GetGames()
        {
            // on initialise la list 
            List<Game> games = new List<Game>();
            // création de la query

            string query = "SELECT Id,Title FROM Game";

            //on créer la commande
            SqlCommand cmd = _sqlConnection.CreateCommand();

            cmd.CommandText = query;

            //ouverture de la connection
            _sqlConnection.Open();

            //on va lire le contenu de la commande

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

               Game game = new Game();


                game.Id = (int)reader["Id"];

                game.Title = (string)reader["Title"];

                games.Add(game);

            }

            reader.Close();

            _sqlConnection.Close();

            return games;
        }

        //méthode qui permet de récuperer les track d'un game
        public List<Track> GetTrackFromGames(int gameId)
        {
            List<Track> tracks = new List<Track>();

            string query = "SELECT Track.Id,Track.Title,Track.Preview FROM Track INNER JOIN Listening ON Track.Id = Listening.TrackId INNER JOIN Game ON Listening.GameId = Game.Id WHERE Game.Id = '" + gameId +   "' ";

            SqlCommand cmd = _sqlConnection.CreateCommand();

            cmd.CommandText = query;

            _sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Track track = new Track();


                track.Id = (int)reader["Id"];

                track.Title = (string)reader["Title"];

                track.Preview = (string)reader["Preview"];

                tracks.Add(track);

            }

            reader.Close();

            _sqlConnection.Close();

            return tracks;
        }
        

    }

        //public int AddAlbum(string title, int dateOfRelease)
        //{
        //    int result = 1;

        //    try
        //    {
        //        // tester response est dans la base 
        //        string query = " SELECT Id(*) "
        //            + " FROM Title "
        //            + " WHERE Content = '" + title + "'";
        //        // execute cette cmd 
        //        SqlCommand cmd = _sqlConnection.CreateCommand();
        //        cmd.CommandText = query;
        //        _sqlConnection.Open();

        //        // test du resultat
        //        if ((int)cmd.ExecuteScalar() == 0)
        //        {
        //            query = "INSERT INTO [dbo].[ProjetFileRougeCorrection]([Id],[Title],[DateOfRelease]) VALUES (1 , " + title + " , " + dateOfRelease + " )";

        //            cmd.CommandText = query;

        //            cmd.ExecuteNonQuery();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        result = 0;
        //    }

        //    return result;
        //}

        //public int AddTrack(int SongId)
        //{

        //    int result = 1;

        //    try
        //    {
        //        // tester response est dans la base 
        //        string query = " SELECT SongId(*) "
        //            + " FROM TrackForGame "
        //            + " WHERE Content = '" + SongId + "'";
        //        // execute cette cmd 
        //        SqlCommand cmd = _sqlConnection.CreateCommand();
        //        cmd.CommandText = query;
        //        _sqlConnection.Open();

        //        // test du resultat
        //        if ((int)cmd.ExecuteScalar() == 0)
        //        {
        //            query = "INSERT INTO [dbo].[ProjetFileRougeCorrection]([Id],[SongId]]) VALUES (1 , " + SongId + " )";

        //            cmd.CommandText = query;

        //            cmd.ExecuteNonQuery();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        result = 0;
        //    }

        //    return result;
        

        //}

    }


