using Car.Manufacturing.Core.Interfaces;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Manufacturing.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public List<T> ReadCsvFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
