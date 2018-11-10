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
    public partial class addForm : Form
    {
        public addForm()
        {
            InitializeComponent();
        }

        List<string> dataItems = new List<string>();
        private void addForm_Load(object sender, EventArgs e)
        {

        }

        private void backToForm1_Click(object sender, EventArgs e)
        {
            this.Close();

            inForm inForm = new inForm();
            inForm.Show();
        }

        private void clearAll_Click(object sender, EventArgs e) // clears all fields
        {

            surnameTB.Text = "";
            nameTB.Text = "";
            patrTB.Text = "";
            streetTB.Text = "";
            dateTimePicker.Text = "";
            buildTB.Text = "";
            flatTB.Text = "";
            telephoneTB.Text = "";


        }

        private void addNew_Click(object sender, EventArgs e)   //add new child
        {
            if ((surnameTB.Text == "") || (nameTB.Text == "") || (patrTB.Text == "") || (telephoneTB.Text == "") || (streetTB.Text == "")
                || (buildTB.Text == "") || (flatTB.Text == ""))
            {
                MessageBox.Show("Заполнены не все поля", "phonebook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                this.insertIntoTable("surname", surnameTB.Text);
                this.insertIntoTable("name", nameTB.Text);
                this.insertIntoTable("patronymic", patrTB.Text);
                this.insertIntoTable("street", streetTB.Text);
                this.insertIntoTable("building", buildTB.Text);
                this.insertIntoTable("flat", flatTB.Text);
                this.insertIntoTable("telephone", telephoneTB.Text);
                this.insertIntoTable("date", dateTimePicker.Text);

                this.insertIntoMain();
            }



            Console.WriteLine(dateTimePicker.Value.Date.Year);


        }

        private void insertIntoTable (string name_table, string text)
        {
            try
            {
                dataItems.Clear(); // reset global var
                bool exist = false;
                string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
                string query = "select f_val from " + name_table;
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    dataItems.Add(dataReader.GetString(0));
                }

                connection.Close();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    if (dataItems[i].Replace(" ", "") == text.Replace(" ", ""))
                    {
                        exist = true;
                    }
                }

                if (exist == false)
                {
                        query = string.Format("INSERT INTO " + name_table + " (f_val) VALUES ('{0}')", text);
                        NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
           
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        private void insertIntoMain()
        {
            string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=1415; Database=kindergarden;";
            NpgsqlConnection connection = new NpgsqlConnection(connstring);

            string qName = string.Format("select f_id from name where f_val = '{0}'", nameTB.Text);
            string qSurname = string.Format("select f_id from surname where f_val = '{0}'", surnameTB.Text);
            string qPatr = string.Format("select f_id from patronymic where f_val = '{0}'", patrTB.Text);
            string qStreet = string.Format("select f_id from street where f_val = '{0}'", streetTB.Text);
            string qBuild = string.Format("select f_id from building where f_val = '{0}'", buildTB.Text);
            string qFlat = string.Format("select f_id from flat where f_val = '{0}'", flatTB.Text);
            string qTelephone = string.Format("select f_id from telephone where f_val = '{0}'", telephoneTB.Text);
            string qDate = string.Format("select f_id from date where f_val = '{0}'", dateTimePicker.Text);
            string qPay = "Не оплачено";

            string maxindex = "(select max(u_id) from main)";
            string group = "";
            int curYear = 2018;
            int age = curYear - dateTimePicker.Value.Date.Year;

            if ((age < 2) || (age > 6))
            {
                MessageBox.Show("Возраст детей должен быть от 2 до 6 лет", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else
            {
                if (age == 2)
                {
                    group = "Младшая группа";
                }

                if ((age == 3) || (age == 4))
                {
                    group = "Средняя группа";
                }

                if ((age == 5) || (age == 6))
                {
                    group = "Старшая группа";
                }

                Console.WriteLine(group);


                string query = String.Format("insert into main (grup) values ('{10}'); " +
                                     "UPDATE main SET name = ({0}), surname = ({1}), " +
                                       "patronymic = ({2}), street = ({3}), " +
                                       "building = ({4}), flat = ({5}), telephone = ({6}), " +
                                       "date = ({7}), pay = ('{8}') where u_id = ({9})", qName, qSurname, qPatr, qStreet, qBuild, qFlat, qTelephone,
                                       qDate, qPay, maxindex, group);

                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show((string.Format("Ребенок успешно внесен в группу под названием «{0}»", group)), "Внесение успешно");
            }
        }
    }

}
