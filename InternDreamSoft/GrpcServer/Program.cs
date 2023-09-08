using GrpcServer.Service;
using GrpcServer.Services;
using System.Net;

namespace GrpcServer
{
    public class Program { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenAnyIP(8080);
            //    options.ListenAnyIP(7173, listenOptions =>
            //    {
            //        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
            //    });
            //});
            //// Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
            builder.Services.AddSingleton<NHibernate.ISessionFactory>(NHibernateConfig.BuildSessionFactory());
            builder.Services.AddSingleton<IClassRepository, ClassRepository>();
            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<ClassService>();
           
            app.MapGet("/", () => "ĐÂY LÀ GRPC SERVICE XIN VUI LÒNG KHÔNG TRUY CẬP TRỰC TIẾP abc");

            app.Run();
        }
    }
}