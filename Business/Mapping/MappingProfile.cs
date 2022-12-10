using AutoMapper;
using DataLayerAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelRoomDto, HotelRoom>().ReverseMap(); 
            CreateMap<HotelRoomImage, HotelRoomImageDto>().ReverseMap();
        }
    }
}
