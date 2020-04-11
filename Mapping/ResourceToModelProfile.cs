using AutoMapper;
using EDzController.Controllers.V1.Resources;
using EDzController.Domain.Models.User;

namespace EDzController.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<UserCredentialsResource, User>();
        }
    }
}