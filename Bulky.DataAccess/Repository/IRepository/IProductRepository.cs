using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.Models;
using Bulky.Models.Models;
using BulkyBook.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {

        void update(Product obj);

    }
}
