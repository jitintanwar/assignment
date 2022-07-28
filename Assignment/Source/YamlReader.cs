using Assignment.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Assignment.Source
{
    public class YamlReader : BaseReader<YamlRoot>
    {
        public override ProductDTO GetStandarDto(YamlRoot? x)
        {
            return new ProductDTO { Categories = x.tags, Name = x.name , Twitter = x.twitter};   
        }

        public override List<ProductDTO> ReadData(string location)
        {
            try
            {
                var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

                var myConfig = deserializer.Deserialize<List<YamlRoot>>(File.ReadAllText(location));
                return ConvertToProductDTO(myConfig);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file");
                throw;
            }
        }

         
    }

    public class YamlRoot
    {
        public string tags { get; set; }
        public string name { get; set; }
        public string twitter { get; set; }
    }
}
