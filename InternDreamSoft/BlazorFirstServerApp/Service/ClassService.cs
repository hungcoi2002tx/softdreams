using BlazorFirstServerApp.Model.Mapper;
using BlazorFirstServerApp.Protos;
using BlazorFirstServerApp.Service.IStudent;
using Grpc.Core;
using Grpc.Net.Client;

namespace BlazorFirstServerApp.Service
{
    public class ClassService : IClassService
    {
        ClassMapper classMapper = new ClassMapper();
        public void Add(Class _class)
        {
            ClassGrpc classGrpc = classMapper.ClassToClassGrpc(_class);
            var client = getService();
            client.AddClass(classGrpc);
        }

        public ClassProto.ClassProtoClient ClientService()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5203");
            return new ClassProto.ClassProtoClient(channel);
        }

        public void Delete(Class _class)
        {
            ClassGrpc classGrpc = classMapper.ClassToClassGrpc(_class);
            var client = getService();
            client.DeleteClass(classGrpc);
        }

        public Class GetClass(int id)
        {
            throw new NotImplementedException();
        }

        public ClassProto.ClassProtoClient getService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("https://localhost:7173", new GrpcChannelOptions { HttpHandler = httpHandler });
            return new ClassProto.ClassProtoClient(channel);
        }

        public List<Class> GetListClass()
        {
            
            List<Class> classes = new List<Class> { };           
            var client = getService();
            Empty empty = new Empty();
            ListClasses listClass = client.GetListClass(empty);
            foreach (var item in listClass.List)
            {
                Class _class = classMapper.ClassGrpcToClass(item);
                classes.Add(_class);
            }
            return classes; 
        }

    }
}
