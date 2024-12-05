using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
    public class ArticlePanier
    {
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }

        public ArticlePanier(string nom, decimal prix, int quantite)
        {
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
        }

        public decimal Total => Prix * Quantite; // Calcul du total pour cet article
    }

}
