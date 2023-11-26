using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1_TP2
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private CompteCourant compte;

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form1,CompteCourant compteCourant)
        {
            InitializeComponent();
            this.form1 = form1;

            compte = compteCourant;
            // Afficher les données reçues dans les étiquettes
            textBox1.Text = compte.NumeroCB;
            textBox2.Text = compte.DecouvertMaxi.ToString();

            // Pour rendre textBox en lecture seule
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
        }

        private void Créditer(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            if (form4.ShowDialog() == DialogResult.OK)
            {
                double montantACrediter = form4.Montant; // Récupérez le montant saisi dans le Form4
                compte.Créditer(montantACrediter); // Créditer le compte
                                        
                // Maintenant, appelez la méthode pour mettre à jour le solde dans Form1
                form1.MettreAJourSolde(montantACrediter);

                string message = "Crédit effectué avec succès. Le nouveau solde est de " + compte.Solde + " " + compte.Devise;
                MessageBox.Show(message, "Crédit réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Débiter(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            if (form4.ShowDialog() == DialogResult.OK)
            {
                double montantADebiter = form4.Montant; // Récupérez le montant saisi dans le Form4
                bool test = compte.Debiter(montantADebiter); // Débiter le compte
              if(test == true)
                {
                    // Maintenant, appelez la méthode pour mettre à jour le solde dans Form1
                    form1.MettreAJourSolde(montantADebiter);

                    string message = "Débit effectué avec succès. Le nouveau solde est de " + compte.Solde + " " + compte.Devise;
                    MessageBox.Show(message, "Débit réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Echec! Vous avez essayé de prendre un montant qui dépasse la limite", "Débit échoué", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
        }

        private void Description(object sender, EventArgs e)
        {
            // Créer le contenu de la boîte de dialogue
            string message = compte.Decrire();

            // Afficher la boîte de dialogue avec les données
            MessageBox.Show(message, "Données du formulaire", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
