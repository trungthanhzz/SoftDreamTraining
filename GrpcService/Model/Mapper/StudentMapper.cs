using Share;

namespace GrpcService
{
    public class StudentMapper
    {
        public StudentGrpc MapEntityToGrpc(Student student)
        {
            StudentGrpc studentGrpc = new StudentGrpc();
            studentGrpc.Id = student.Id;
            studentGrpc.Name = student.Name;
            studentGrpc.Address = student.Address;
            studentGrpc.DateOfBirth = student.DateOfBirth;
            if (student.Class == null)
            {
                student.Class = new Class();
            }
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

    }
}
