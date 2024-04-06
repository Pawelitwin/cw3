using LegacyApp;
using System;

public class UserService
{
    private ClientRepository clientRepository = new ClientRepository();
    private UserCreditService userCreditService = new UserCreditService();

    public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
    {
        if (!IsValidName(firstName, lastName) || !IsValidEmail(email) || !IsAdult(dateOfBirth))
        {
            return false;
        }

        var client = clientRepository.GetById(clientId);
        var user = CreateUser(firstName, lastName, email, dateOfBirth, client);

        SetCreditLimit(user, client);

        if (user.HasCreditLimit && user.CreditLimit < 500)
        {
            return false;
        }

        UserDataAccess.AddUser(user);
        return true;
    }

    private bool IsValidName(string firstName, string lastName)
    {
        return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
    }

    private bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    private bool IsAdult(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age >= 21;
    }

    private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
    {
        return new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
    }

    private void SetCreditLimit(User user, Client client)
    {
        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else
        {
            user.HasCreditLimit = true;
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            if (client.Type == "ImportantClient")
            {
                creditLimit = creditLimit * 2;
            }
            user.CreditLimit = creditLimit;
        }
    }
}
