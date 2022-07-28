using Assignment.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Factories
{
    public class ReaderFactory
    {
        private readonly IServiceProvider serviceProvider;

        public ReaderFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public ISource? GetReader(string ImportType)
        {
            switch (ImportType)
            {
                case "yaml":
                    return serviceProvider.GetService(typeof(YamlReader)) as ISource;
                case "json":
                    return serviceProvider.GetService(typeof(JsonReader)) as ISource;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
