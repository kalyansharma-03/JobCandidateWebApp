using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Infrastructure.Repository
{
    public interface IServiceFactory
    {
        IServiceRepository<T> GetInstance<T>() where T : class;

    }
}
