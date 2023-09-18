using Npgsql;
using System;
using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class Labels
    {
        
        public static void RefreshLabel ()
        {
            // обработка labelTotal

            //вывод общего числа фильмов в БД
            NpgsqlConnection connection = FormMain.CONNECTION_STRING();
            connection.Open();

            string sql = $"select MAX(id) as id from kino.kino";

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
                num++;
                FormMain.labelAdded.Text = num.ToString();
            }
            catch (ArgumentNullException ex)
            {
                FormMain.labelAdded.Text = "0";
            }
            catch (FormatException ex)
            {
                FormMain.labelAdded.Text = "0";
            }
        }
    }
}
