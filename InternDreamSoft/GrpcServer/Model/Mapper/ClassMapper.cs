
using Share;

namespace GrpcServer.Model.Mapper
{
    public class ClassMapper
    {
        public ClassGrpc ClassToClassGrpc(Class _class)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = _class.Id;
            classGrpc.Name = _class.Name;
            classGrpc.Subject = _class.SubjectName;
            return classGrpc;
        }
        public Class ClassGrpcToClass(ClassGrpc classGrpc)
        {
            Class _class = new Class();
            _class.Id = classGrpc.Id;
            _class.Name = classGrpc.Name;
            _class.SubjectName = classGrpc.Subject;
            return _class;
        }
    }
}
