using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Manufacturing.Core.Interfaces
{
    public interface IApiRepository
    {
        Task<string> GetURL(Uri Url);

    }
}
