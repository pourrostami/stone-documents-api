using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stone.Core.DTOs.AdminDTO;
using Stone.Core.DTOs.UserDTO;
using Stone.Core.Services.Interfaces;
using Stone.DataLayer.Context;
using Stone.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Core.Services
{
    public class AdminService : IAdminService
    {
        private StoneContext _context;
        private AppSettings _appSettings;

        public AdminService(StoneContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public List<ProductViewModelDto> CreatNewProduct(ProductViewModelDto productViewModelDto)
        {
            if (productViewModelDto == null)
                return null;
            _context.Products.AddAsync(new Product()
            {
                ProductTitle = productViewModelDto.ProductTitle,
                ProductImage = productViewModelDto.ProductImage,
                StartingPrice = productViewModelDto.StartingPrice,
                ProductDescription = productViewModelDto.ProductDescription
            });
            _context.SaveChanges();
            var products = _context.Products.ToList();
            List<ProductViewModelDto> listProductViewModel = new List<ProductViewModelDto>();
            foreach (var product in products)
            {
                listProductViewModel.Add(new ProductViewModelDto()
                {
                    ProductId = product.ProductId,
                    ProductImage = product.ProductImage,
                    ProductTitle = product.ProductTitle,
                    StartingPrice = product.StartingPrice,
                    ProductDescription = product.ProductDescription
                });
            }
            return listProductViewModel;
        }


        public async Task<AdminViewModelDto> Login(AdminViewModelDto adminViewModelDto)
        {
            if (adminViewModelDto == null)
                return null;
            var admin = await _context.Admins.FirstOrDefaultAsync
                    (a => a.Mobile == adminViewModelDto.Mobile && a.Password == adminViewModelDto.Password);
            if (admin != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim(ClaimTypes.Name,admin.AdminId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new AdminViewModelDto
                {
                    Email = admin.Email,
                    Mobile = admin.Mobile,
                    Password = admin.Password,
                    Token = tokenHandler.WriteToken(token)
                };
            }
            return null;
        }


        public async Task<List<ProductViewModelDto>> ListProductViewModel()
        {
            //var p = _context.Products.Select(p => new List<ProductViewModelDto>() {new ProductViewModelDto()
            //{
            //    ProductId=p.ProductId,
            //    ProductImage=p.ProductImage,
            //    ProductTitle=p.ProductTitle,
            //    StartingPrice=p.StartingPrice
            //} });
            var products = await _context.Products.ToListAsync();
            List<ProductViewModelDto> listProductViewModel = new List<ProductViewModelDto>();
            foreach (var product in products)
            {
                listProductViewModel.Add(new ProductViewModelDto()
                {
                    ProductId = product.ProductId,
                    ProductImage = product.ProductImage,
                    ProductTitle = product.ProductTitle,
                    StartingPrice = product.StartingPrice,
                    ProductDescription = product.ProductDescription
                });
            }
            return listProductViewModel;
        }

        public async Task<bool> UpdateProduct(ProductViewModelDto productViewModelDto)
        {

            var updatedProduct = await _context.Products.
                Where(p => p.ProductId == productViewModelDto.ProductId).Select(p => new Product()
                {
                    ProductId = p.ProductId,
                    ProductImage = productViewModelDto.ProductImage,
                    ProductTitle = productViewModelDto.ProductTitle,
                    StartingPrice = productViewModelDto.StartingPrice,
                    ProductDescription = productViewModelDto.ProductDescription
                }).FirstOrDefaultAsync();
            //var UpdatedProduct = new Product()
            //{
            //    ProductId = productViewModelDto.ProductId,
            //    ProductTitle = productViewModelDto.ProductTitle,
            //    StartingPrice = productViewModelDto.StartingPrice,
            //    ProductImage = productViewModelDto.ProductImage
            //};
            _context.Products.Update(updatedProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public ProductViewModelDto GetProduct(int productId)
        {

            //var product= await _context.Products.Where(p => p.ProductId == productId)
            //    .Select(p => new ProductViewModelDto()
            //{
            //    ProductId = p.ProductId,
            //    ProductImage = p.ProductImage,
            //    ProductTitle = p.ProductTitle,
            //    StartingPrice = p.StartingPrice
            //}).FirstOrDefaultAsync();

            var product = _context.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            ProductViewModelDto productVM = new ProductViewModelDto();
            productVM.ProductId = product.ProductId;
            productVM.ProductImage = product.ProductImage;
            productVM.ProductTitle = product.ProductTitle;
            productVM.StartingPrice = product.StartingPrice;
            productVM.ProductDescription = product.ProductDescription;
            return productVM;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SubProductViewModelDto>> SubProductList(int productId)
        {
            return await _context.SubProds.Where(s => s.ProductId == productId).Select(s => new SubProductViewModelDto()
            {
                height = s.height,
                Length = s.Length,
                Width = s.Width,
                ProductId = s.ProductId,
                SubProductId = s.subProdId,
                SubProductPrice = s.SubProductPrice,
                SubProductPriceDiscount = s.SubProductPriceDiscount,
                SubProductTitle = s.SubProductTitle,
                SubProductImage = s.SubProductImage,
                SubProductDescription = s.SubProductDescription
            }).ToListAsync();
        }

        public async Task<SubProductIndexViewModelDto> CreatNewSubProduct(SubProductViewModelDto subProductViewModelDto)
        {
            var newSubPod = new SubProd();
            newSubPod.height = subProductViewModelDto.height;
            newSubPod.Length = subProductViewModelDto.Length;
            newSubPod.Width = subProductViewModelDto.Width;
            newSubPod.ProductId = subProductViewModelDto.ProductId;
            newSubPod.SubProductPrice = subProductViewModelDto.SubProductPrice;
            newSubPod.SubProductPriceDiscount = subProductViewModelDto.SubProductPriceDiscount;
            newSubPod.SubProductTitle = subProductViewModelDto.SubProductTitle;
            newSubPod.SubProductDescription = subProductViewModelDto.SubProductDescription;
            newSubPod.SubProductImage = subProductViewModelDto.SubProductImage;
            await _context.SubProds.AddAsync(newSubPod);

            //_context.SubProducts.Add(newSubPod);
            await _context.SaveChangesAsync();
            var subProductList = await SubProductList(subProductViewModelDto.ProductId);
            SubProductIndexViewModelDto subProductIndexViewModelDto = new SubProductIndexViewModelDto();
            subProductIndexViewModelDto.ListSubProductViewModelDto = subProductList;
            return subProductIndexViewModelDto;


        }

        public async Task<SubProductViewModelDto> GetSubProduct(int subProductId)
        {
            var subProduct = await _context.SubProds.Where(p => p.subProdId == subProductId).FirstOrDefaultAsync();
            SubProductViewModelDto subProductVM = new SubProductViewModelDto()
            {
                height = subProduct.height,
                Length = subProduct.Length,
                ProductId = subProduct.ProductId,
                SubProductId = subProduct.subProdId,
                SubProductImage = subProduct.SubProductImage,
                SubProductPrice = subProduct.SubProductPrice,
                SubProductPriceDiscount = subProduct.SubProductPriceDiscount,
                SubProductTitle = subProduct.SubProductTitle,
                Width = subProduct.Width,
                SubProductDescription = subProduct.SubProductDescription
            };

            return subProductVM;
        }

        public async Task<bool> UpdateSubProduct(SubProductViewModelDto subProductViewModelDto)
        {
            var updatedSubProduct = await _context.SubProds.
                Where(p => p.subProdId == subProductViewModelDto.SubProductId).Select(p => new SubProd()
                {
                    subProdId = p.subProdId,
                    ProductId = p.ProductId,
                    height = subProductViewModelDto.height,
                    Length = subProductViewModelDto.Length,
                    //product = p.product,
                    SubProductImage = subProductViewModelDto.SubProductImage,
                    SubProductPrice = subProductViewModelDto.SubProductPrice,
                    SubProductPriceDiscount = subProductViewModelDto.SubProductPriceDiscount,
                    SubProductTitle = subProductViewModelDto.SubProductTitle,
                    Width = subProductViewModelDto.Width,
                    SubProductDescription = subProductViewModelDto.SubProductDescription
                }).FirstOrDefaultAsync();
            _context.SubProds.Update(updatedSubProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSubProduct(int subProductId)
        {
            var subProduct = await _context.SubProds.Where(p => p.subProdId == subProductId).FirstOrDefaultAsync();
            _context.SubProds.Remove(subProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateNewEslimi(EslimiViewModelDto eslimiViewModelDto)
        {
            if (eslimiViewModelDto == null)
                return false;
            try
            {
                await _context.EslimiDesigns.AddAsync(new EslimiDesign()
                {
                    EslimiImage = eslimiViewModelDto.EslimiImage
                });
                await _context.SaveChangesAsync();
                //await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
