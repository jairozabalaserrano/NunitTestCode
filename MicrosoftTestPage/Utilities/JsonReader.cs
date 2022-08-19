using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MicrosoftTestPage.Utilities
{
    public class JsonReader
    {
        public JObject GetDataFromJson()
        {   
            dynamic JsonFile = JsonConvert.DeserializeObject(File.ReadAllText(@"C:\Users\jairo\source\repos\MicrosoftTestPage\MicrosoftTestPage\DataDriven\MicrosoftTestData.json"));
            return JsonFile;
        }
       
    }
}
