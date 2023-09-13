using GrpcServer.Model.Mapper;
using ProtoBuf.Grpc;
using Share;

namespace GrpcServer.Service
{
    public class ClassService : ClassProto
    {
        private readonly ILogger<ClassService> logger;
        private readonly IClassRepository _classRepository;
        ClassMapper classMapper = new ClassMapper();

        public ClassService(ILogger<ClassService> logger, IClassRepository classRepository)
        {
            this.logger = logger;
            _classRepository = classRepository;
        }

        public ListClasses GetListClass(Empty request, CallContext context = default)
        {
            ListClasses listClasses = new ListClasses();
            List<Class> classes = _classRepository.GetAllClass();
            foreach (var item in classes)
            {
                ClassGrpc classGrpc = classMapper.ClassToClassGrpc(item);
                listClasses.List.Add(classGrpc);
            }
            return listClasses;
        }

        public Empty AddClass(ClassGrpc request, CallContext context = default)
        {
            Class _class = classMapper.ClassGrpcToClass(request);
            _classRepository.Add(_class);
            Empty empty = new Empty();  
            return empty;
        }

        public Empty DeleteClass(ClassGrpc request, CallContext context = default)
        {
            Class _class = classMapper.ClassGrpcToClass(request);
            _classRepository.Delete(_class);
            Empty empty = new Empty();
            return empty;
        }
    }
}
