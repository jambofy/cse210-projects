// Assignment.cs
public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor for the base class
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return the summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Optional: Public method to access the student name (for derived classes)
    public string GetStudentName()
    {
        return _studentName;
    }
}
