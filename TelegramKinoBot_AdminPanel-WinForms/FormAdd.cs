using Npgsql;
using System;
using System.Windows.Forms;


namespace TelegramKinoBot_AdminPanel_WinForms
{
    public partial class FormAdd : Form
    {

        public bool updateData = false;//указатель на обновление в БД, а не добавление
        public int updateID;//указатель на конкретный фильм по id

        public FormAdd()
        {
            InitializeComponent();//запускается при добавлении нового фильма
            textBoxName.Select();//автоматически выставляет курсор
        }

        public FormAdd(String sql, int id)
        {
            InitializeComponent();//запускается при редактировании нового фильма
            
            NpgsqlConnection connection = FormMain.CONNECTION_STRING();
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            var Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                textBoxName.Text = Reader["name"].ToString();
                textBoxImage.Text = Reader["image"].ToString();
                textBoxKinoLink.Text = Reader["kino_link"].ToString();
                textBoxLink1.Text = Reader["link1"].ToString();
                textBoxLink2.Text = Reader["link2"].ToString();
                textBoxLink3.Text = Reader["link3"].ToString();
                textBoxLink4.Text = Reader["link4"].ToString();
            }
            Reader.Close();
            connection.Close();

            updateID = id;//указатель на конкретный фильм по id
            updateData = true;//указатель на обновление в БД, а не добавление
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //при нажатии кнопки "Сохранить" происходит перенос в БД и отображение в VistView

            if (textBoxName.Text != String.Empty && textBoxImage.Text != String.Empty && textBoxKinoLink.Text != String.Empty)
            {
                NpgsqlConnection connection = FormMain.CONNECTION_STRING();
                connection.Open();

                //строка на добавление нового фильма
                var link1 = textBoxLink1.Text == "" ? "null" : $"'{textBoxLink1.Text}'";
                var link2 = textBoxLink2.Text == "" ? "null" : $"'{textBoxLink2.Text}'";
                var link3 = textBoxLink3.Text == "" ? "null" : $"'{textBoxLink3.Text}'";
                var link4 = textBoxLink4.Text == "" ? "null" : $"'{textBoxLink4.Text}'";

                string sql = $"INSERT into kino.kino(name, image, kino_link, link1, link2, link3, link4) VALUES ($${textBoxName.Text}$$, $${textBoxImage.Text}$$, $${textBoxKinoLink.Text}$$, {link1}, {link2}, {link3}, {link4});";

                if(updateData) 
                    //строка на обновление имеющегося фильма
                    sql = $"UPDATE kino.kino set name='{textBoxName.Text}', image='{textBoxImage.Text}', kino_link='{textBoxKinoLink.Text}', link1='{textBoxLink1.Text}', link2='{textBoxLink2.Text}', link3='{textBoxLink3.Text}', link4='{textBoxLink4.Text}' where id={updateID};";


                NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                cmd.ExecuteNonQuery();//занесение фильма в БД
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