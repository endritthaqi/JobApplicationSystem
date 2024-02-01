using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem.Application.Responses
{
    public class JwtResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
        public List<string> UserRoles { get; set; }

        public JwtResponse(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public JwtResponse(int status, string message, string token, DateTime expiration, string userId, List<string> userRoles)
        {
            Status = status;
            Message = message;
            Token = token;
            Expiration = expiration;
            UserId = userId;
            UserRoles = userRoles;
        }

    }
}
