using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Model.Usuario
{
   

    public class Usuario
    {
        public string id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public List<int> created { get; set; }
    }

 
}
