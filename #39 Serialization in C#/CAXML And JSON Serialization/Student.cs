namespace CAXML_And_JSON_Serialization
{
    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public decimal GPA { get; set; }
        public List<string> FailsSubjects { get; set; } = new List<string>();
    }
}
