using Assignment.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Source
{
    public abstract class BaseReader<T> : ISource
    {
        public abstract List<ProductDTO> ReadData(string location);

        public List<ProductDTO> ConvertToProductDTO(List<T> mapping)
        {
            var result = new List<ProductDTO>();
            mapping.ForEach(x => result.Add(GetStandarDto(x)));
            return result;
        }

        public abstract ProductDTO GetStandarDto(T? x);        

        public BaseReader()
        {
            // Do basic initialization, if any
        }
    }
}
