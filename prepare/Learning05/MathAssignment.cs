// MathAssignment.cs
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Constructor for MathAssignment class
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic) // Call base class constructor
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method to display the homework list
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
