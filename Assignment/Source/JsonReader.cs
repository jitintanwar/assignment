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
    public class JsonReader : BaseReader
    {
        public override List<StandardDTO> ReadData(string location)
        {
            try
            {
                using (StreamReader r = new StreamReader(location))
                {
                    string json = r.ReadToEnd();
                    var jsondata = JsonConvert.DeserializeObject<Root>(json);
                    return ConvertToStandardDTO(jsondata);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error reading file");
                throw ex;
            }
        }

        private List<StandardDTO> ConvertToStandardDTO(Root root)
        {
            var result = new List<StandardDTO>();
            root.products.ForEach(x => result.Add(
                new StandardDTO
                {
                    Name = x.title,
                    Categories = String.Join(", ", x.categories),
                    Twitter = x.twitter,
                }
            ));
            return result;
        }
    }
}
