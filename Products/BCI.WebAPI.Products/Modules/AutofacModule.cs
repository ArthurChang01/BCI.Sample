using Autofac;
using BCI.Products.Application.Categories.DataContracts.ViewModels;
using BCI.Products.Application.Categories.DomainServices;
using BCI.Products.Application.Categories.Repositories;
using BCI.Products.Application.Products.DataContracts.ViewModels;
using BCI.Products.Application.Products.DomainServices;
using BCI.Products.Application.Products.Repositories;
using BCI.Products.Domain.Categories.Interfaces;
using BCI.Products.Domain.Categories.Models;
using BCI.Products.Domain.Products.Interfaces;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.WebAPI.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryIdTranslator>().As<ITranslator<CategoryId, string>>();
            builder.RegisterType<CategoryRMTranslator>().As<ITranslator<CategoryRM, Category>>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<ProductIdTranslator>().As<ITranslator<ProductId, string>>();
            builder.RegisterType<ProductRMTranslator>().As<ITranslator<ProductVM, Product>>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
        }
    }
}