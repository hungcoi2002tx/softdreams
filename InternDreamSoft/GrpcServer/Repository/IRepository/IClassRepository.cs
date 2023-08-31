
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer
{
    public interface IClassRepository
    {
        public List<Class> GetAllClass();

        public Class GetClassById(int id);

        public int GetNewClassID();

        public void Add(Class _class);
        
        public void Delete(Class _class);

    }
}
