using Npgsql;
using System;
using System.Windows.Forms;


namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class DB_Table : FormMain
    {
<<<<<<< Updated upstream
        public static void DB_TableInitialize(ListView listView1)
        {
=======
        public static void DB_TableInitialize()
        {
            ListView listView1 = GetListView();

>>>>>>> Stashed changes
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            ListViewButtons listViewButtons= new ListViewButtons(listView1);

            // названия столбцов
            listView1.Columns.Add("Номер", 50);
            listView1.Columns.Add("Название", 200);
            listView1.Columns.Add("Картинка", 50);
            listView1.Columns.Add("Кинопоиск", 220);
            listView1.Columns.Add("Ссылка", 110);
            listView1.Columns.Add("Ссылка", 110);
            listView1.Columns.Add("Ссылка", 110);
            listView1.Columns.Add("Ссылка", 110);
            listView1.Columns.Add("Редактировать", 100);
            listView1.Columns.Add("Удалить", 80);

            ListViewButtonColumn EditButton = new ListViewButtonColumn(8);
            EditButton.FixedWidth = true;
            EditButton.Click += EditFilm;

            ListViewButtonColumn DeleteButton = new ListViewButtonColumn(9);
            DeleteButton.FixedWidth = true;
            DeleteButton.Click += DeleteFilm;

            DB_TableShow();

            listViewButtons.AddColumn(EditButton);
            listViewButtons.AddColumn(DeleteButton);
        }

        private static void DeleteFilm(object sender, ListViewColumnMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this movie?", 
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

                RefreshDB();
            }
        }

        private static void EditFilm(object sender, ListViewColumnMouseEventArgs e)
        {
<<<<<<< Updated upstream
            string sql = "Select id, name, image, link, link2, link3, link4, link5 from kino.kino";//запрос на вывод данных
=======
            var FormEdit = new FormAdd();
            FormEdit.ShowDialog();

            RefreshDB();
        }

        public static void DB_TableShow()//отображение списка на главной форме
        {
            ListView listView1 = GetListView();

            ImageList imageList = new ImageList();
            string sql = "Select id, name, image, link, link2, link3, link4, link5 from kino.kino order by id";//запрос на вывод данных
>>>>>>> Stashed changes
            NpgsqlConnection connection = FormMain.CONNECTION_STRING();
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            var Reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (Reader.Read())//вывод данных БД в таблицу
            {
                ListViewItem lv = new ListViewItem(Reader["id"].ToString());
                lv.SubItems.Add((string)Reader["name"]);
                lv.SubItems.Add((string)Reader["image"]);
                lv.SubItems.Add((string)Reader["link"]);
                lv.SubItems.Add((Reader["link2"] == DBNull.Value ? "" : (string)Reader["link2"]));
                lv.SubItems.Add((Reader["link3"] == DBNull.Value ? "" : (string)Reader["link3"]));
                lv.SubItems.Add((Reader["link4"] == DBNull.Value ? "" : (string)Reader["link4"]));
                lv.SubItems.Add((Reader["link5"] == DBNull.Value ? "" : (string)Reader["link5"]));
                lv.SubItems.Add("Edit");
                lv.SubItems.Add("Delete");
                listView1.Items.Add(lv);
            }
            Reader.Close();
            connection.Close();
        }
    }
}