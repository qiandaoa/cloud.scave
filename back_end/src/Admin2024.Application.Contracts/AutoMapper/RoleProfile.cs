using Admin2024.Application.Contracts.RoleApplication.Dto;
using Admin2024.Domain.System;
using AutoMapper;

namespace Admin2024.Application.Contracts.AutoMapper;
public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleCreateInfoDto, Role>();
        CreateMap<RoleUpdateInfoDto, Role>();
    }
}