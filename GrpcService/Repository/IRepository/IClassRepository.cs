using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcService
{
    public interface IClassRepository
    {
        /// <summary>
        /// Hàm lấy ra tất cả các lớp học
        /// </summary>
        /// <returns></returns>
        public List<Class> GetAllClasses();

        /// <summary>
        /// Lấy ra lớp học theo id tương ứng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Class GetClassById(int id);
    }
}
