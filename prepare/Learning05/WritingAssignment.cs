// WritingAssignment.cs
public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor for WritingAssignment class
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic) // Call base class constructor
    {
        _title = title;
    }

    // Method to get writing information
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}
