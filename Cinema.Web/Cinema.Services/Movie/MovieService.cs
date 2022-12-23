using Cinema.DAO.Movie;
using Cinema.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Services.Movie
{
    public class MovieService
    {
        public MovieDao movieDao = new MovieDao();

        public DataTable GetAll ()
        {
            DataTable dt = movieDao.GetAll ();
            return dt;
        }

        public DataTable Get(int id)
        {
            DataTable dt = movieDao.Get (id);
            return dt;
        }

        public bool Insert(MovieEntity movieEntity)
        {
            return movieDao.Insert(movieEntity);
        }

        public bool Update(MovieEntity movieEntity)
        {
            return movieDao.Update(movieEntity);
        }

        public bool Delete(int id) {
            return movieDao.Delete(id);
        }
    }
}
