public void AddUserInputToCookie(string userInput)
{
    // Sanitize the user input
    string sanitizedInput = SanitizeInput(userInput);

    // Validate the sanitized input
    if (IsValidInput(sanitizedInput))
    {
        // Create a new cookie with secure attributes
        HttpCookie cookie = new HttpCookie("SessionID", sanitizedInput)
        {
            HttpOnly = true, // Prevents client-side scripts from accessing the cookie
            Secure = true,   // Ensures the cookie is sent over HTTPS
            SameSite = SameSiteMode.Strict // Prevents the cookie from being sent with cross-site requests
        };

        // Add the cookie to the response
        Response.Cookies.Add(cookie);
        Console.WriteLine("Cookie added with user input: " + sanitizedInput);
    }
    else
    {
        Console.WriteLine("Invalid user input: " + userInput);
    }
}

private string SanitizeInput(string input)
{
    // Example sanitization logic (you can customize this as needed)
    return input.Replace("<", "").Replace(">", "").Replace("'", "").Replace("\"", "");
}

private bool IsValidInput(string input)
{
    // Example validation logic (you can customize this as needed)
    return !string.IsNullOrEmpty(input) && input.Length <= 100; // Example: input should not be empty and should be less than 100 characters
}
