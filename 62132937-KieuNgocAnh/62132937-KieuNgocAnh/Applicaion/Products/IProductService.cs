﻿using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Applicaion.Products.DTO;
using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Aplicaion.Products
{
    public interface IProductService
    {
        Task<List<Product_62132937>> GetAllAsync();
        Task<Product_62132937> Add(ProductDto input );
        Task<Product_62132937> GetAsync(int id);
        Task<Product_62132937> Delete(int id);
        Task<List<Product_62132937>> Search(SearchParams param);


    }
}
