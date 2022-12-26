using System.Data;
using TEST.DAO.Category;
using TEST.Entities.Category;

namespace TEST.Services.Category
{
    public class CategoryService
    {
        private CategoryDao categoryDao = new CategoryDao();

        public DataTable GetAll()
        {
            DataTable dt = categoryDao.GetAll();
            return dt;
        }

        public DataTable Get(int id)
        {
            DataTable dt = categoryDao.Get(id);
            return dt;
        }

        public bool Insert(CategoryEntity categoryEntity)
        {
            return categoryDao.Insert(categoryEntity);
        }

        public bool Update(CategoryEntity categoryEntity)
        {
            return categoryDao.Update(categoryEntity);
        }

        public bool Delete(int id)
        {
            return categoryDao.Delete(id);
        }
    }
}
