using Npgsql;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class DB_Table : FormMain
    {

        public static void DB_TableInitialize()
        {
            ListView listView1 = GetListView();


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
            listView1.Columns.Add("Редактировать", 112);
            listView1.Columns.Add("Удалить", 85);

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

                RefreshDB();
            }
        }

        private static void EditFilm(object sender, ListViewColumnMouseEventArgs e)
        {
            string sql = $"Select id, name, image, link, link2, link3, link4, link5 from kino.kino where id='{e.Item.Text}';";

            var FormEdit = new FormAdd(sql, Int32.Parse(e.Item.Text));
            FormEdit.ShowDialog();

            RefreshDB();
        }

        public static void DB_TableShow()//отображение списка на главной форме
        {
            ListView listView1 = GetListView();

            ImageList imageList = new ImageList();
            string sql = "Select id, name, image, link, link2, link3, link4, link5 from kino.kino order by id";//запрос на вывод данных

            NpgsqlConnection connection = FormMain.CONNECTION_STRING();
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            var Reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            int i = 0;
            while (Reader.Read())//вывод данных БД в таблицу
            {
                ListViewItem lv = new ListViewItem(Reader["id"].ToString());
                lv.SubItems.Add((string)Reader["name"]);
                var s = (string)Reader["image"];
                lv.SubItems.Add(s);
                ImageOutput(s, imageList, lv, i); i++;
                lv.SubItems.Add((string)Reader["link"]);
                lv.SubItems.Add((Reader["link2"] == DBNull.Value ? "" : (string)Reader["link2"]));
                lv.SubItems.Add((Reader["link3"] == DBNull.Value ? "" : (string)Reader["link3"]));
                lv.SubItems.Add((Reader["link4"] == DBNull.Value ? "" : (string)Reader["link4"]));
                lv.SubItems.Add((Reader["link5"] == DBNull.Value ? "" : (string)Reader["link5"]));
                lv.SubItems.Add("Редактировать");
                lv.SubItems.Add("Удалить");

                listView1.Items.Add(lv);
            }
            Reader.Close();
            connection.Close();
        }

        public static void ImageOutput(String ImageString, ImageList imageList, ListViewItem lv, int i)
        {//вывод маленьких постеров на экран

            ListView listView1 = GetListView();
            int size = 20;
            imageList.ImageSize = new Size(size, size);
            Bitmap emptyImage = new Bitmap(size, size);

            try
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(ImageString);
                MemoryStream ms = new MemoryStream(bytes);
                Image img = Image.FromStream(ms);

                imageList.Images.Add(img);//вывод изображения из БД
                ms.Dispose();
            }
            catch
            {
                using (Graphics gr = Graphics.FromImage(emptyImage))
                {
                    gr.Clear(Color.White);//вывод белого квадрата про отсутствии изображения
                }
                imageList.Images.Add(emptyImage);
            }
            listView1.SmallImageList = imageList;
            lv.ImageIndex = i;
        }

    }
}