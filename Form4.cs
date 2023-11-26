using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_TP2
{
    public partial class Form4 : Form
    {
        public double Montant ;
        public Form4()
        {
            InitializeComponent();
        }

        private void OK(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox1.Text, out Montant))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // L'utilisateur n'a rien saisi
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                // L'utilisateur a saisi une entrée non valide
                MessageBox.Show("Montant invalide. Veuillez saisir un nombre valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Annuler(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Définit le résultat du formulaire sur Annuler
            Close(); // Ferme le formulaire
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
