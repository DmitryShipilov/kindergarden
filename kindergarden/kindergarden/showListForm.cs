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
        // column numbers
        const int u_id = 0;
        const int surname = 1;
        const int name = 2;
        const int patr = 3;
        const int group = 4;
        const int attendance = 5;
        const int payStatus = 6;
        const int debit = 7;
        const int street = 8;
        const int building = 9;
        const int flat = 10;
        const int date = 11;
        const int parentPhone = 12;


        public showListForm()
        {
            InitializeComponent();
        }

        List<string> ColumnVals = new List<string>();
        List<string> ColumnIndex = new List<string>();
        DataTable dt = new DataTable();
        DataTable dt_filter = new DataTable();
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
            string query = " select u_id, surname.f_val, name.f_val, patronymic.f_val, grup, visit,pay, debt,  " +
                           " street.f_val, building.f_val, flat.f_val, date.f_val, telephone.f_val from main " +
                           " inner join surname on main.surname = surname.f_id " +
                           " inner join name on main.name = name.f_id " +
                           " inner join street on main.street = street.f_id " +
                           " inner join patronymic on main.patronymic = patronymic.f_id " +
                           " inner join building on main.building = building.f_id " +
                           " inner join flat on main.flat = flat.f_id " +
                           " inner join date on main.date = date.f_id " +
                           " inner join telephone on main.telephone = telephone.f_id; ";
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();

            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, connection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

            dt.Load(npgSqlDataReader);
            dataGridView.DataSource = dt;
            dataGridView.Sort(dataGridView.Columns[u_id], System.ComponentModel.ListSortDirection.Ascending);

            connection.Close();

            // column names
            dataGridView.Columns[u_id].HeaderText = "Номер";
            dataGridView.Columns[surname].HeaderText = "Фамилия";
            dataGridView.Columns[name].HeaderText = "Имя";
            dataGridView.Columns[patr].HeaderText = "Отчество";
            dataGridView.Columns[group].HeaderText = "Группа";
            dataGridView.Columns[attendance].HeaderText = "Количество посещений";
            dataGridView.Columns[payStatus].HeaderText = "Статус оплаты";
            dataGridView.Columns[debit].HeaderText = "Задолженность";
            dataGridView.Columns[street].HeaderText = "Улица";
            dataGridView.Columns[building].HeaderText = "Дом";
            dataGridView.Columns[flat].HeaderText = "Квартира";
            dataGridView.Columns[date].HeaderText = "Дата рождения";
            dataGridView.Columns[parentPhone].HeaderText = "Телефон родителей";

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

                if (dataGridView[attendance, x].Value.ToString() != "")
                {
                    string id = (dataGridView[u_id, x].Value.ToString());
                    string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                    string query = "";

                    if (dataGridView[payStatus, x].Value.ToString().Replace(" ", "") == "Оплачено")
                    {
                        query = string.Format("update main set pay = 'Не оплачено' where u_id = {0};", id); 
                        string inCount =  dataGridView[attendance, x].Value.ToString();
                        int sum = 500 * Int32.Parse(inCount);
                        query += string.Format("update main set debt = '{0}' where u_id = {1};",sum, id);
                        //this.considerPay(x);
                        this.showAll_Click(sender, e);
                    }
                    else
                    {

                        query = "update main set pay = 'Оплачено' where u_id = " + id + ";";
                        query += string.Format(" update main set debt = 0 where u_id = {0};", id);
                    }



                    NpgsqlConnection connection = new NpgsqlConnection(connstring);
                    connection.Open();


                    NpgsqlCommand command = new NpgsqlCommand(query, connection);

                    command.ExecuteNonQuery();


                    connection.Close();

                    MessageBox.Show("Статус оплаты изменен");


                    this.showAll_Click(sender, e);

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
                Console.WriteLine("try");

                if (dataGridView.CurrentCell.ColumnIndex == attendance)
                {
                    Console.WriteLine("if 1");

                    if (dataGridView.CurrentCell.Value.ToString().Replace(" ", "") != "")
                    {
                        Console.WriteLine("if 2");
                        int x = dataGridView.CurrentCell.RowIndex;
                        string val = dataGridView.CurrentCell.Value.ToString().Replace(" ", "");
                        if ((Int32.Parse(val) > 31) || (Int32.Parse(val) < 0))
                        {
                            Console.WriteLine("if 3");
                            MessageBox.Show("Некорректное число дней");
                            this.showAll_Click(sender, e);
                        }

                        else
                        {
                            Console.WriteLine("else 1 begin");
                            string id = (dataGridView[u_id, x].Value.ToString());
                            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                            string query = string.Format("update main set visit = '{0}' where u_id = {1} ", val, id);


                            NpgsqlConnection connection = new NpgsqlConnection(connstring);
                            connection.Open();


                            NpgsqlCommand command = new NpgsqlCommand(query, connection);
                            Console.WriteLine("before execute");
                            command.ExecuteNonQuery();
                            Console.WriteLine("after execute");
                            considerPay(dataGridView.CurrentCell.RowIndex);
                            Console.WriteLine("after conspay");
                            connection.Close();
                            Console.WriteLine("after close");

                            MessageBox.Show("Количество дней и сумма задолженности установлены","Успешно");
                            Console.WriteLine("else 1 end");
                            this.showAll_Click(sender, e);
                        }
                    }
                    else
                    {
                        Console.WriteLine("else 2");
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

                        if (dataGridView[payStatus, i].Value.ToString().Replace(" ", "") == "Неоплачено")
                        {

                            string visit_val = dataGridView[attendance, i].Value.ToString();
                            int numDays = Int32.Parse(visit_val);
                            int payPerDay = 500;
                            int debt = payPerDay * numDays;



                            string id = dataGridView[u_id, i].Value.ToString();


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



                try
                {
                    int x = dataGridView.CurrentCell.RowIndex;

                    string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                    string query = String.Format("DELETE from main where u_id = {0}", dataGridView[u_id, x].Value.ToString());

                    NpgsqlConnection connection = new NpgsqlConnection(connstring);
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    
                    MessageBox.Show(string.Format("{0} успешно удален", dataGridView[surname, x].Value.ToString()), "Данные удалены");
                    this.showAll_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nothing picked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            dt_filter.Clear();
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
                query += string.Format("AND street.f_val = '{0}';", comboBoxFilterStreet.SelectedItem.ToString());
            }


            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();

            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, connection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

            dt_filter.Load(npgSqlDataReader);
            dataGridView.DataSource = dt_filter;
            dataGridView.Sort(dataGridView.Columns[u_id], System.ComponentModel.ListSortDirection.Ascending);
            connection.Close();
        }

        private void considerPay(int curRow)
        {
            string query = "";

           // for (int i = 0; i < dataGridView.RowCount - 1; i++)
           // {

                if (dataGridView[payStatus, curRow].Value.ToString().Replace(" ", "") == "Неоплачено")
                {

                    string visit_val = dataGridView[attendance, curRow].Value.ToString();
                    int numDays = Int32.Parse(visit_val);
                    int payPerDay = 500;
                    int debt = payPerDay * numDays;



                    string id = dataGridView[u_id, curRow].Value.ToString();


                    query += string.Format("update main set debt = {0} where u_id = ({1}); ", debt, id);
                    Console.WriteLine(query);
                }
            //}

            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


    }
}
