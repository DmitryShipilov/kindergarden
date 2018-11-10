using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kindergarden
{
    public partial class inForm : Form
    {
        public inForm()
        {
            InitializeComponent();
        }

        private void inForm_Load(object sender, EventArgs e)
        {

        }

        private void newChildButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            addForm addForm = new addForm();
            addForm.Show();
        }

        private void showListButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            showListForm showListForm = new showListForm();
            showListForm.Show();
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
