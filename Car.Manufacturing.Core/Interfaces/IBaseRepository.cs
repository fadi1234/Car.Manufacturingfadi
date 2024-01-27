using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Manufacturing.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> ReadCsvFile(string filePath);
    }
}
