using System;
using System.Collections.Generic;
using System.Text;

namespace Adopte1Dev.BLL.Entities
{
    public class CategoriesBLL
    {
        public int idCategory { get; set; }
        public string CategLabel { get; set; }
        
        // Constructeur 
        public CategoriesBLL(int IdCategory, string categLabel)
        {
            idCategory = IdCategory;
            CategLabel = categLabel;
        }
    }
}
