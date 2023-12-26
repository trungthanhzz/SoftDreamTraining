using Share;

namespace BlazorServerApp
{
    public class ClassMapper
    {
        public ClassGrpc ClassToClassGrpc(Class @class)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = @class.Id;
            classGrpc.ClassName = @class.ClassName;
            classGrpc.Subject = @class.Subject;
           return classGrpc;
        }

        public Class ClassGrpcToClass(ClassGrpc classGrpc)
        {
            Class @class = new Class();
            @class.Id = classGrpc.Id;
            @class.ClassName = classGrpc.ClassName;
            @class.Subject = classGrpc.Subject;
            return @class;
        }
    }
}
