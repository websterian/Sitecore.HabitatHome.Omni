using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.Commerce.XA.Feature.Catalog.Models.JsonResults;
using Sitecore.Commerce.XA.Feature.Catalog.Repositories;
using Sitecore.Commerce.XA.Foundation.Common.Context;
using Sitecore.Commerce.XA.Foundation.Common.Models;
using Sitecore.Commerce.XA.Foundation.Connect;
using Sitecore.Diagnostics;
using Sitecore.HabitatHome.Fitness.Feature.StoreSelector.Entities;
using Sitecore.LayoutService.Mvc.Security;
using Sitecore.LayoutService.Serialization.ItemSerializers;
using Sitecore.Commerce.XA.Foundation.Common;

namespace Sitecore.HabitatHome.Fitness.Feature.StoreSelector.Controllers
{
    [RequireSscApiKey]
    [ImpersonateApiKeyUser]
    [EnableApiKeyCors]
    [SuppressFormsAuthenticationRedirect]
    public class StoresController : Controller
    {
		public ICatalogItemContainerRepository CatalogItemContainerRepository
		{
			get;
			protected set;
		}

		public ISiteContext SiteContext
		{
			get;
			protected set;
		}

		public IModelProvider ModelProvider
		{
			get;
			protected set;
		}

		public IProductListHeaderRepository ProductListHeaderRepository
		{
			get;
			protected set;
		}

		public IProductListRepository ProductListRepository
		{
			get;
			protected set;
		}

		public IPromotedProductsRepository PromotedProductsRepository
		{
			get;
			protected set;
		}

		public IProductInformationRepository ProductInformationRepository
		{
			get;
			protected set;
		}

		public IProductImagesRepository ProductImagesRepository
		{
			get;
			protected set;
		}

		public IProductInventoryRepository ProductInventoryRepository
		{
			get;
			protected set;
		}

		public IProductVariantsRepository ProductVariantsRepository
		{
			get;
			protected set;
		}

		public IProductPriceRepository ProductPriceRepository
		{
			get;
			protected set;
		}

		public IProductListPagerRepository ProductListPagerRepository
		{
			get;
			protected set;
		}

		public IProductFacetsRepository ProductFacetsRepository
		{
			get;
			protected set;
		}

		public IProductListSortingRepository ProductListSortingRepository
		{
			get;
			set;
		}

		public IProductListPageInfoRepository ProductListPageInfoRepository
		{
			get;
			set;
		}

		public IProductListItemsPerPageRepository ProductListItemsPerPageRepository
		{
			get;
			set;
		}

		public IVisitedCategoryPageRepository VisitedCategoryPageRepository
		{
			get;
			protected set;
		}

		public IVisitedProductDetailsPageRepository VisitedProductDetailsPageRepository
		{
			get;
			protected set;
		}

		public ISearchInitiatedRepository SearchInitiatedRepository;


