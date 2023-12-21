using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp
{
    public class Teacher
    {
        public virtual int Id { get; set; }
        public virtual string TeacherName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
