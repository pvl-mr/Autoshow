using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Views
{
    public partial class Cars : Form
    {
        //CarStorage cs = new CarStorage();
        public Cars()
        {
            InitializeComponent();
        }

        private void Cars_Load(object sender, EventArgs e)
        {
            /*List<Car> list = cs.GetList();
            dataGridViewCars.DataSource = list;
            dataGridViewCars.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCars.Columns[0].Visible = false;
            dataGridViewCars.Columns[4].Visible = false;
            dataGridViewCars.Columns[5].Visible = false;
            dataGridViewCars.Columns[6].Visible = false;*/
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
