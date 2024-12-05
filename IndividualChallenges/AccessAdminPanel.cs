using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;

public class AdminPanel
{
    private readonly IConfiguration _configuration;

    public AdminPanel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void AccessAdminPanel(string username, string password)
    {
        // Retrieve credentials from configuration
        string adminUsername = _configuration["AdminCredentials:Username"];
        string adminPassword = _configuration["AdminCredentials:Password"];

        if (username == adminUsername && password == adminPassword)
        {
            Console.WriteLine("Access to Admin Panel Granted!");
        }
        else
        {
            Console.WriteLine("Access Denied.");
        }
    }
}
