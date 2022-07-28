using Assignment.Factories;
using Assignment.Utilities;
using DAL;

namespace Assignment
{
    public class InventoryService
    {
        private readonly IConfigRepository configRepository;
        private readonly ReaderFactory readerFactory;
        private readonly InputValidator inputValidator;

        public InventoryService(IConfigRepository configRepository, ReaderFactory readerFactory, InputValidator inputValidator)
        {
            this.configRepository = configRepository;
            this.readerFactory = readerFactory;
            this.inputValidator = inputValidator;
        }
        public async Task Process(string clientName, string FileName)
        {
            if (inputValidator.Validate(clientName, FileName))
            {
                var clientConfig = await configRepository.GetClientConfig(clientName);

                if (clientConfig != null)
                {
                    try
                    {
                        var reader = readerFactory.GetReader(clientConfig.ImportType);
                        var data = reader?.ReadData(FileName);

                        if(data != null)
                        {
                            foreach (var item in data)
                            {
                                Console.WriteLine($"importing: Name: {item.Name}; Categories: {item.Categories}; Twitter: {item.Twitter}");
                            }

                            // Persist the data; Only code skeleton.
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading data: ClientName: {clientName}, FileName: {FileName}, DateTime: {DateTime.Now}");
                    }                    
                }                
            }
        }
    }
}
