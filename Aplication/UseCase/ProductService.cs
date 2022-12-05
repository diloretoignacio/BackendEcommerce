using Aplication.Interfaces.IClient;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using Aplication.Interfaces.IProduct;
using Aplication.Mappers;

namespace Aplication.UseCase
{
    public class ProductService : IProductService
    {
        private readonly IProductQuery _query;

        public ProductService(IProductQuery query)
        {
            _query = query;
        }

        public ResponseGral GetByName(string name, bool sort)
        {
            var products = _query.GetByName(name, sort);

            if(products.Count == 0)
            {
                return new ResponseGral(404, new { Message = "El Prodcuto indicado NO existe" });
            }

            List<ProductResponse> result = new List<ProductResponse>();

            foreach (Producto product in products)
            {
                var response = Mapper.MapperProduct(product);

                result.Add(response);
            }
            return new ResponseGral(200, result);
        }

        public ResponseGral GetById(int id)
        {
            var product = _query.GetById(id);

            if (product == null)
            {
                return new ResponseGral(404, new { Message = "El Prodcuto indicado NO existe" });
            }

            ProductResponse response = Mapper.MapperProduct(product);
            return new ResponseGral(200, response);
        }

    }
}
