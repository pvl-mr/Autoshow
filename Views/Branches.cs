using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class Branches : Form
    {
       // BranchStorage bs = new BranchStorage();

        public Branches()
        {
            InitializeComponent();
        }

        private void Branches_Load(object sender, EventArgs e)
        {
           /* List<Branch> list = bs.GetList();
            dataGridViewBranches.DataSource = list;
            dataGridViewBranches.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBranches.Columns[0].Visible = false;
            dataGridViewBranches.Columns[3].Visible = false;*/
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
