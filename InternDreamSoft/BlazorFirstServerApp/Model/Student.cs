using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFirstServerApp
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? Dob { get; set; }
        public virtual String Address { get; set; }
        public virtual Class ClassStudent { get; set; }
        //public virtual string ClassName { get => ClassStudent?.Name; set { } }
        public override string? ToString()
        {
            if (Dob.HasValue)
            {
                return $"{Id} - {Name} - {Dob.Value.ToString("dd/MM/yyyy")} - {Address} - Class: {ClassStudent.Name}";
            }
            else
            {
                return $"{Id} - {Name} - {Address} - Class: {ClassStudent.Name}";
            }

        }
    }
}
