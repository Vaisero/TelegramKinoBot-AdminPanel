using Npgsql;
using System;
using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class FilmButtons
    {
        public static void DeleteFilm(object sender, ListViewColumnMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Ты уверен, что хочешь БЕЗВОЗВРАТНО удалить фильм №{e.Item.Text}?",
                "Удалить фильм",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                NpgsqlConnection connection = FormMain.CONNECTION_STRING();
                connection.Open();

                string sql = $"Delete from kino.kino where id='{e.Item.Text}';";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                FormMain.RefreshDB();
            }
        }

        public static void EditFilm(object sender, ListViewColumnMouseEventArgs e)
        {
            string sql = $"Select id, name, image, link, link2, link3, link4, link5 from kino.kino where id='{e.Item.Text}';";

            var FormEdit = new FormAdd(sql, Int32.Parse(e.Item.Text));
            FormEdit.ShowDialog();

            FormMain.RefreshDB();
        }
    }
}
