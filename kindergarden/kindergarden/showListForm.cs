using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace kindergarden
{
    public partial class showListForm : Form
    {
        public showListForm()
        {
            InitializeComponent();
        }

        List<string> ColumnVals = new List<string>();
        List<string> ColumnIndex = new List<string>();
        DataTable dt = new DataTable();
        private void showListForm_Load(object sender, EventArgs e)
        {
            this.comboShow("street");

        }

        private void backToForm1_Click(object sender, EventArgs e)
        {
            this.Hide();

            inForm inForm = new inForm();
            inForm.Show();
        }

        private void showAll_Click(object sender, EventArgs e)  //показать всех детей
        {
            dt.Clear() ;
            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
            string query = " select u_id, surname.f_val, name.f_val, patronymic.f_val, street.f_val, telephone.f_val, " +
                           " grup, visit, pay, debt from main " +
                           " inner join surname on main.surname = surname.f_id " +
                           " inner join name on main.name = name.f_id " +
                           " inner join street on main.street = street.f_id " +
                           " inner join patronymic on main.patronymic = patronymic.f_id" +
                           " inner join telephone on main.telephone = telephone.f_id; ";
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();

            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, connection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

            dt.Load(npgSqlDataReader);
            dataGridView.DataSource = dt;
            dataGridView.Sort(dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            connection.Close();

            // column names
            dataGridView.Columns[0].HeaderText = "Номер";
            dataGridView.Columns[1].HeaderText = "Фамилия";
            dataGridView.Columns[2].HeaderText = "Имя";
            dataGridView.Columns[3].HeaderText = "Отчество";
            dataGridView.Columns[4].HeaderText = "Улица";
            dataGridView.Columns[5].HeaderText = "Номер родителей";
            dataGridView.Columns[6].HeaderText = "Группа";
            dataGridView.Columns[7].HeaderText = "Число посещений";
            dataGridView.Columns[8].HeaderText = "Статус оплаты";
            dataGridView.Columns[9].HeaderText = "Задолжность";

            //reset filters
            /*comboBoxFilterName.SelectedItem = null;
            comboBoxFilterSurname.SelectedItem = null;
            comboBoxFilterStreet.SelectedItem = null;
            comboBoxFilterPatr.SelectedItem = null;*/

            dataGridView.Show();
        }

        private void paid_Click(object sender, EventArgs e)
        {
            try
            {
                
                int x = dataGridView.CurrentCell.RowIndex;

                if (dataGridView[7, x].Value.ToString() != "")
                {
                    string id = (dataGridView[0, x].Value.ToString());
                    string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                    string query = "update main set pay = 'Оплачено' where u_id = " + id + ";";
                    query += string.Format(" update main set debt = 0 where u_id = {0};", id);

                    if (dataGridView[8, x].Value.ToString().Replace(" ","") == "Оплачено")
                    {
                        query = "update main set pay = 'Не оплачено' where u_id = " + id;
                    }


                    NpgsqlConnection connection = new NpgsqlConnection(connstring);
                    connection.Open();


                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.showAll_Click(sender, e);
                    this.considerPay();
                    this.showAll_Click(sender, e);
                    MessageBox.Show("Статус оплаты изменен");
                }

                else
                {
                    MessageBox.Show("Не установлено число посещений", "Ошибка");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nothing pickedddd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void visitCount_Click(object sender, EventArgs e)
        {
            try
            {
                int visitColumn = 7; //номер столбца посещений
                if (dataGridView.CurrentCell.ColumnIndex == visitColumn)
                {


                    if (dataGridView.CurrentCell.Value.ToString().Replace(" ", "") != "")
                    {
                        int x = dataGridView.CurrentCell.RowIndex;
                        string val = dataGridView.CurrentCell.Value.ToString().Replace(" ", "");
                        if ((Int32.Parse(val) > 31) || (Int32.Parse(val) < 0))
                        {
                            MessageBox.Show("Некорректное число дней");
                            this.showAll_Click(sender, e);
                        }

                        else
                        {
                            string id = (dataGridView[0, x].Value.ToString());
                            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                            string query = string.Format("update main set visit = '{0}' where u_id = {1} ", val, id);


                            NpgsqlConnection connection = new NpgsqlConnection(connstring);
                            connection.Open();


                            NpgsqlCommand command = new NpgsqlCommand(query, connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                            this.showAll_Click(sender, e);

                            MessageBox.Show("Количество дней установлено");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Количество дней не установлено");
                    }
                }
                else
                {
                    MessageBox.Show("Выбран неверный столбец");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Nothing pickedddd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calcPay_Click(object sender, EventArgs e)
        {
            try
            {                
                    string query = "";

                    for (int i = 0; i < dataGridView.RowCount-1; i++)
                    {

                        if (dataGridView[8, i].Value.ToString().Replace(" ", "") == "Неоплачено")
                        {

                            string visit_val = dataGridView[7, i].Value.ToString();
                            int numDays = Int32.Parse(visit_val);
                            int payPerDay = 500;
                            int debt = payPerDay * numDays;



                            string id = dataGridView[0, i].Value.ToString();


                            query += string.Format("update main set debt = {0} where u_id = ({1}); ", debt, id);
                        Console.WriteLine(query);
                        }
                    }

                    string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                    NpgsqlConnection connection = new NpgsqlConnection(connstring);
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.showAll_Click(sender, e);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nothing picked");
            }
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {


            if (dataGridView.CurrentCellAddress.Y.Equals(null))

                MessageBox.Show("Nothing picked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    int x = dataGridView.CurrentCell.RowIndex;

                    string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                    string query = String.Format("DELETE from main where u_id = {0}", dataGridView[0, x].Value.ToString());

                    NpgsqlConnection connection = new NpgsqlConnection(connstring);
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.showAll_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nothing picked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void comboShow(string table_name) // fills combobox
        {
            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
            string query = string.Format("select f_val from {0}", table_name);
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();

            switch (table_name)
            {
                case "street":
                    {
                        while (dataReader.Read())
                        {
                            comboBoxFilterStreet.Items.Add(dataReader.GetString(0).Replace(" ", ""));
                        }
                        break;
                    }

            }
            connection.Close();
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            
            dt.Clear();
            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
            string query = " select u_id, surname.f_val, name.f_val, patronymic.f_val, street.f_val, telephone.f_val, " +
                           " grup, visit, pay from main " +
                           " inner join surname on main.surname = surname.f_id " +
                           " inner join name on main.name = name.f_id " +
                           " inner join street on main.street = street.f_id " +
                           " inner join patronymic on main.patronymic = patronymic.f_id" +
                           " inner join telephone on main.telephone = telephone.f_id" +
                           " where 1 = 1 ";

            if (comboBoxFilterStreet.SelectedItem != null)
            {
                query += string.Format("AND street.f_val = '{0}'", comboBoxFilterStreet.SelectedItem.ToString());
            }


            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();

            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, connection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

            dt.Load(npgSqlDataReader);
            dataGridView.DataSource = dt;
            dataGridView.Sort(dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            connection.Close();
        }

        private void considerPay()
        {
            string query = "";

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {

                if (dataGridView[8, i].Value.ToString().Replace(" ", "") == "Неоплачено")
                {

                    string visit_val = dataGridView[7, i].Value.ToString();
                    int numDays = Int32.Parse(visit_val);
                    int payPerDay = 500;
                    int debt = payPerDay * numDays;



                    string id = dataGridView[0, i].Value.ToString();


                    query += string.Format("update main set debt = {0} where u_id = ({1}); ", debt, id);
                    Console.WriteLine(query);
                }
            }

            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
                    }
    }
}
