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
    public class YamlReader : BaseReader
    {
        public override List<StandardDTO> ReadData(string location)
        {
            try
            {
                var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

                var myConfig = deserializer.Deserialize<List<YamlRoot>>(File.ReadAllText(location));
                return ConvertToStandardDTO(myConfig);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file");
                throw ex;
            }
        }

        private List<StandardDTO> ConvertToStandardDTO(List<YamlRoot> mapping)
        {
            var result = new List<StandardDTO>();
            mapping.ForEach(x => result.Add(new StandardDTO
            {
                Name = x.name,
                Categories = String.Join(", ", x.tags),
                Twitter = x.twitter,
            }
            ));
            return result;
        }
    }

    public class YamlRoot
    {
        public string tags { get; set; }
        public string name { get; set; }
        public string twitter { get; set; }
    }
}
