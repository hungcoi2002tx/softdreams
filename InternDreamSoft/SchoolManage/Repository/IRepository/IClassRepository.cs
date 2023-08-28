using SchoolManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
     interface IClassRepository
    {
        public List<Class> GetAllClass();
    }
}
