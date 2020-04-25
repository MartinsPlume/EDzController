using EDzController.Domain.Models;

namespace EDzController.Domain.Services.Communication
{
    public class GetUserResponse : BaseResponse
    {
        public User User { get; }
        public GetUserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }
    }
}
