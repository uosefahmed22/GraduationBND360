using Account.Core.Dtos;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Dtos.PropertyFolderDto;
using Account.Core.Models.Content;
using Account.Core.Models.Content.Jobs;
using Account.Core.Models.Content.Properties;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobModel, JobModelDto>().ReverseMap();
        CreateMap<JobContact, ContactDTO>().ReverseMap();
        CreateMap<PropertyContact, PropertyContactDto>().ReverseMap();
        CreateMap<RequirementArb, RequirementDTO>().ReverseMap();
        CreateMap<RequirementEnglish, RequirementDTO>().ReverseMap();
        CreateMap<PublisherDetails, PublisherDetailsDTO>().ReverseMap();
        CreateMap<PropertyModel, PropertyModelDTO>().ReverseMap();
        CreateMap<ImageNamesModel, ImageNamesModelDto>().ReverseMap();
    }
}

