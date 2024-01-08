using AutoMapper;
using GrantAdvance.Domain.Models;
using GrantAdvance.Domain.ViewModel;

namespace GrantAdvance.API.Mapping
{
    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<UserResourceViewModel, User>();
        }
    }
}
