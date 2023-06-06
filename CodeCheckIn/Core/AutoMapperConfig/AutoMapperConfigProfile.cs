using AutoMapper;
using CodeCheckIn.Core.Dtos.MainPage;
using CodeCheckIn.Core.Dtos.Receiver;
using CodeCheckIn.Core.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
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

            //Receiver
        //    CreateMap<ReceiverCreateDto, Receiver>();
        //    CreateMap<Receiver, ReceiverGetDto>()
        //        .ForMember(dest=>dest.From,opt=>opt.MapFrom(src=>src.MainPage.From));
        }
        }
}
