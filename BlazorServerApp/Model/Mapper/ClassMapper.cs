using Share;

namespace BlazorServerApp
{
    public class ClassMapper
    {
        public ClassGrpc ClassToClassGrpc(Class _class)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = _class.Id;
            classGrpc.ClassName = _class.ClassName;
            classGrpc.Subject = _class.Subject;
           return classGrpc;
        }

        public Class ClassGrpcToClass(ClassGrpc classGrpc)
        {
            Class _class = new Class();
            _class.Id = classGrpc.Id;
            _class.ClassName = classGrpc.ClassName;
            _class.Subject = classGrpc.Subject;
            return _class;
        }
    }
}
