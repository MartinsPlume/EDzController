namespace EDzController.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        protected BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}