using Npgsql;
using System;
using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class DB_TableShow
    {
        public static void Show()//отображение списка на главной форме
        {
            ListView listView1 = FormMain.GetListView();

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
                Image.ImageOutput(s, imageList, lv, i); i++;
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
    }
}
