using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace GrpcService
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IClassRepository _classRepository;
        private readonly ISessionFactory _session;
        public StudentRepository(IClassRepository classRepository, ISessionFactory session)
        {
            _classRepository = classRepository;
            _session = session;
        }
        public void AddNewStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(student);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }
   
        public void DeleteStudent(Student student)
        {
            using (var session = _session.OpenSession()) 
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(student);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Student>()
                    .Fetch(s=> s.Class)
                    .ToList();
            }
        }

        public async Task<PageView<Student>> GetDataPageAsync(int pageNumber, int pageSize, StudentFilter studentFilter)
        {
            //get index

            //get and convert data
            using (var session = _session.OpenSession())
            {
                var query = session.Query<Student>(); // Implement NHibernate query here
                query = Filter(query, studentFilter);
                var pagedData = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                var total = query.Count();
                return new PageView<Student>
                {
                    Data = pagedData,
                    PageCount = total // Đây là tổng số mục
                };
            }
        }

        public Student GetStudentById(int id)
        {
            using (var session = _session.OpenSession())
            {
                var student = session.Query<Student>()
                    .Fetch(s => s.Class)
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
                return student;
            }
        }

        public List<Student> SortByName()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.Class)
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(student);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
            }
        }
        private IQueryable<Student>? Filter(IQueryable<Student> query, StudentFilter studentFilter)
        {
            if (studentFilter.Name != null && !studentFilter.Name.Equals(""))
            {
                query = query.Where(c => c.Name.Contains(studentFilter.Name));
            }
            if (studentFilter.Address != null && !studentFilter.Address.Equals(""))
            {
                query = query.Where(c => c.Address.Contains(studentFilter.Address));
            }
            if (studentFilter.StartDate != null)
            {
                query = query.Where(student => student.DateOfBirth >= studentFilter.StartDate);
            }
            if (studentFilter.EndDate != null)
            {
                query = query.Where(student => student.DateOfBirth <= studentFilter.EndDate);
            }
            if (studentFilter.ClassId != -1)
            {
                query = query.Where(student => student.Class.Id == studentFilter.ClassId);
            }
            if (studentFilter.Id != -1)
            {
                query = query.Where(student => student.Id == studentFilter.Id);
            }
            return query;
        }
    }
}
