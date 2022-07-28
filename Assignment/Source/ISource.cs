using Assignment.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Source
{
    public interface ISource
    {
        List<ProductDTO> ReadData(string location);
    }
}
