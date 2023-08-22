using Npgsql;
using System;
using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            DB_Table.DB_TableInitialize(listView1);//отображение списка фильмов
            labelAdded.Text = null; //колличество добавленных фильмов за сессию
            Labels.RefreshLabel();//обновление счётчика колличества фильмов 
        }

        public static NpgsqlConnection CONNECTION_STRING()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=devUser;Password=1234;Database=Kino;");
            // в БД создан пользователь для удалённого подключения и администрирования
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var AddForm = new FormAdd();
            AddForm.ShowDialog();

            DB_Table.DB_TableShow(listView1);//обновление страницы
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DB_Table.DB_TableShow(listView1);
        }

        private void buttonUserChange_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
             "В разработке",
             "Сообщение",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information,
             MessageBoxDefaultButton.Button1);
        }
    }
}