namespace BlazorFirstServerApp.Model.DTO
{
    public class StudentViewDTO
    {
        public int Stt { get; set; }

        public int Id { get; set; }

        public String Name { get; set; }

        public String Dob { get; set; }

        public String Address { get; set; }


        public String ClassName { get; set; }

        public override string? ToString()
        {
            return $"{Stt} - {Name} - {Dob} - {Address} - {ClassName}";
        }
    }
}
