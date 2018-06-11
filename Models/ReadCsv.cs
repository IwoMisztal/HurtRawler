using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileHelpers;
namespace HurtRawler.Models
{
    [DelimitedRecord(",")]
    public class ReadCsv
    {
        public CsvRecord[] result { get; set; }
        public ReadCsv()
        {
            var engine = new FileHelperEngine<CsvRecord>();
            result = engine.ReadFile("atrax.csv");
         
        }

    }
}
