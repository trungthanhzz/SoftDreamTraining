﻿using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share;

namespace BlazorServerApp
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        StudentMapper studentMapper = new StudentMapper();

        public StudentProto GetService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress($"http://localhost:5113", new GrpcChannelOptions { HttpHandler = httpHandler });
            return channel.CreateGrpcService<StudentProto>();
        }

        public void AddNewStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.DeleteStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = new List<Student>();
                var client = GetService();
                Empty empty = new Empty();
                var listStudent = client.GetAllStudents(empty);
                foreach (var student in listStudent.Students)
                {
                    Student student1 = studentMapper.MapGrpcToEntity(student);
                    students.Add(student1);
                }
                return students;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public int GetIdNewStudent()
        {
            var student = GetAllStudents().OrderByDescending(x => x.Id).First();
            return student.Id + 1;
        }


        public Student GetStudentById(int id)
        {
            try
            {
                IntGrpc intGrpc = new IntGrpc();
                intGrpc.Id = id;
                intGrpc.Empty = new Empty();
                var client = GetService();
                var studentGrpc = client.GetStudentById(intGrpc);
                Student student = studentMapper.MapGrpcToEntity(studentGrpc);
                return student;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void SortByName()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<PageView<Student>> GetDataPageAsync(int pageNumber, int pageSize, StudentFilter studentFilter)
        {
            try
            {
                PageViewGrpc pageViewGrpc = new PageViewGrpc();
                pageViewGrpc.Empty = new Empty();
                pageViewGrpc.PageNumber = pageNumber;
                pageViewGrpc.PageSize = pageSize;
                pageViewGrpc.StudentFilterGrpc = MapFilterToGrpc(studentFilter);
                var client = GetService();
                var resultGrpc = await client.GetDataPageAsync(pageViewGrpc);
                PageView<Student> result = new PageView<Student>();
                result.Data = new List<Student>();
                foreach ( var item in resultGrpc.Students)
                {
                    Student student2 = studentMapper.MapGrpcToEntity(item);
                    result.Data.Add(student2);
                }
                result.PageNumber = resultGrpc.PageNumber;
                result.PageCount = resultGrpc.PageCount;
                result.PageSize = resultGrpc.PageSize;
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        private StudentFilterGrpc MapFilterToGrpc(StudentFilter studentFilter)
        {
            var filterGrpc = new StudentFilterGrpc();
            filterGrpc.StartDate = studentFilter.StartDate;
            filterGrpc.EndDate = studentFilter.EndDate; 
            filterGrpc.Name = studentFilter.Name;
            filterGrpc.ClassId = studentFilter.ClassId;
            filterGrpc.Address = studentFilter.Address;
            return filterGrpc;
        }
    }
}
