
namespace TextRedaktor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходCtrlEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМенюПолныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очивкаВыполненаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стильToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветоваяГаммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светлаяТемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темнаяТемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.частотаАвтосохраненийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выклToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каждые10СимволовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.черезКаждые40СимволовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tapPage1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьФорматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tapPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.форматToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.удалитьВсеToolStripMenuItem,
            this.сохранитьВсёToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.выходCtrlEToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.менюToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить            Ctrl+S";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // удалитьВсеToolStripMenuItem
            // 
            this.удалитьВсеToolStripMenuItem.Name = "удалитьВсеToolStripMenuItem";
            this.удалитьВсеToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.удалитьВсеToolStripMenuItem.Text = "Закрыть все";
            this.удалитьВсеToolStripMenuItem.Click += new System.EventHandler(this.DeleteAllToolStripMenuItem_Click);
            // 
            // сохранитьВсёToolStripMenuItem
            // 
            this.сохранитьВсёToolStripMenuItem.Name = "сохранитьВсёToolStripMenuItem";
            this.сохранитьВсёToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.сохранитьВсёToolStripMenuItem.Text = "Сохранить всё    Ctrl+Shift+S";
            this.сохранитьВсёToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.удалитьToolStripMenuItem.Text = "Закрыть текущую вкладку";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // выходCtrlEToolStripMenuItem
            // 
            this.выходCtrlEToolStripMenuItem.Name = "выходCtrlEToolStripMenuItem";
            this.выходCtrlEToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.выходCtrlEToolStripMenuItem.Text = "Выход                      Ctrl+E";
            this.выходCtrlEToolStripMenuItem.Click += new System.EventHandler(this.CloseFormToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокМенюПолныйToolStripMenuItem,
            this.очивкаВыполненаToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // списокМенюПолныйToolStripMenuItem
            // 
            this.списокМенюПолныйToolStripMenuItem.Name = "списокМенюПолныйToolStripMenuItem";
            this.списокМенюПолныйToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.списокМенюПолныйToolStripMenuItem.Text = "Список меню полный,";
            // 
            // очивкаВыполненаToolStripMenuItem
            // 
            this.очивкаВыполненаToolStripMenuItem.Name = "очивкаВыполненаToolStripMenuItem";
            this.очивкаВыполненаToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.очивкаВыполненаToolStripMenuItem.Text = "очивка выполнена";
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стильToolStripMenuItem1});
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.форматToolStripMenuItem.Text = "Формат";
            // 
            // стильToolStripMenuItem1
            // 
            this.стильToolStripMenuItem1.Name = "стильToolStripMenuItem1";
            this.стильToolStripMenuItem1.Size = new System.Drawing.Size(132, 26);
            this.стильToolStripMenuItem1.Text = "Стиль";
            this.стильToolStripMenuItem1.Click += new System.EventHandler(this.StyleToolStripMenuItem1_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветоваяГаммаToolStripMenuItem,
            this.частотаАвтосохраненийToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // цветоваяГаммаToolStripMenuItem
            // 
            this.цветоваяГаммаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.светлаяТемаToolStripMenuItem,
            this.темнаяТемаToolStripMenuItem});
            this.цветоваяГаммаToolStripMenuItem.Name = "цветоваяГаммаToolStripMenuItem";
            this.цветоваяГаммаToolStripMenuItem.Size = new System.Drawing.Size(391, 26);
            this.цветоваяГаммаToolStripMenuItem.Text = "Цветовая гамма";
            // 
            // светлаяТемаToolStripMenuItem
            // 
            this.светлаяТемаToolStripMenuItem.Name = "светлаяТемаToolStripMenuItem";
            this.светлаяТемаToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.светлаяТемаToolStripMenuItem.Text = "Светлая тема";
            this.светлаяТемаToolStripMenuItem.Click += new System.EventHandler(this.WhiteThemeToolStripMenuItem_Click);
            // 
            // темнаяТемаToolStripMenuItem
            // 
            this.темнаяТемаToolStripMenuItem.Name = "темнаяТемаToolStripMenuItem";
            this.темнаяТемаToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.темнаяТемаToolStripMenuItem.Text = "Темная тема";
            this.темнаяТемаToolStripMenuItem.Click += new System.EventHandler(this.BlackThemeToolStripMenuItem_Click);
            // 
            // частотаАвтосохраненийToolStripMenuItem
            // 
            this.частотаАвтосохраненийToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выклToolStripMenuItem,
            this.каждые10СимволовToolStripMenuItem,
            this.каToolStripMenuItem,
            this.черезКаждые40СимволовToolStripMenuItem,
            this.чToolStripMenuItem});
            this.частотаАвтосохраненийToolStripMenuItem.Name = "частотаАвтосохраненийToolStripMenuItem";
            this.частотаАвтосохраненийToolStripMenuItem.Size = new System.Drawing.Size(391, 26);
            this.частотаАвтосохраненийToolStripMenuItem.Text = "Частота автосохранений открытых файлов";
            // 
            // выклToolStripMenuItem
            // 
            this.выклToolStripMenuItem.Name = "выклToolStripMenuItem";
            this.выклToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.выклToolStripMenuItem.Text = "Выкл.";
            this.выклToolStripMenuItem.Click += new System.EventHandler(this.StepSave0ToolStripMenuItem_Click);
            // 
            // каждые10СимволовToolStripMenuItem
            // 
            this.каждые10СимволовToolStripMenuItem.Name = "каждые10СимволовToolStripMenuItem";
            this.каждые10СимволовToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.каждые10СимволовToolStripMenuItem.Text = "Через каждые 10 символов";
            this.каждые10СимволовToolStripMenuItem.Click += new System.EventHandler(this.StepSave10ToolStripMenuItem_Click);
            // 
            // каToolStripMenuItem
            // 
            this.каToolStripMenuItem.Name = "каToolStripMenuItem";
            this.каToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.каToolStripMenuItem.Text = "Через каждые 100 символов";
            this.каToolStripMenuItem.Click += new System.EventHandler(this.StepSave100ToolStripMenuItem_Click);
            // 
            // черезКаждые40СимволовToolStripMenuItem
            // 
            this.черезКаждые40СимволовToolStripMenuItem.Name = "черезКаждые40СимволовToolStripMenuItem";
            this.черезКаждые40СимволовToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.черезКаждые40СимволовToolStripMenuItem.Text = "Через каждую 1000 символов";
            this.черезКаждые40СимволовToolStripMenuItem.Click += new System.EventHandler(this.StepSave1000ToolStripMenuItem_Click);
            // 
            // чToolStripMenuItem
            // 
            this.чToolStripMenuItem.Name = "чToolStripMenuItem";
            this.чToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.чToolStripMenuItem.Text = "Через каждые 10000 символов";
            this.чToolStripMenuItem.Click += new System.EventHandler(this.StepSave10000ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tapPage1
            // 
            this.tapPage1.ContextMenuStrip = this.contextMenuStrip1;
            this.tapPage1.Controls.Add(this.tabPage1);
            this.tapPage1.Controls.Add(this.tabPage2);
            this.tapPage1.Controls.Add(this.tabPage3);
            this.tapPage1.Controls.Add(this.tabPage4);
            this.tapPage1.Location = new System.Drawing.Point(0, 32);
            this.tapPage1.Name = "tapPage1";
            this.tapPage1.SelectedIndex = 0;
            this.tapPage1.Size = new System.Drawing.Size(907, 544);
            this.tapPage1.TabIndex = 3;
            this.tapPage1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.вырезатьToolStripMenuItem,
            this.выделитьВсеToolStripMenuItem,
            this.изменитьФорматToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 124);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            this.копироватьToolStripMenuItem.Click += new System.EventHandler(this.Copy_Click);
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            this.вставитьToolStripMenuItem.Click += new System.EventHandler(this.Paste_Click);
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            this.вырезатьToolStripMenuItem.Click += new System.EventHandler(this.Cut_Click);
            // 
            // выделитьВсеToolStripMenuItem
            // 
            this.выделитьВсеToolStripMenuItem.Name = "выделитьВсеToolStripMenuItem";
            this.выделитьВсеToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.выделитьВсеToolStripMenuItem.Text = "Выделить все";
            this.выделитьВсеToolStripMenuItem.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // изменитьФорматToolStripMenuItem
            // 
            this.изменитьФорматToolStripMenuItem.Name = "изменитьФорматToolStripMenuItem";
            this.изменитьФорматToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.изменитьФорматToolStripMenuItem.Text = "Изменить формат";
            this.изменитьФорматToolStripMenuItem.Click += new System.EventHandler(this.ChangeFormat_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(899, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вкладка 1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Location = new System.Drawing.Point(-4, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(903, 508);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(899, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Неиспользуемая вкладка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox2.Location = new System.Drawing.Point(-4, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(907, 511);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(899, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Неиспользуемая вкладка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox3.Location = new System.Drawing.Point(-4, 0);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(907, 511);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "";
            this.richTextBox3.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(899, 511);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Неиспользуемая вкладка";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox4
            // 
            this.richTextBox4.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox4.Location = new System.Drawing.Point(-4, 0);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(907, 511);
            this.richTextBox4.TabIndex = 4;
            this.richTextBox4.Text = "";
            this.richTextBox4.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(314, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 27);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(907, 571);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tapPage1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tapPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tapPage1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem стильToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem цветоваяГаммаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem светлаяТемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темнаяТемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem частотаАвтосохраненийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выклToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каждые10СимволовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem черезКаждые40СимволовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделитьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьФорматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокМенюПолныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очивкаВыполненаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходCtrlEToolStripMenuItem;
    }
}

