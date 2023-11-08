﻿using Npgsql;
using System;
using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class FilmButtons
    {
        public static void DeleteFilm(object sender, ListViewColumnMouseEventArgs e)
        {
            //кнопка "Удалить" в таблице

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

                string sql = $"Delete from kino.kino where id='{e.Item.Text}';";//удаление конкретного фильма по id

                NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                FormMain.RefreshDB();
            }
        }

        public static void EditFilm(object sender, ListViewColumnMouseEventArgs e)
        {
            //кнопка "Редактировать" в таблице

            string sql = $"Select id, name, image, link, link2, link3, link4, link5 from kino.kino where id='{e.Item.Text}';";//выбор конкретного фильма

            var FormEdit = new FormAdd(sql, Int32.Parse(e.Item.Text));
            FormEdit.ShowDialog();//открытие формы "Добавить", но с автоматическим заполнением полей из конкретного фильма по id

            FormMain.RefreshDB();
        }
    }
}
