using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab_15._2
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public long movieId { get; set; }

        public string movieTitle { get; set; }

        public string movieGenre { get; set; }

        public string movieMainActor { get; set; }

        public string movieDirector { get; set; }


        const string connectionString = "Server=GWJSN13\\SQLEXPRESS; Database=Movie; user id =admin; password=pass1";

    }
}
