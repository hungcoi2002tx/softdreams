﻿using ProtoBuf.Grpc;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Share;

[DataContract]
public class Empty
{

}

[DataContract]
public class ClassGrpc
{
    [DataMember(Order = 1)]
    public int Id { get;set; }
    [DataMember(Order = 2)]
    public string Name { get;set; }
    
    [DataMember(Order = 3)]
    public string Subject { get; set; }  
    
    [DataMember(Order = 4)]
    public int TeacherId { get;set; }
}
[DataContract]
public class ListClasses
{
    [DataMember(Order = 1)]
    public List<ClassGrpc> List = new List<ClassGrpc>();   
}

[ServiceContract]
public interface ClassProto
{
    [OperationContract]
    ListClasses GetListClass(Empty request,
        CallContext context = default);
    [OperationContract]
    Empty AddClass(ClassGrpc request,
        CallContext context = default);
    [OperationContract]
    Empty DeleteClass(ClassGrpc request,
        CallContext context = default);
}