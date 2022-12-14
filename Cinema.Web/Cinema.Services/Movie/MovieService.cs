using Cinema.DAO.Movie;
using Cinema.Entities.Movie;
using System.Data;

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

        public int Exist(MovieEntity movieEntity)
        {
            int exist = movieDao.Exist(movieEntity);
            return exist;
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
