using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.ViewModels
{
    public class ProductVM
    {
        public IEnumerable<SelectListItem> CategoryList;

        public Product Product { get; set; }
       
        
        [ValidateNever]
        public IEnumerable<SelectListItem> Category { get; set; }


    }
}
