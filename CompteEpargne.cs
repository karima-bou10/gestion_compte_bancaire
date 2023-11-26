using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1_TP2
{
    public class CompteEpargne : CompteBancaire
    {
        private double tauxInteret;
        public CompteEpargne(string leTitulaire, double soldeInitial, string laDevise, double leTauxInteret)
            : base(leTitulaire,
                   soldeInitial,
                   laDevise)
        {
            tauxInteret = leTauxInteret;
        }
        public double TauxInteret
        {
            get { return tauxInteret; }
        }
        public void AjouterInterets()
        {
            double interets = Solde * tauxInteret;
            Solde += interets;
        }

        // Redéfinition de la méthode Debiter
        public override bool Debiter(double montant)
        {
            if (montant <= Solde / 2)
            {
               Solde -= montant;
                return true;
            }
            else
            {
                return false;            }
               
        }

        public override void Créditer(double montant)
        {
            Solde += montant;
            this.AjouterInterets();
        }

        // Redéfinition de la méthode Decrire
        public override string Decrire()
        {
            return base.Decrire() + ". Son taux d'intérêt est de " +
            (tauxInteret * 100) + "%.";
        }
    }
}
