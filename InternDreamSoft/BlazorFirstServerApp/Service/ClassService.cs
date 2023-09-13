using AntDesign.Charts;
using BlazorFirstServerApp.Model.Mapper;
using BlazorFirstServerApp.Service.IStudent;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share;
using System.Net.WebSockets;

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

        public ClassProto getService()
        {
            //var channel = GrpcChannel.ForAddress("https://localhost:7173");
            //var client = channel.CreateGrpcService<IGreeterService>();
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress($"http://localhost:5162", new GrpcChannelOptions { HttpHandler = httpHandler });
            //var channel = GrpcChannel.ForAddress("https://localhost:7173", new GrpcChannelOptions { HttpHandler = httpHandler });
            return channel.CreateGrpcService<ClassProto>();
        }

        public List<Class> GetListClass()
        {
            
            List<Class> classes = new List<Class>();           
            var client = getService();
            Empty empty = new Empty();

            var list = client.GetListClass(empty);
            foreach (var item in list.List)
            {
                Class _class = classMapper.ClassGrpcToClass(item);
                classes.Add(_class);
            }
            return classes; 
            
        }
    }
}
