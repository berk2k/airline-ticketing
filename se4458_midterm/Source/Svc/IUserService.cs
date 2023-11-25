using se4458_midterm.Models;
using se4458_midterm.Models.Dto;

namespace se4458_midterm.Source.Svc
{
    public interface IUserService
    {
        bool IsUserUnique(string userName);

        public LoginResponseDTO Login(LoginReguestDTO loginReguestDTO);

        public User Register(RegisterationRequestDTO reqisterationRequestDTO);

    }
}
