using Account.Apis.Errors;
using Account.Core.Dtos.PropertyFolderDto;
using Account.Core.Models.Content.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface IPropertyService
    {
        Task<List<PropertyModelDTO>> GetAllPropertiesAsync();
        Task<PropertyModelDTO> GetPropertyByIdAsync(int id);
        Task<ApiResponse> CreatePropertyAsync(PropertyModelDTO propertyDto);
        Task<ApiResponse> UpdatePropertyAsync(int id, PropertyModelDTO propertyDto);
        Task<ApiResponse> DeletePropertyAsync(int id);
        Task<PropertyModel> FindByIdAsync(int id);
    }
}
