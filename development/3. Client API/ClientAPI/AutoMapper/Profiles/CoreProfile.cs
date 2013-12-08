using System;
using AutoMapper;
using ClientAPI.AutoMapper.Converters;

namespace ClientAPI.AutoMapper.Profiles
{
    public class CoreProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeConverter>();
            CreateMap<string, DateTime?>().ConvertUsing<StringToDateTimeConverter>();

            CreateMap<string, TimeSpan>().ConvertUsing<StringToTimeSpanConverter>();
            CreateMap<string, TimeSpan?>().ConvertUsing<StringToTimeSpanConverter>();
        }
    }
}