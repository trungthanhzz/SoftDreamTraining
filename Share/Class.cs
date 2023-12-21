using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Share;

[DataContract]
public class ClassGrpc
{
    [DataMember(Order = 1)]
    public int Id { get; set; }
    [DataMember(Order = 2)]
    public string ClassName { get; set; }

    [DataMember(Order = 3)]
    public string Subject { get; set; }

    [DataMember(Order = 4)]
    public int TeacherId { get; set; }
}
[DataContract]
public class ListClass
{
    [DataMember(Order = 1)]
    public List<ClassGrpc> List = new List<ClassGrpc>();
}

[DataContract]
public class IntGrpc
{
    [DataMember(Order =1)]
    public int Id { get; set; }

    [DataMember(Order = 2)]
    public Empty Empty { get; set; }
}

[ServiceContract]
public interface ClassProto
{
    [OperationContract]
    ListClass GetAllClasses(Empty request, CallContext context = default);

    [OperationContract]
    ClassGrpc GetClassById(IntGrpc request, CallContext context = default);
}