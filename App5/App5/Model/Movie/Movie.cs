using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Model.Movie
{
 
    public class Movie
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string created { get; set; }
        public List<Imagem.Image> images { get; set; }
        public List<Categoria.Category> category { get; set; }
        public int publishIn { get; set; }
    }

  
}
