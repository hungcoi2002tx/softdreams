namespace GrpcServer.Model
{
    public class StudentSearch
    {
        public String Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public String Address { get; set; }

        public int ClassID { get; set; } = -1;
        public int Id { get; set; } = -1;

        public int Months { get; set; }

        public StudentSearch() {

        }

    }
}
