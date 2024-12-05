public void SecurelyModifyRegistry()
{
    try
    {
        // Check if the current user is an administrator
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

        if (!isAdmin)
        {
            throw new UnauthorizedAccessException("User does not have administrative privileges.");
        }

        // Open the registry key with write access
        Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\App", "AdminAccess", "true");

        Console.WriteLine("Set registry key AdminAccess to true securely.");
    }
    catch (UnauthorizedAccessException ex)
    {
        Console.WriteLine("Access error: " + ex.Message);
    }
    catch (SecurityException ex)
    {
        Console.WriteLine("Security error: " + ex.Message);
    }
    catch (IOException ex)
    {
        Console.WriteLine("IO error: " + ex.Message);
    }
}
