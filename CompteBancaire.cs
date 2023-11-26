using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1_TP2
{
    public abstract class CompteBancaire
    {
        protected string titulaire;
        protected double solde;
        protected string devise;

        public string Titulaire
        {
            get { return titulaire; }
        }
        public double Solde
        {
            get { return solde; }
            set { solde = value; }
        }
        public string Devise
        {
            get { return devise; }
        }
        public CompteBancaire(string leTitulaire, double soldeInitial, string laDevise)
        {
            titulaire = leTitulaire;
            solde = soldeInitial;
            devise = laDevise;
        }
        // La méthode Debiter est abstraite
        public abstract bool Debiter(double montant);
      
        public virtual string Decrire()
        {
            string description = "Le solde du compte de " + Titulaire + " est de " + Solde + " " + Devise;
            return description;
        }
        public string DecrireBase()
        {
            string description = "Le solde du compte de " + Titulaire + " est de " + Solde + " " + Devise;
            return description;
        }
        public virtual void Créditer(double montant)
        {
            Solde += montant;
        }
    }
}
