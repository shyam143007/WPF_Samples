using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace MEF_Samples
{
    class Constructor_Injection_Sample
    {
        static void Main(string[] args)
        {
            //Constructor_Injection_Class sample = new Constructor_Injection_Class()
        }
    }

    class Constructor_Injection_Class
    {
        public ICountryRule CountryRule { get; set; }
        [ImportingConstructor]
        public Constructor_Injection_Class(ICountryRule countryRule)
        {
            CountryRule = countryRule;
        }
    }
}
