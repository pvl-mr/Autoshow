using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogic;
using BusinessLogic.ViewModels;
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
    public partial class FormEmployee : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private int? id;
        public int Id { set { id = value; } }

        private readonly EmployeeLogic employeeLogic;
        private readonly BranchLogic _branchLogic;
        private readonly PostLogic _postLogic;

        public FormEmployee(EmployeeLogic employeeLogic, BranchLogic branchLogic, PostLogic postLogic)
        {
            InitializeComponent();
            this.employeeLogic = employeeLogic;
            _branchLogic = branchLogic;
            _postLogic = postLogic;
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            List<BranchViewModel> list = _branchLogic.Read(null);
            if (list != null)
            {
                comboBox.DisplayMember = "BranchName";
                comboBox.ValueMember = "Id";
                comboBox.DataSource = list;
                comboBox.SelectedItem = null;
            }
            List<PostViewModel> listPosts = _postLogic.Read(null);
            if (listPosts != null)
            {
                comboBoxPosts.DisplayMember = "PostName";
                comboBoxPosts.ValueMember = "Id";
                comboBoxPosts.DataSource = listPosts;
                comboBoxPosts.SelectedItem = null;
            }
            if (id.HasValue)
            {
                try
                {
                    EmployeeViewModel view = employeeLogic.Read(new EmployeeBindingModel { Id = id.Value })?[0];

                    if (view != null)
                    {
                        textBoxName.Text = view.FirstName;
                        textBoxLastName.Text = view.LastName;
                        comboBox.SelectedValue = view.BranchId;
                        comboBoxPosts.SelectedValue = view.PostId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните поле \"ФИО\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                employeeLogic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = id,
                    FirstName = textBoxName.Text,
                    LastName = textBoxLastName.Text,
                    BranchId = Convert.ToInt32(comboBox.SelectedValue),
                    PostId = Convert.ToInt32(comboBoxPosts.SelectedValue),
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }
    }
}
