namespace SolidExamples.SingleResponsibility.Refactored;

public class StudentService
{
    private readonly RefactoredExample _refactoredExample;

    public StudentService(RefactoredExample refactoredExample)
    {
        _refactoredExample = refactoredExample;
    }

    public void PromoteStudentToNewSemester(int userId, string nextSemester)
    {
        // Some business logic to promote a student to a new semester.
        Console.WriteLine($"Promoting student with ID {userId} to the next semester: {nextSemester}.");

        // Call the repository to persist the change
        _refactoredExample.UpdateStudentSemester(userId, nextSemester);
    }
}

public class RefactoredExample
{
    private readonly string _connectionString;

    public RefactoredExample(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void UpdateStudentSemester(int userId, string nextSemester)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Students SET Semester = @nextSemester WHERE UserId = @userId";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@nextSemester", nextSemester);
                command.ExecuteNonQuery();
            }
        }
    }
}