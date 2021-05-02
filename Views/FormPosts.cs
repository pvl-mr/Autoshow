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

namespace Views
{
    public partial class FormPosts : Form
    {
        private readonly PostLogic logic;
        public FormPosts(PostLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void Posts_Load(object sender, EventArgs e)
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                   
                    dataGridViewPosts.DataSource = list;
                    dataGridViewPosts.Columns[0].Visible = true;
                    dataGridViewPosts.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
