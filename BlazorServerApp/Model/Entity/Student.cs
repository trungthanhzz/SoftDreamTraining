using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateOfBirth { get; set; }

        public virtual string Address { get; set; }
        public virtual Class Class { get; set; }

        public override string ToString()
        {
            return $"Mã sinh viên: {Id}\nTên: {Name}\nNgày sinh: {DateOfBirth}\nĐịa chỉ: {Address}";
        }
    }
}
