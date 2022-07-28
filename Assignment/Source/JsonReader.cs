using Assignment.Dtos;
using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Source
{
    public class JsonReader : BaseReader<Product>
    {
        public override ProductDTO GetStandarDto(Product? x)
        {
            return new ProductDTO
            {
                Name = x.title,
                Categories = String.Join(", ", x.categories),
                Twitter = x.twitter,
            };
        }

        public override List<ProductDTO> ReadData(string location)
        {
            try
            {    
                string json = File.ReadAllText(location);
                var jsondata = JsonConvert.DeserializeObject<Root>(json);
                return ConvertToProductDTO(jsondata.products);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error reading file");
                throw;
            }
        }

        
    }
}
