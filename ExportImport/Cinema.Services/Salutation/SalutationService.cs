using Cinema.DAO.Salutation;
using Cinema.Entities.Salutation;
using System.Data;

namespace Cinema.Services.Salutation
{
    public class SalutationService
    {
        private SalutationDao salutationDao = new SalutationDao();

        public DataTable GetAll()
        {
            DataTable dt = salutationDao.GetAll();
            return dt;
        }

        public DataTable Get(int id)
        {
            DataTable dt = salutationDao.Get(id);
            return dt;
        }

        public int CheckName(string word)
        {
            int id = salutationDao.CheckName(word);
            return id;
        }

        public int Exist(SalutationEntity salutationEntity)
        {
            int count = salutationDao.Exist(salutationEntity);
            return count;
        }

        public bool Insert(SalutationEntity salutationEntity)
        {
            return salutationDao.Insert(salutationEntity);
        }

        public bool Update(SalutationEntity salutationEntity)
        {
            return salutationDao.Update(salutationEntity);
        }

        public bool Delete(int id)
        {
            return salutationDao.Delete(id);
        }
    }
}
