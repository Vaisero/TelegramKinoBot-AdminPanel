using System.Windows.Forms;

namespace TelegramKinoBot_AdminPanel_WinForms
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            listView1 = new System.Windows.Forms.ListView();
            this.buttonUserChange = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            labelTotal = new System.Windows.Forms.Label();
            labelAdded = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listView1.HideSelection = false;
            listView1.Location = new System.Drawing.Point(0, 45);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(1161, 642);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // buttonUserChange
            // 
            this.buttonUserChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonUserChange.BackColor = System.Drawing.Color.Cyan;
            this.buttonUserChange.Location = new System.Drawing.Point(31, 1);
            this.buttonUserChange.Name = "buttonUserChange";
            this.buttonUserChange.Size = new System.Drawing.Size(220, 44);
            this.buttonUserChange.TabIndex = 1;
            this.buttonUserChange.Text = "Сменить Пользователя";
            this.buttonUserChange.UseVisualStyleBackColor = false;
            this.buttonUserChange.Click += new System.EventHandler(this.buttonUserChange_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.LawnGreen;
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAdd.Location = new System.Drawing.Point(251, 1);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(440, 44);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRefresh.Location = new System.Drawing.Point(691, 1);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(440, 44);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 690);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Всего фильмов в БД: ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(732, 690);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сейчас было добавлено в БД: ";
            // 
            // labelTotal
            // 
            labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelTotal.AutoSize = true;
            labelTotal.Location = new System.Drawing.Point(257, 690);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new System.Drawing.Size(0, 13);
            labelTotal.TabIndex = 6;
            // 
            // labelAdded
            // 
            labelAdded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelAdded.AutoSize = true;
            labelAdded.Location = new System.Drawing.Point(902, 690);
            labelAdded.Name = "labelAdded";
            labelAdded.Size = new System.Drawing.Size(0, 13);
            labelAdded.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 712);
            this.Controls.Add(labelAdded);
            this.Controls.Add(labelTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonUserChange);
            this.Controls.Add(listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель Управления Базой Данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private static System.Windows.Forms.ListView listView1;
        
        public static ListView GetListView()
        {
            return listView1;
        }

        private System.Windows.Forms.Button buttonUserChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public static System.Windows.Forms.Label labelTotal;
        public static System.Windows.Forms.Label labelAdded;
    }
}
