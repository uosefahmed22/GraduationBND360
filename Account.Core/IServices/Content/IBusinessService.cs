using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Models.Content.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface IBusinessService
    {
        Task<BusinessModelDto> GetByIdAsync(int id);
        Task<ApiResponse> CreateAsync(BusinessModelDto model);
        Task<ApiResponse> UpdateAsync(int id, BusinessModelDto model);
        Task<ApiResponse> DeleteAsync(int id);
        Task<BusinessModelDto> GetBusinessForBusinessOwnerAsync(string userId);
        Task<List<BusinessResponseInCategory>> GetAllBusinessesWithDetailsAsync(int categoryId);
        Task<BusinessModel> FindByIdAsync(int id);
    }
}
