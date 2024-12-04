using EscolaDoSaber.Model;
using Microsoft.EntityFrameworkCore;

namespace EscolaDoSaber.Infra
{
    public class StudentDAL : DAL<Student>
    {
        public StudentDAL(SchoolContex context) : base(context)
        {
        }
    }
}
