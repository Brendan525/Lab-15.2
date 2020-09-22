using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_15._2.Controllers
{
    [Route("Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        const string connectionString = "Server=GWJSN13\\SQLEXPRESS; Database=Movies; user id =admin; password=pass1";

        public static Random rand = new Random();



        [HttpGet("All")]
        public List<Movie> All()
        {
            IDbConnection db = new SqlConnection(connectionString);
            List<Movie> movies = db.Query<Movie>($"select * from Movie").AsList<Movie>();
            return movies;

            //Movie movie = new Movie();
            //movie = Movie.GetAllMovies();

            //return movie;
        }

        [HttpGet("Category/{movieGenre}")]
        public List<Movie> Catgory(string movieGenre)
        {
            IDbConnection db = new SqlConnection(connectionString);
            List<Movie> movies = db.Query<Movie>($"SELECT * from Movie WHERE movieGenre = '{movieGenre}'").AsList<Movie>();
            return movies;
        }

        [HttpGet("Random")]
        public Movie Random()
        {
            IDbConnection db = new SqlConnection(connectionString); // Connects to database
            List<Movie> movie = db.Query<Movie>($"SELECT * from Movie").AsList<Movie>(); // Selects all from Movie database
            int result = rand.Next(0, movie.Count); // Selects one random movie from the Movie database

            return movie[result]; // Returns one random movie
        }

        [HttpGet("Random/{movieGenre}")]
        public Movie RandomMovieFromGenre(string movieGenre)
        {
            IDbConnection db = new SqlConnection(connectionString);
            List<Movie> movie = db.Query<Movie>($"SELECT * from Movie WHERE movieGenre = '{movieGenre}' ").AsList<Movie>();
            int result = rand.Next(0, movie.Count);

            return movie[result];
        }

        //[HttpGet("Random/{quantity}")]
        //public Movie RandomQuantity(int quantity)
        //{
        //    IDbConnection db = new SqlConnection(connectionString); 
        //    List<Movie> movie = db.Query<Movie>($"SELECT Top {quantity} from Movie").AsList<Movie>();
        //    int result = rand.Next(0, movie.Count); 

        //    return movie[result]; 
        //}

        [HttpGet("Category/All")]
        public List<Movie> AllCatgories()
        {
            IDbConnection db = new SqlConnection(connectionString);
            List<Movie> movies = db.Query<Movie>($"select movieGenre FROM Movie group by movieGenre").AsList<Movie>();
            return movies;
        }

        [HttpGet("{movieTitle}")]
        public List<Movie> GetMovieInfo(string movieTitle)
        {
            IDbConnection db = new SqlConnection(connectionString);
            List<Movie> movies = db.Query<Movie>($"SELECT * from Movie WHERE movieTitle Like '{movieTitle}'").AsList<Movie>();
            return movies;
        }

        [HttpGet("Keyword/{keyword}")]
        public List<Movie> Keyword(string keyword)
        {
            IDbConnection db = new SqlConnection(connectionString);
            List<Movie> movies = db.Query<Movie>($"SELECT * from Movie WHERE movieTitle LIKE '%{keyword}%'").AsList<Movie>();
            return movies;
        }







        //[HttpGet("Movie/{movieId}/{movieTitle}/{movieMainActor}/{movieGenre}/{movieDirector}")]
        ////public Movie film(long movieId, string movieTitle, string movieMainActor, string movieGenre, string movieDirector)
        //public Movie film(long movieId)
        //{
        //    Movie film1 = new Movie() { movieId = movieId, movieTitle = "Legend Of Zelda", movieMainActor = "Brendan Burch", movieGenre = "Action", movieDirector = "Brendan Burch"  };

        //    return film1;
        //}
    }
    }

