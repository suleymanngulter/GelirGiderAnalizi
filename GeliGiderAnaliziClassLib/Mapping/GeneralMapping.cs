using AutoMapper;
using GelirGiderAnalizi.Dtos.GiderDto;
using GelirGiderAnalizi.Dtos.GiderIslDto;
using GelirGiderAnalizi.Models;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // Gider Mapping
            CreateMap<GiderModel, GiderAddDto>().ReverseMap();
            CreateMap<GiderModel, GiderAddRangeDto>().ReverseMap();          
            CreateMap<GiderModel, GiderUpdateDto>().ReverseMap();
            CreateMap<GiderModel, GiderUpdateRangeDto>().ReverseMap();
            CreateMap<GiderModel, GiderGetByIdDto>().ReverseMap();
            CreateMap<GiderModel, GiderGetAllDto>().ReverseMap();
            CreateMap<GiderModel, GiderControlDeleteDto>().ReverseMap();
            CreateMap<GiderModel, GiderControlDeleteByIdDto>().ReverseMap();
            CreateMap<GiderModel, GiderDeleteDto>().ReverseMap();
            CreateMap<GiderModel, GiderDeleteByIdDto>().ReverseMap();
            CreateMap<GiderModel, GiderDeleteRangeDto>().ReverseMap();


            //GiderIsl Mapping
            CreateMap<GiderIslModel, GelirGiderIslemYapDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslAddDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslAddRangeDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslDeleteDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslDeleteByIdDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslDeleteRangeDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslGetAllDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslGetByIdDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslUpdateDto>().ReverseMap();
            CreateMap<GiderIslModel, GiderIslUpdateRangeDto>().ReverseMap();

        }
    }
}
