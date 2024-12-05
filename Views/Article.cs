using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
    public class Article
    {
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }

        public Article(string nom, decimal prix, int quantite)
        {
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom: {Nom}, Prix: {Prix:C}, Quantité en stock: {Quantite}");
        }

        public void Ajouter(int quantity)
        {
            Quantite += quantity;
            Console.WriteLine($"{quantity} unités de {Nom} ajoutées au stock. Quantité totale: {Quantite}");
        }

        public void Retirer(int quantity)
        {
            if (quantity > Quantite)
            {
                Console.WriteLine($"Impossible de retirer {quantity} unités de {Nom}. Stock insuffisant.");
            }
            else
            {
                Quantite -= quantity;
                Console.WriteLine($"{quantity} unités de {Nom} retirées du stock. Quantité restante: {Quantite}");
            }
        }
    }
}
