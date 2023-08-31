using BlazorFirstServerApp.Protos;
using Grpc.Core;
using GrpcServer.Model.Mapper;

namespace GrpcServer.Service
{
    public class ClassService : BlazorFirstServerApp.Protos.ClassProto.ClassProtoBase
    {
        private readonly ILogger<ClassService> logger;
        private readonly IClassRepository _classRepository;
        ClassMapper classMapper = new ClassMapper();

        public ClassService(ILogger<ClassService> logger, IClassRepository classRepository)
        {
            this.logger = logger;
            _classRepository = classRepository;
        }


        public override Task<BlazorFirstServerApp.Protos.ListClasses> GetListClass(BlazorFirstServerApp.Protos.Empty request, ServerCallContext context)
        {
            BlazorFirstServerApp.Protos.ListClasses listClasses = new BlazorFirstServerApp.Protos.ListClasses();
            List<Class> classes = _classRepository.GetAllClass();
            foreach (var item in classes)
            {
                ClassGrpc classGrpc = classMapper.ClassToClassGrpc(item);
                listClasses.List.Add(classGrpc);
            }
            return Task.FromResult(listClasses); 
        }

        public override Task<Empty> AddClass(ClassGrpc _classGrpc, ServerCallContext context)
        {
            Class _class = classMapper.ClassGrpcToClass(_classGrpc);
            _classRepository.Add(_class);
            Empty empty = new Empty();  
            return Task.FromResult(empty);
        }

        public override Task<Empty> DeleteClass(ClassGrpc _classGrpc, ServerCallContext context)
        {
            Class _class = classMapper.ClassGrpcToClass(_classGrpc);
            _classRepository.Delete(_class);
            Empty empty = new Empty();
            return Task.FromResult(empty);
        }

    }
}
