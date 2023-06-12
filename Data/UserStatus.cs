namespace RotaryClub.Data
{
    public class UserStatus
    {
        public UserStatus()
        {
            Success = true;
            ErrorMessage = null;
        }

        public UserStatus(string error)
        {
            Success = false;
            ErrorMessage = error;
        }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
