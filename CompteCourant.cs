using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1_TP2
{
    public class CompteCourant : CompteBancaire
    {
        private string numeroCB;
        private double decouvertMaxi;
        public CompteCourant(string leTitulaire, double soldeInitial, string
        laDevise, string numeroCB, double decouvertMaxi)
        : base(leTitulaire, soldeInitial, laDevise)
        {
            this.numeroCB = numeroCB;
            this.decouvertMaxi = decouvertMaxi;
        }
        public string NumeroCB
        {
            get { return numeroCB; }
        }
        public double DecouvertMaxi
        {
            get { return decouvertMaxi; }
        }
        // Redéfinition de la méthode Debiter
        public override bool Debiter(double montant)
        {
            if (Solde - montant >= decouvertMaxi)
            {
             Solde -= montant;
                return true;
            }
            else
            {
                return false;
            }
               
        }

        // Redéfinition de la méthode Decrire
        public override string Decrire()
        {
            return base.Decrire() + ". Son numéro CB est " + numeroCB +
            " et son découvert maxi est de " + decouvertMaxi + " " +
            Devise + ".";
        }
    }
}
