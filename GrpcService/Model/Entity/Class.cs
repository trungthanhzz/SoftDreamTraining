using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcService
{
    public class Class
    {
        public virtual int Id { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual string ClassName { get; set; }
        public virtual string Subject { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
