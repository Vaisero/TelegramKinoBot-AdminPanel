using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class DB_Table : FormMain
    {

        public static void DB_TableInitialize()
        {
            //Создание таблицы на экране приложения

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

            //авто-создание кнопки редактирования в ListView
            ListViewButtonColumn EditButton = new ListViewButtonColumn(8);
            EditButton.FixedWidth = true;
            EditButton.Click += FilmButtons.EditFilm;

            //авто-создание кнопки удаления в ListView
            ListViewButtonColumn DeleteButton = new ListViewButtonColumn(9);
            DeleteButton.FixedWidth = true;
            DeleteButton.Click += FilmButtons.DeleteFilm;

            DB_TableShow.Show();

            listViewButtons.AddColumn(EditButton);
            listViewButtons.AddColumn(DeleteButton);
        } 
    }
}