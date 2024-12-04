using EscolaDoSaber.Model;
using Microsoft.EntityFrameworkCore;

namespace EscolaDoSaber.Infra
{
    public class CourseDAL : DAL<Course>
    {
        public CourseDAL(SchoolContex context) : base(context)
        {
        }
    }
}
