using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp
{
    /// <summary>
    /// Interface của repository sinh viên
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Hàm lấy tất cả sinh viên
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents();

        /// <summary>
        /// Hàm thêm mới sinh viên
        /// </summary>
        /// <param name="student"></param>
        public Boolean AddNewStudent(Student student);

        /// <summary>
        /// Hàm cập nhật thông tin sinh viên
        /// </summary>
        /// <param name="studentUpdate"></param>
        public Boolean UpdateStudent(Student student);

        /// <summary>
        /// Hàm xóa 1 sinh viên
        /// </summary>
        /// <param name="student"></param>
        public Boolean DeleteStudent(Student student);

        /// <summary>
        /// Hàm sắp xếp sinh viên theo tên
        /// </summary>
        /// <returns></returns>
        public List<Student> SortByName();

        /// <summary>
        /// Hàm lấy ra sinh viên theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudentById(int id);

        public int GetIdNewStudent();

        /// <summary>
        /// Lấy dữ liệu sinh viên theo paging và filter
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="studentFilter"></param>
        /// <returns></returns>
        Task<PageView<Student>> GetDataPageAsync(int pageNumber, int pageSize, StudentFilter studentFilter);

    }
}
