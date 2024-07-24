using Admin2024.Application.Contracts.PermissionApplication.Dto;
using Admin2024.Domain.System;
using AutoMapper;

namespace Admin2024.Application.Contracts.AutoMapper;
public class PermissionProfile : Profile
{
    public PermissionProfile()
    {

        CreateMap<PerCreateInfoDto, Permission>();
        CreateMap<PerUpdateInfoDto, Permission>();

        CreateMap<OperCreateInfoDto,Operation>();
        CreateMap<OperUpdateInfoDto,Operation>();

        CreateMap<ResCreateInfoDto,Resource>();
        CreateMap<ResUpdateInfoDto,Resource>();   
    }
}