using AutoMapper;
using FightersGymAPI.Models.added;
using FightersGymAPI.ViewModel;

namespace FightersGymAPI.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<NewMemberViewModel,Member>();
        }
    }
}
