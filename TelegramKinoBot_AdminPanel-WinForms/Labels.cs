using Npgsql;
using System;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class Labels
    {
        
        public static void RefreshLabel ()
        {
            //создание и обновление Label


            // обработка labelTotal           
            NpgsqlConnection connection = FormMain.CONNECTION_STRING();
            connection.Open();

            //вывод количества фильмов в БД
            string sql = $"select count (*) from kino.kino";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                FormMain.labelTotal.Text = reader.GetInt32(0).ToString(); //вывод общего числа фильмов в БД
            }
            connection.Close();



            // обработка labelAdded

            //колличество добавленных фильмов за сессию
            try
            {
                var num = Int32.Parse(FormMain.labelAdded.Text);
                num++;//счётчик обновляется при перезапуске программы
                FormMain.labelAdded.Text = num.ToString();
            }
            catch (ArgumentNullException ex)
            {
                FormMain.labelAdded.Text = "0";//по умолчанию
            }
            catch (FormatException ex)
            {
                FormMain.labelAdded.Text = "0";//по умолчанию
            }
        }
    }
}
