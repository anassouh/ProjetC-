using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
    public class ArticleType
    {
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public TypeArticle Type { get; set; }

        public ArticleType(string nom, decimal prix, int quantite, TypeArticle type)
        {
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
            Type = type;
        }
    }

    public enum TypeArticle
    {
        Alimentaire,
        Droguerie,
        Habillement,
        Loisir
    }

}

