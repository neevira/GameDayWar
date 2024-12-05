public void DeleteFile(string userInput)
{
    try
    {
        // Validate input
        if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Invalid file path.");
            return;
        }

        // Get the absolute path and check if it is within a safe directory
        string rootPath = @"C:\SafeDirectory";
        string fullPath = Path.GetFullPath(userInput);

        if (!fullPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Unauthorized file path.");
            return;
        }

        // Check if the file exists
        if (!File.Exists(fullPath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        // Delete the file
        File.Delete(fullPath);
        Console.WriteLine($"Deleted file: {fullPath}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting file: {ex.Message}");
    }
}
