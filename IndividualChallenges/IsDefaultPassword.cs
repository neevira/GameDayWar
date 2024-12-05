public bool IsDefaultPassword(string password)
{
    if (string.IsNullOrWhiteSpace(password))
    {
        throw new ArgumentException("Password cannot be null or whitespace.");
    }

    // Securely stored hash of the default password (example hash for "default").
    string defaultPasswordHash = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3";

    // Compute the hash of the input password.
    using (SHA1 sha1 = SHA1.Create())
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = sha1.ComputeHash(passwordBytes);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }

        // Compare the hashes securely.
        return string.Equals(sb.ToString(), defaultPasswordHash, StringComparison.OrdinalIgnoreCase);
    }
}
