using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Http;
using System.Configuration;

namespace VulnerableWebAPI.Controllers
{
    [RoutePrefix("api/secure")]
    public class SecureController : ApiController
    {
        // Secure Database Connection String (Vulnerability #3 fixed)
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SecureDB"].ConnectionString;

        // Secure endpoint to fetch user data
        [HttpGet]
        [Route("getUserData")]
        public IHttpActionResult GetUserData(string userId)
        {
            try
            {
                // Parameterized Query to prevent SQL Injection (Vulnerability #1 fixed)
                string query = "SELECT * FROM Users WHERE UserId = @UserId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return Ok(new
                        {
                            UserId = reader["UserId"],
                            Name = reader["Name"],
                            Email = reader["Email"]
                        });
                    }
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                // Proper Error Handling (Vulnerability #4 fixed)
                return InternalServerError(new Exception("An error occurred while fetching user data."));
            }
        }

        // Secure endpoint to access files
        [HttpGet]
        [Route("getFile")]
        public IHttpActionResult GetFile(string fileName)
        {
            try
            {
                // Validate file name to prevent Insecure Direct Object Reference (Vulnerability #2 fixed)
                if (string.IsNullOrWhiteSpace(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    return BadRequest("Invalid file name.");
                }

                string filePath = Path.Combine("C:\\SecureFiles\\", fileName);

                // Restrict file access to specific directory (Vulnerability #5 fixed)
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    return Ok(new { FileName = fileName, Content = content });
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("An error occurred while accessing the file."));
            }
        }

        // Secure debug endpoint
        [HttpGet]
        [Route("debug")]
        public IHttpActionResult Debug()
        {
            // Remove sensitive information from debug endpoint (Vulnerability #6 fixed)
            return Ok(new
            {
                Environment = "Production",
                Message = "Debug information is not available in production."
            });
        }
    }
}
