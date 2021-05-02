using BusinessLogic.BusinessLogic;
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

    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic _orderLogic;

        public FormMain(OrderLogic orderLogic)
        {
            InitializeComponent();
            this._orderLogic = orderLogic;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
/*            var form = Container.Resolve<FormPosts>();
            form.ShowDialog();*/
        }

        private void филиалToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void машинаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void работникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEmployees>();
            form.ShowDialog();
        }

        private void покупательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void LoadData()
        {
            try
            {
                var list = _orderLogic.Read(null);
                dataGridViewOrders.DataSource = list;
                dataGridViewOrders.Columns[0].Visible = false;
                dataGridViewOrders.Columns[6].Visible = false;
                dataGridViewOrders.Columns[7].Visible = false;
                dataGridViewOrders.Columns[5].Visible = false;
                dataGridViewOrders.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
