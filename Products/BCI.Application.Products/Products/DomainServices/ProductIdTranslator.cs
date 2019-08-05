﻿using System;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Application.Products.DomainServices
{
    public class ProductIdTranslator : ITranslator<ProductId, string>
    {
        public ProductId Translate(string input)
        {
            string[] idString = input.Split("-");
            idString[1] = idString[1].Insert(4, "/").Insert(7, "/");
            return new ProductId(int.Parse(idString[2]), DateTimeOffset.Parse(idString[1]));
        }
    }
}