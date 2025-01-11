using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public  class Baseclass
    {
        public static IConfiguration Configuration { get; private set; }

        
        static Baseclass()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("specflow.json", optional: false, reloadOnChange: true) 
                .Build();
        }
        
    }
}
