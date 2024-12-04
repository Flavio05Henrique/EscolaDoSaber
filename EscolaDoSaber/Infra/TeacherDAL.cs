using EscolaDoSaber.Model;
using Microsoft.EntityFrameworkCore;

namespace EscolaDoSaber.Infra
{
    public class TeacherDAL : DAL<Teacher>
    {
        public TeacherDAL(SchoolContex context) : base(context)
        {
        }
    }
}
