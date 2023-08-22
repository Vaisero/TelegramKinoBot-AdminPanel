using Npgsql;
using System;
using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != String.Empty && textBoxImage.Text != String.Empty && textBoxKinoLink.Text != String.Empty)
            {
                NpgsqlConnection connection = FormMain.CONNECTION_STRING();
                connection.Open();
                
                string sql = $"INSERT into kino.kino(name, image, link, link2, link3, link4, link5) VALUES ('{textBoxName.Text}', '{textBoxImage.Text}', '{textBoxKinoLink.Text}', '{textBoxLink1.Text}', '{textBoxLink2.Text}', '{textBoxLink3.Text}', '{textBoxLink4.Text}');";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                cmd.ExecuteNonQuery();//занесение нового фильма в БД
                connection.Close();

                Labels.RefreshLabel();//обновление счётчика колличества фильмов 
            }
            else//проверка на  заполненность обязательных строк
            {
                MessageBox.Show(
                "Не заполнены обязательные первые три строчки",
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);

                DialogResult = DialogResult.None;
            }
        }
    }
}