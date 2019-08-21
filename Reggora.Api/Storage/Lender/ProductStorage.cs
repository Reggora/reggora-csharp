using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Products;
using Reggora.Api.Util;
using System.Collections.Generic;

namespace Reggora.Api.Storage.Lender
{
    public class ProductStorage : Storage<Product, Api.Lender>
    {
        public ProductStorage(Api.Lender api) : base(api)
        {
        }
        public List<Product> All()
        {
            var result = new GetProductsRequest().Execute(Api.Client);
            var fetchedProducts = result.Data.Products;
            List<Product> products = new List<Product>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedProducts.Count; i++)
                {
                    Product tempProduct = new Product();
                    tempProduct.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedProducts[i]));
                    products.Add(tempProduct);
                }
            }
            return products;
        }

        public override Product Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetProductRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new Product();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data.Product));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }

        public override void Save(Product product)
        {
            
        }

        public string Create(Product product)
        {
            string response = null;
            var result = new CreateProductRequest(product).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                product.Clean();

            }

            return response;
        }

        public string Edit(Product product)
        {
            string response = "";
            var result = new EditProductRequest(product).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                product.Clean();
            }
            return response;
        }

        public string Delete(string id)
        {
            string response = null;
            var result = new DeleteProductRequest(id).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }
    }
}
