namespace StudentApi.Models
{
    public class Student
    {
        public int Id { get; set; }          // Primary Key
        public string Name { get; set; }     // Student name
        public int Age { get; set; }         // Student age
        public string Course { get; set; }   // Course enrolled
    }
}