		public StoresController(IModelProvider modelProvider, IProductListHeaderRepository productListHeaderRepository, IProductListRepository productListRepository, IPromotedProductsRepository promotedProductsRepository, IProductInformationRepository productInformationRepository, IProductImagesRepository productImagesRepository, IProductInventoryRepository productInventoryRepository, IProductPriceRepository productPriceRepository, IProductVariantsRepository productVariantsRepository, IProductListPagerRepository productListPagerRepository, IProductFacetsRepository productFacetsRepository, IProductListSortingRepository productListSortingRepository, IProductListPageInfoRepository productListPageInfoRepository, IProductListItemsPerPageRepository productListItemsPerPageRepository, ICatalogItemContainerRepository catalogItemContainerRepository, IVisitedCategoryPageRepository visitedCategoryPageRepository, IVisitedProductDetailsPageRepository visitedProductDetailsPageRepository, ISearchInitiatedRepository searchInitiatedRepository, IStorefrontContext storefrontContext, ISiteContext siteContext, IContext sitecoreContext)
        {
			Assert.ArgumentNotNull(modelProvider, "modelProvider");
			Assert.ArgumentNotNull(productListHeaderRepository, "productListHeaderRepository");
			Assert.ArgumentNotNull(productListRepository, "productListRepository");
			Assert.ArgumentNotNull(promotedProductsRepository, "promotedProductsRepository");
			Assert.ArgumentNotNull(productInformationRepository, "productInformationRepository");
			Assert.ArgumentNotNull(productImagesRepository, "productImagesRepository");
			Assert.ArgumentNotNull(productInventoryRepository, "productInventoryRepository");
			Assert.ArgumentNotNull(productPriceRepository, "productPriceRepository");
			Assert.ArgumentNotNull(productVariantsRepository, "productVariantsRepository");
			Assert.ArgumentNotNull(productListPagerRepository, "productListPagerRepository");
			Assert.ArgumentNotNull(productFacetsRepository, "productFacetsRepository");
			Assert.ArgumentNotNull(sitecoreContext, "sitecoreContext");
			Assert.ArgumentNotNull(productListSortingRepository, "productListSortingRepository");
			Assert.ArgumentNotNull(productListPageInfoRepository, "productListPageInfoRepository");
			Assert.ArgumentNotNull(productListItemsPerPageRepository, "productListItemsPerPageRepository");
			Assert.ArgumentNotNull(catalogItemContainerRepository, "catalogItemContainerRepository");
			Assert.ArgumentNotNull(searchInitiatedRepository, "searchInitiatedRepository");
			Assert.ArgumentNotNull(siteContext, "siteContext");
			ModelProvider = modelProvider;
			ProductListHeaderRepository = productListHeaderRepository;
			ProductListRepository = productListRepository;
			PromotedProductsRepository = promotedProductsRepository;
			ProductInformationRepository = productInformationRepository;
			ProductImagesRepository = productImagesRepository;
			ProductInventoryRepository = productInventoryRepository;
			ProductPriceRepository = productPriceRepository;
			ProductVariantsRepository = productVariantsRepository;
			ProductListPagerRepository = productListPagerRepository;
			ProductFacetsRepository = productFacetsRepository;
			ProductListSortingRepository = productListSortingRepository;
			ProductListPageInfoRepository = productListPageInfoRepository;
			ProductListItemsPerPageRepository = productListItemsPerPageRepository;
			CatalogItemContainerRepository = catalogItemContainerRepository;
			VisitedCategoryPageRepository = visitedCategoryPageRepository;
			VisitedProductDetailsPageRepository = visitedProductDetailsPageRepository;
			SearchInitiatedRepository = searchInitiatedRepository;
			SiteContext = siteContext;
		}

		[HttpPost]
		[ActionName("search")]
		public JsonResult GetProductList([Bind(Prefix = "q")] string searchKeyword, [Bind(Prefix = "pg")] int? pageNumber, [Bind(Prefix = "f")] string facetValues, [Bind(Prefix = "s")] string sortField, [Bind(Prefix = "ps")] int? pageSize, [Bind(Prefix = "sd")] SortDirection? sortDirection, [Bind(Prefix = "cci")] string currentCatalogItemId, [Bind(Prefix = "ci")] string currentItemId)
		{
			IVisitorContext current = VisitorContext.Current;
			ProductListJsonResult productListJsonResult = ProductListRepository.GetProductListJsonResult(current, "{06F5147B-9E24-FA33-20FB-D4B7D8D21392}"/*currentItemId*/, currentCatalogItemId, searchKeyword, pageNumber, facetValues, sortField, pageSize, sortDirection);
			return Json(productListJsonResult);
		}

		[HttpGet]
        [ActionName("Index")]
        public ActionResult Get(int take = 4)
        {
            try
            {
                List<Shop> shops = new List<Shop>();

                var shopA = new Shop
                {
                    Id = "ShopA",
                    Name = "Shop A"
                };

                var shopB = new Shop
                {
                    Id = "ShopB",
                    Name = "Shop B"
                };

                shops.Add(shopA);
                shops.Add(shopB);

                string output = JsonConvert.SerializeObject(shops);

                return Content(output, "application/json");
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve shops", ex, this);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }  
        }
    }
}