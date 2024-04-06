namespace SolidExamples.SingleResponsibility;

using System;
using System.Data.SqlClient;

public class UserManager
{
    private readonly string _connectionString;

    public UserManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Business logic method
    public void PromoteStudentToNewSemester(int userId, string nextSemester)
    {
        // Some business logic to promote student to new semester.
        Console.WriteLine("Validating and changing the user's password.");

        // Infrastructure logic to save the new password to the database
        var user=GetUserData(userId);
        
        //... some business logic
        
        ChangeStudentSemester(userId, user.currentSemester + 1);
    }

    // Infrastructure method
    private void GetUserData(int userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT ...";
            command.ExecuteNonQuery();
        }
    }
    
    private void ChangeStudentSemester(int userId, int newSemesterId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT ...";
            command.ExecuteNonQuery();
        }
    }
}