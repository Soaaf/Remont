using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remont
{
    public partial class Masterskay : Form
    {
        public Masterskay()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sotrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sotr newForm = new Sotr();
            newForm.Show ();

        }

        private void price_Click(object sender, EventArgs e)
        {
            Price newForm = new Price();
            newForm.Show();
        }

        private void remont_Click(object sender, EventArgs e)
        {
            Remont newForm = new Remont();
            newForm.Show();
        }

        private void avto_Click(object sender, EventArgs e)
        {
            Avto newForm = new Avto();
            newForm.Show();
        }

        private void spisok_sotr_Click(object sender, EventArgs e)
        {
            Spisok_sotr newForm = new Spisok_sotr();
            newForm.Show();
        }

        private void vipolnenie_Click(object sender, EventArgs e)
        {
            Vipolnenie newForm = new Vipolnenie();
            newForm.Show();
        }

        private void reiting_Click(object sender, EventArgs e)
        {
            Reiting newForm = new Reiting();
            newForm.Show();
        }

        
    }
}
