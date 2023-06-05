using AutoMapper;
using CodeCheckIn.Core.Dtos.MainPage;
using CodeCheckIn.Core.Entities;
using System.Runtime.InteropServices;

namespace CodeCheckIn.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile: Profile
    {
        public AutoMapperConfigProfile()
        {
            //Mainpage
            CreateMap<CheckInCreateDto, MainPage>();
            CreateMap<MainPage,CheckInGetDto>();


        }
        }
}
