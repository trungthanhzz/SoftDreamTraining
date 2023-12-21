namespace BlazorServerApp
{
    public class StudentViewDto
    {
        public int Stt { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Dob { get; set; }

        public string Address { get; set; }


        public string ClassName { get; set; }

        public override string? ToString()
        {
            return $"{Stt} - {Name} - {Dob} - {Address} - {ClassName}";
        }
    }
}
