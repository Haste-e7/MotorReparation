namespace MotorReparation.Models.DTOs
{
    public class RegisterationResponseDTO
    {
        public bool IsRegisterationSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
