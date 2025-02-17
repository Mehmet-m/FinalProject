﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.İnMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ProductId = 1, CategoryId= 1, ProductName="Bardak", UnitPrice=15,UnitsİnStock= 15 },
            new Product{ProductId = 2, CategoryId= 1, ProductName="Kamere", UnitPrice=500,UnitsİnStock= 3 },
            new Product{ProductId = 3, CategoryId= 2, ProductName="Telefon", UnitPrice=1500,UnitsİnStock= 2 },
            new Product{ProductId = 4, CategoryId= 2, ProductName="Klavye", UnitPrice=150,UnitsİnStock= 65 },
            new Product{ProductId = 5, CategoryId= 2, ProductName="Fare", UnitPrice=85,UnitsİnStock= 1 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ =Language Integrated Query

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //gönderdiğim üürün ıd'sine sahip olan listedeki ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsİnStock = product.UnitsİnStock;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
