﻿using LaptopShopOnline.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaptopShopOnline.Service.Implement
{
    public class ProductService : IProductService
    {
        public IPagedList<Product> GetAll(IQueryable<Product> products, string searchString, string sortOrder, int? pageSize, int? page, dynamic ViewBag)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    products = products.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                case "PromotionPrice":
                    products = products.OrderBy(s => s.PromotionPrice);
                    break;
                case "promotion_price_desc":
                    products = products.OrderByDescending(s => s.PromotionPrice);
                    break;
                case "Quantity":
                    products = products.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    products = products.OrderByDescending(s => s.Quantity);
                    break;
                default:
                    break;
            }

            //Sort order
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.PromotionPriceSortParm = sortOrder == "PromotionPrice" ? "promotion_price_desc" : "PromotionPrice";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            //
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;

            // paging
            int pageNumber = (page ?? 1);
            int pageSizeNumber = pageSize ?? 10;
            var productsPaging = products.ToPagedList(pageNumber, pageSizeNumber);

            return productsPaging;
        }
    }
}
