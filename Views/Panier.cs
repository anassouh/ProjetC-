using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
    public class Panier1
    {
        public List<ArticlePanier> Articles { get; private set; }
        public Panier1()
        {
            Articles = new List<ArticlePanier>();
        }
        public void AjouterArticle(ArticlePanier article)
        {
            Articles.Add(article);
            Console.WriteLine("Article ajouté au panier.");
        }
        public void RetirerArticle(ArticlePanier article)
        {
            if (Articles.Contains(article))
            {
                Articles.Remove(article);
                Console.WriteLine("Article retiré du panier.");
            }
            else
            {
                Console.WriteLine("Article non trouvé dans le panier.");
            }
        }
        public void ViderPanier()
        {
            Articles.Clear();
            Console.WriteLine("Panier vidé.");
        }
        

    }
}
