using Cinema.DAO.Member;
using Cinema.Entities.Member;
using System.Data;

namespace Cinema.Services.Member
{
    public class MemberService
    {
        public MemberDao memberDao = new MemberDao();

        public DataTable GetAll()
        {
            DataTable dt = memberDao.GetAll();
            return dt;
        }

        public DataTable Get(int id)
        {
            DataTable dt = memberDao.Get(id);
            return dt;
        }

        public DataTable Search(string keyword)
        {
            DataTable dt = memberDao.Search(keyword);
            return dt;
        }

        public bool Insert(MemberEntity memberEntity)
        {
            return memberDao.Insert(memberEntity);
        }

        public bool Update(MemberEntity memberEntity)
        {
            return memberDao.Update(memberEntity);
        }

        public bool Delete(int id)
        {
            return memberDao.Delete(id);
        }
    }
}
