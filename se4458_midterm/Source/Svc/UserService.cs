using Microsoft.IdentityModel.Tokens;
using se4458_midterm.Context;
using se4458_midterm.Models;
using se4458_midterm.Models.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace se4458_midterm.Source.Svc
{
    public class UserService : IUserService
    {
        private readonly AirlineDbContext _airlineDb;
        private string secretKey;

        public UserService(AirlineDbContext airlineDb, IConfiguration configuration)
        {
            _airlineDb = airlineDb;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            
        }

        public bool IsUserUnique(string userName)
        {
            var user  = _airlineDb.Users.FirstOrDefault(u => u.UserName == userName);

            if(user == null)
            {
                return true;
            }

            return false;
        }

        public LoginResponseDTO Login(LoginReguestDTO loginReguestDTO)
        {
            var user = _airlineDb.Users.FirstOrDefault(u => u.UserName == loginReguestDTO.UserName && u.Password == loginReguestDTO.Password);

            if(user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    APIUser = null
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                APIUser = user,
            };

            return loginResponseDTO;

        }

        public User Register(RegisterationRequestDTO reqisterationRequestDTO)
        {
            User user = new User()
            {
                UserName = reqisterationRequestDTO.UserName,
                Name = reqisterationRequestDTO.Name,
                Password = reqisterationRequestDTO.Password,
                Role = reqisterationRequestDTO.Role,
            };

            _airlineDb.Users.Add(user);
            _airlineDb.SaveChanges();

            user.Password = "";

            return user;

        }
    }
}
