
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFirstServerApp
{
    public interface IClassRepository
    {
        public List<Class> GetAllClass();

        public Class GetClassById(int id);  
    }
}
