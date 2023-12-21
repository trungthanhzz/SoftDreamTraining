using ProtoBuf.Grpc;
using Share;

namespace GrpcService
{
    public class StudentService : StudentProto
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IStudentRepository _studentRepository;

        StudentMapper studentMapper = new StudentMapper();

        public StudentService(ILogger<GreeterService> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }   

        public Empty AddNewStudent(StudentGrpc request, CallContext context = default)
        {
            Student student = studentMapper.MapGrpcToEntity(request);
            _studentRepository.AddNewStudent(student);
            Empty empty = new Empty();
            return empty;
        }

        public Empty DeleteStudent(StudentGrpc request, CallContext context = default)
        {
            Student student = studentMapper.MapGrpcToEntity(request);
            _studentRepository.DeleteStudent(student);
            Empty empty = new Empty();
            return empty;
        }

        public ListStudent GetAllStudents(Empty request, CallContext context = default)
        {
            ListStudent listStudent = new ListStudent();
            List<Student> students = _studentRepository.GetAllStudents();
            foreach (Student student in students)
            {
                StudentGrpc studentGrpc = studentMapper.MapEntityToGrpc(student);
                listStudent.Students.Add(studentGrpc);
            }
            return listStudent;
        }

        public async Task<PageViewGrpc> GetDataPageAsync(PageViewGrpc pageViewGrpc, CallContext context = default)
        {
            try
            {
                PageView<Student> pageView = new PageView<Student>();
                pageView.PageNumber = pageViewGrpc.PageNumber;
                pageView.PageSize = pageViewGrpc.PageSize;
                StudentFilter filter = new StudentFilter();
                filter = MapGrpcToFilter(pageViewGrpc.StudentFilterGrpc);
                var result = await _studentRepository.GetDataPageAsync(pageView.PageNumber, pageView.PageSize, filter);
                var resultGrpc = new PageViewGrpc();
                resultGrpc.PageCount = result.PageCount;
                resultGrpc.PageNumber = result.PageNumber;
                resultGrpc.PageSize = resultGrpc.PageSize;
                foreach (var item in result.Data)
                {
                    StudentGrpc studentGrpc = studentMapper.MapEntityToGrpc(item);
                    resultGrpc.Students.Add(studentGrpc);
                }
                return resultGrpc;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public StudentGrpc GetStudentById(IntGrpc request, CallContext context = default)
        {
            try
            {
                StudentGrpc studentGrpc = new StudentGrpc();
                Student student = _studentRepository.GetStudentById(request.Id);
                studentGrpc = studentMapper.MapEntityToGrpc(student);
                return studentGrpc;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Empty UpdateStudent(StudentGrpc request, CallContext context = default)
        {
            Student student = studentMapper.MapGrpcToEntity(request);
            _studentRepository.UpdateStudent(student);
            Empty empty = new Empty();
            return empty;
        }

        private StudentFilter MapGrpcToFilter(StudentFilterGrpc studentFilterGrpc)
        {
            var filter = new StudentFilter();
            filter.StartDate = studentFilterGrpc.StartDate;
            filter.EndDate = studentFilterGrpc.EndDate;
            filter.Name = studentFilterGrpc.Name;
            filter.ClassId = studentFilterGrpc.ClassId;
            filter.Address = studentFilterGrpc.Address;
            return filter;
        }
    }
}
