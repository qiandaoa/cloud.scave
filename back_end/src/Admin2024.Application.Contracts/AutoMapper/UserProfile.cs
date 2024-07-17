using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Domain.System;
using AutoMapper;

namespace Admin2024.Application.Contracts.AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto,User>()
        .ForMember(dest => dest.Username,opt => opt.MapFrom(src => src.Username))
        .ForMember(dest => dest.Password,opt => opt.MapFrom(src => src.Password));

        CreateMap<ResetPasswordDto,User>()
        .ForMember(dest => dest.Password,opt => opt.MapFrom(src => src.NewPassword));
    }
}