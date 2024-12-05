using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Views
{
    public enum EtatCommande
    {
        EnAttente,
        Validee,
        Annulee
    }

    public class Commande
    {
        public int IdCommande { get; private set; }
        public List<Panier> Paniers { get; private set; }
        public EtatCommande Etat { get; private set; }

        public Commande(int idCommande)
        {
            IdCommande = idCommande;
            Paniers = new List<Panier>();
            Etat = EtatCommande.EnAttente;
        }

        public void AjouterPanier(Panier panier)
        {
            if (Etat != EtatCommande.EnAttente)
            {
                Console.WriteLine("Impossible d'ajouter un panier. La commande n'est pas en attente.");
                return;
            }

            Paniers.Add(panier);
            Console.WriteLine("Panier ajouté avec succès à la commande.");
        }

        public void ValiderCommande()
        {
            if (Etat == EtatCommande.EnAttente)
            {
                Etat = EtatCommande.Validee;
                Console.WriteLine("Commande validée.");
            }
            else
            {
                Console.WriteLine("Commande non valide ou déjà traitée.");
            }
        }

        public void AnnulerCommande()
        {
            if (Etat == EtatCommande.EnAttente)
            {
                Etat = EtatCommande.Annulee;
                Console.WriteLine("Commande annulée.");
            }
            else
            {
                Console.WriteLine("Commande déjà traitée et ne peut être annulée.");
            }
        }
    }

    public class Panier
    {
        public string Nom { get; set; }
        public decimal Total { get; set; }

        public Panier(string nom, decimal total)
        {
            Nom = nom;
            Total = total;
        }
    }
}
