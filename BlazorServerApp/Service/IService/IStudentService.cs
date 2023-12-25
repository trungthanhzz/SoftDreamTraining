﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp
{
    public interface IStudentService
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
        public void DeleteStudent(Student student);

        /// <summary>
        /// Hàm sắp xếp sinh viên theo tên
        /// </summary>
        /// <returns></returns>
        public void SortByName();

        /// <summary>
        /// Hàm lấy ra sinh viên theo Id
        /// </summary>
        public Student GetStudentById(int id);

        public int GetIdNewStudent();
        Task<PageView<Student>> GetDataPageAsync(int pageNumber, int pageSize, StudentFilter studentFilter);
    }
}
