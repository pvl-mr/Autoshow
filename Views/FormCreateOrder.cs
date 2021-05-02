using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace Views
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic _logicOrder;
        private readonly CarLogic _logicC;
        private readonly CustomerLogic _logicP;
        private readonly EmployeeLogic _logicE;
        public FormCreateOrder(CarLogic logicF, CustomerLogic logicO, EmployeeLogic logicC, OrderLogic or)
        {
            InitializeComponent();
            _logicC = logicF;
            _logicP = logicO;
            _logicE = logicC;
            _logicOrder = or;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _logicC.Read(null);
                if (list != null)
                {
                    comboBoxCar.DataSource = list;
                    comboBoxCar.DisplayMember = "Model";
                    comboBoxCar.ValueMember = "Id";
                    comboBoxCar.SelectedItem = null;
                }
                var listClients = _logicP.Read(null);
                foreach (var client in listClients)
                {
                    comboBoxClient.DataSource = listClients;
                    comboBoxClient.DisplayMember = "FirstName";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.SelectedItem = null;
                }
                var listE = _logicE.Read(null);
                if (listE != null)
                {
                    comboBoxEmployee.DataSource = listE;
                    comboBoxEmployee.DisplayMember = "FirstName";
                    comboBoxEmployee.ValueMember = "Id";
                    comboBoxEmployee.SelectedItem = null;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicOrder.CreateOrder(new OrderBindingModel
                {
                    CustomerId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    CarId = Convert.ToInt32(comboBoxCar.SelectedValue),
                    EmployeeId = Convert.ToInt32(comboBoxEmployee.SelectedValue),
                    Date = DateTime.Now
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
