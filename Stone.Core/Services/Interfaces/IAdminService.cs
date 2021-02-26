using Stone.Core.DTOs.AdminDTO;
using Stone.Core.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Core.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminViewModelDto> Login(AdminViewModelDto adminViewModelDto);
        List<ProductViewModelDto> CreatNewProduct(ProductViewModelDto productViewModelDto);
        Task<List<ProductViewModelDto>> ListProductViewModel();
        Task<bool> UpdateProduct(ProductViewModelDto productViewModelDto);
        ProductViewModelDto GetProduct(int productId);
        Task<bool> DeleteProduct(int productId);
        Task<List<SubProductViewModelDto>> SubProductList(int productId);
        Task<SubProductIndexViewModelDto> CreatNewSubProduct(SubProductViewModelDto subProductViewModelDto);
        Task<SubProductViewModelDto> GetSubProduct(int subProductId);
        Task<bool> UpdateSubProduct(SubProductViewModelDto subProductViewModelDto);
        Task<bool> DeleteSubProduct(int subProductId);
        Task<bool> CreateNewEslimi(EslimiViewModelDto eslimiViewModelDto);

    }
}
