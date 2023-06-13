namespace RotaryClub.Data
{
    public class Status
    {
        public Status()
        {
            Success = true;
            ErrorMessage = null;
        }

        public Status(string error)
        {
            Success = false;
            ErrorMessage = error;
        }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
