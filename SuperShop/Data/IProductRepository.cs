using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public interface IProductRepository: IGenericRepository<Product>
    {
    }
}
