public void HashWithMD5(byte[] data)
{
    byte[] dataBytes = Encoding.UTF8.GetBytes(data); 

    using (SHA256 sha256 = SHA256.Create()) 

    { 
        byte[] hashBytes = sha256.ComputeHash(dataBytes); 

        string hash = Convert.ToBase64String(hashBytes); 
        Console.WriteLine($" Hash: {Convert.ToHexString(hash)}");

    } 
}
