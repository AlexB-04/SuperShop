using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        public IQueryable GetAllWithUsers();
        IEnumerable<SelectListItem> GetComboProducts();
    }
}
