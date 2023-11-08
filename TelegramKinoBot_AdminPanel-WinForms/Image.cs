using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    internal class Image
    {
        public static void ImageOutput(String ImageString, ImageList imageList, ListViewItem lv, int i)
        {
            //вывод маленького постера каждого фильма в таблицу

            ListView listView1 = FormMain.GetListView();
            int size = 20;//размер постера при отображении в таблице (квадрат)
            imageList.ImageSize = new Size(size, size);
            Bitmap emptyImage = new Bitmap(size, size);

            try
            {
                //скачивание изображения по ссылке из интернета
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(ImageString);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                imageList.Images.Add(img);//вывод изображения из БД
                ms.Dispose();//очистка памяти
            }
            catch
            {
                //вывод белого квадрата про отсутствии изображения
                using (Graphics gr = Graphics.FromImage(emptyImage))
                {
                    gr.Clear(Color.White);
                }
                imageList.Images.Add(emptyImage);
            }
            listView1.SmallImageList = imageList;
            lv.ImageIndex = i;//перебор id фильмов
        }
    }
}
