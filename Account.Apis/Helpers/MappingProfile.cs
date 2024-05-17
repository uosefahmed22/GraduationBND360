using Account.Core.Dtos;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.CategoriesDto;
using Account.Core.Dtos.CraftsFolder;
using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Dtos.FavoirteDto;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Dtos.PropertyFolderDto;
using Account.Core.Dtos.Saved;
using Account.Core.Models.Content;
using Account.Core.Models.Content.Business;
using Account.Core.Models.Content.Categories;
using Account.Core.Models.Content.Crafts;
using Account.Core.Models.Content.CraftsMen;
using Account.Core.Models.Content.Favorite;
using Account.Core.Models.Content.Jobs;
using Account.Core.Models.Content.Properties;
using Account.Core.Models.Content.Saved;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobModel, JobModelDto>().ReverseMap();
        CreateMap<RequirementArb, RequirementDTO>().ReverseMap();
        CreateMap<RequirementEnglish, RequirementDTO>().ReverseMap();
        CreateMap<PublisherDetails, PublisherDetailsDTO>().ReverseMap();
        CreateMap<PropertyModel, PropertyModelDTO>().ReverseMap();
        CreateMap<CategoriesModel, CategoriesModelDTO>()
        .ForMember(dest => dest.Image, opt => opt.Ignore()).ReverseMap();
        CreateMap<BusinessModel, BusinessModelDto>().ReverseMap();
        CreateMap<CraftsModel, CraftsModelDto>().ReverseMap();
        CreateMap<CraftsMenModel, CraftsMenModelDto>().ReverseMap();
        CreateMap<SavedModelForProperty, SavedModelForPropertyDto>().ReverseMap();
        CreateMap<SavedModelForJobs, SavedModelForJobsDto>().ReverseMap();
        CreateMap<FavoriteModelForBusiness, FavoriteModelForBusinessDto>().ReverseMap();
        CreateMap<FavoriteModelForCraftsmen, FavoriteModelForCraftsmenDto>().ReverseMap();



    }
}

