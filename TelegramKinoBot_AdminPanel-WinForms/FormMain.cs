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
            DB_Table.DB_TableInitialize();//отображение списка фильмов
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
            var FormAdd = new FormAdd();
            FormAdd.ShowDialog();//форма добавления новых фильмов в БД

            RefreshDB();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDB();//обновление отображения таблицы
        }

        public static void RefreshDB()
        {
            //обновление отображения таблицы
            DB_TableShow.Show();
            Labels.RefreshLabel();
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