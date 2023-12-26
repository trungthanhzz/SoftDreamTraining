using AntDesign.Charts;
using Share;

namespace BlazorServerApp
{
    public class StudentMapper
    {
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;
        public StudentMapper(IClassService classService, IStudentService studentService)
        {
            _classService = classService;
            _studentService = studentService;
        }

        public StudentMapper()
        {
        }

        public StudentGrpc MapEntityToGrpc(Student student)
        {
            StudentGrpc studentGrpc = new StudentGrpc();
            studentGrpc.Id = student.Id;
            studentGrpc.Name = student.Name;
            studentGrpc.Address = student.Address;
            studentGrpc.DateOfBirth = student.DateOfBirth;
            studentGrpc.ClassId = student.Class.Id;
            return studentGrpc;
        }
        public Student MapGrpcToEntity(StudentGrpc studentGrpc)
        {
            Student student = new Student();
            student.Id = studentGrpc.Id;
            student.Name = studentGrpc.Name;
            student.Address = studentGrpc.Address;
            student.DateOfBirth = studentGrpc.DateOfBirth;
            if (student.Class == null)
            {
                student.Class = new Class();
            }
            student.Class.Id = studentGrpc.ClassId;
            return student;
        }

        public StudentViewDto MapEntityToViewDto (Student student)
        {
            try
            {
                StudentViewDto StudentViewDto = new StudentViewDto();
                StudentViewDto.Name = student.Name;
                StudentViewDto.Address = student.Address;
                StudentViewDto.ClassName = student.Class.ClassName;
                StudentViewDto.Dob = student.DateOfBirth.ToString("dd/MM/yyyy");
                StudentViewDto.Id = student.Id;
                return StudentViewDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<StudentViewDto> MapListToListViewDtoWithIndex(List<Student> list, int startIndex)
        { 
            List<StudentViewDto> listStudentView = new List<StudentViewDto>();
            var i = 1;
            
            foreach (var item in list)
            {
                StudentViewDto s = MapEntityToViewDto(item);
                s.Stt = startIndex + i;
                i++;
                listStudentView.Add(s);
            }

            return listStudentView;
        }

        public StudentDto MapEntityToDto(Student student)
        {
            StudentDto studentDto = new StudentDto();
            if (student.Id == 0)
            {
                return studentDto;
            }
            else
            {
                studentDto.Id = student.Id;
                studentDto.Name = student.Name;
                studentDto.Address = student.Address;
                studentDto.DateOfBirth = student.DateOfBirth;
                studentDto.ClassId = student.Class.Id;
                return studentDto;
            }
            return null;
        }

        public Student MapDtoToEntity (StudentDto studentDto)
        {
            Student student;
            if (studentDto.Id == 0)
            {
                student = new Student();
                student.Name = studentDto.Name;
                student.Address = studentDto.Address;
                student.DateOfBirth = studentDto.DateOfBirth;
                student.Class = new Class { Id = studentDto.ClassId};
                return student;
            }
            else 
            {
                student = new Student();
                student.Id = studentDto.Id;
                student.Name = studentDto.Name;
                student.Address = studentDto.Address;
                student.DateOfBirth = studentDto.DateOfBirth;
                student.Class = new Class { Id = studentDto.ClassId };
                return student;
            }
            return null;
        }
    }
}
