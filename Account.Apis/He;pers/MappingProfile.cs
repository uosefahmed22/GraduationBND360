using Account.Core.Dtos.Content;
using Account.Core.Models.Content;
using Account.Core.Models.Content.Jobs;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobModel, JobModelDto>().ReverseMap();
        CreateMap<Contact, ContactDTO>().ReverseMap();
        CreateMap<RequirementArb, RequirementDTO>().ReverseMap();
        CreateMap<RequirementEnglish, RequirementDTO>().ReverseMap();
        CreateMap<PublisherDetails, PublisherDetailsDTO>().ReverseMap();
    }
}

