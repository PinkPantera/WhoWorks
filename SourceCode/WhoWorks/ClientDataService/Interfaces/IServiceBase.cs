using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> UpdateAsync(T model);
        Task<T> CreateAsync(T model);
        Task DeleteAsync(T model);
    }
}
