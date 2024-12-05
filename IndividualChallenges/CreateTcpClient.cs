public void CreateTcpClient(string host)
{
    using (var tcpClient = new TcpClient(host, 443)) // Secure: Uses HTTPS port
    using (var sslStream = new SslStream(tcpClient.GetStream(), false))
    {
        sslStream.AuthenticateAsClient(host);
        Console.WriteLine("TCP client connected securely to: " + host);
    }
}
// aparna has fixed this
