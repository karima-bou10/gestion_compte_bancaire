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
    public partial class Form1 : Form
    {
        private CompteCourant compteCourant;
        private CompteEpargne compteEpargne;
        private bool isCompteCourantSelected = true; // Par défaut, le compte courant est sélectionné

        public Form1()
        {
            InitializeComponent();

            // Créer les instances des comptes
            compteCourant = new CompteCourant("karima", 1000.00, "DH", "A100", 200.00);
            compteEpargne = new CompteEpargne("karima", 1000.00, "DH", 0.2);

            // Afficher les données dans les étiquettes
            textBox1.Text = compteCourant.Titulaire;
            textBox2.Text = compteCourant.Solde.ToString();
            textBox3.Text = compteCourant.Devise;

            // Pour rendre textBox en lecture seule
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true; 
            textBox3.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isCompteCourantSelected = true;
            //Form2 form2 = new Form2();
            Form2 form2 = new Form2(this,compteCourant);
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isCompteCourantSelected = false;
            //Form3 form3 = new Form3();
            Form3 form3 = new Form3(this,compteEpargne);
            form3.ShowDialog();
        }
        private void description(object sender, EventArgs e)
        {
            String message;
            if (isCompteCourantSelected == true)
            {
                // Appelez la méthode Decrire() de la classe de base CompteBancaire.
                // Créer le contenu de la boîte de dialogue
                message = compteCourant.DecrireBase();
            }
            else
            {
                message = compteEpargne.DecrireBase();
            }
            // Afficher la boîte de dialogue avec les données
            MessageBox.Show(message, "Données du formulaire", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MettreAJourSolde(double montantCredite)
        {   
            if(isCompteCourantSelected == true)
            {
              // Mettez à jour les étiquettes pour afficher le nouveau solde
              textBox2.Text = compteCourant.Solde.ToString();
            }
            else
            {
               // Mettez à jour les étiquettes pour afficher le nouveau solde
               textBox2.Text = compteEpargne.Solde.ToString();
            }
            
        }
    }
}
