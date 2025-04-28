using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ErrorModels
{
    public class ErrorToReturn
    {
        public string ErrorMessage { get; set; }=default!;
        public int StatusCode { get; set; } 
    }
}
