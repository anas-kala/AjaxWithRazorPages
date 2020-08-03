using NewTry_02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewTry_02.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
    }
}
