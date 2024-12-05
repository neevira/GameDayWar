public void CreateAuthCookie(string userInput)
{
    // Creating a new cookie with the user's input
    try{
        HttpCookie authCookie = new HttpCookie("auth", userInput)
    {
        HttpOnly = true,
        Secure = true
    };
    HttpContext.Current.Response.Cookies.Add(authCookie);
    Console.WriteLine("Cookie has been set.");
 catch (Exception ex){
     Console.WriteLine("An error occurred while setting the cookie.");
 }
}
