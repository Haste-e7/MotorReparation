using MotorReparation.Models.DTOs;

namespace MotorReparation.Client.Services.IServices
{
    public interface IAuthenticationService
    {
        Task<RegisterationResponseDTO> RegisterUser(UserRequestDTO userForRegisteration);

        Task<AuthenticationResponseDTO> Login(AuthenticationDTO userFromAuthentication);

        Task Logout();
    }
}
