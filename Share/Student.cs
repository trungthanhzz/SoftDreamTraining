using ProtoBuf.Grpc;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Share;

[DataContract]
public class Empty
{

}

[DataContract]
public class StudentGrpc
{
    [DataMember(Order = 1)]
    public int Id { get; set; }

    [DataMember(Order = 2)]
    public string Name { get; set; }

    [DataMember(Order = 3)]
    public string Address { get; set; }

    [DataMember(Order = 4)]
    public DateTime DateOfBirth { get; set; }

    [DataMember(Order = 5)]
    public int ClassId { get; set; }
}

[DataContract]
public class ListStudent
{
    [DataMember(Order = 1)]
    public List<StudentGrpc> Students { get; set; } = new List<StudentGrpc>();
}

[DataContract]
public class PageViewGrpc
{
    [DataMember(Order = 1)]
    public List<StudentGrpc> Students { get; set; } = new List<StudentGrpc>();

    [DataMember(Order = 2)]
    public StudentFilterGrpc StudentFilterGrpc { get; set; }

    [DataMember(Order = 3)]
    public int PageNumber { get; set; }

    [DataMember(Order = 4)]
    public int PageSize { get; set; }

    [DataMember(Order = 5)]
    public int PageCount { get; set; }

    [DataMember(Order = 6)]
    public Empty Empty { get; set; }
}

[DataContract]
public class StudentFilterGrpc
{
    [DataMember(Order = 1)]
    public String Name { get; set; }
    [DataMember(Order = 2)]
    public DateTime? StartDate { get; set; }
    [DataMember(Order = 3)]
    public DateTime? EndDate { get; set; }

    [DataMember(Order = 4)]
    public String Address { get; set; }

    [DataMember(Order = 5)]
    public int ClassId { get; set; } = -1;

    [DataMember(Order = 6)]
    public int Id { get; set; } = -1;

    [DataMember(Order = 7)]
    public int Months { get; set; }

    public StudentFilterGrpc()
    {

    }
}

[ServiceContract]
public interface StudentProto
{
    [OperationContract]
    ListStudent GetAllStudents(Empty request, CallContext context = default);

    [OperationContract]
    Empty AddNewStudent(StudentGrpc request, CallContext context = default);

    [OperationContract]
    Empty DeleteStudent(StudentGrpc request, CallContext context = default);

    [OperationContract]
    Empty UpdateStudent(StudentGrpc request, CallContext context = default);

    [OperationContract]
    StudentGrpc GetStudentById (IntGrpc request, CallContext context = default);

    [OperationContract]
    Task<PageViewGrpc> GetDataPageAsync(PageViewGrpc pageViewGrpc, CallContext context = default);
}


