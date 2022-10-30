using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MVC6.Models
{
    public class ImgViewModel
    {

       public IFormFile Imagen1 { get; set; }
        public int Id { get; set; }
        public string link { get; set; }

    }
}

