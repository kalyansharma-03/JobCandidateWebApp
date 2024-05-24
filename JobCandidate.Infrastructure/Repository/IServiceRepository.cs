using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Infrastructure.Repository
{
    public interface IServiceRepository<t>
    {
        Task<t> FindAsync(string email);

        Task<t> AddAsync(t model);


        Task<t> UpdateAsync(t model);
    }
}
