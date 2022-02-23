using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/// 
/// ПРЕДИСЛОВИЕ
/// Здравствуй, дорогой читатель!
/// Убедииитееельнааая просьба, прочитай пожалуйста ReadMe :)
/// 

namespace TextRedaktor
{

    public partial class Form1 : Form
    {
        //Для хранения ссылки поступающей при нажатии "открыть с помощью". 
        string[] globalArgs;
        //Выключатели показывающие, что требуется сохранять.
        bool[] switchSaves = { false, false, false, false };
        //Выключатели показывающие какие закладки открыты на данный момент.
        bool[] openerTab = { true, false, false, false };
        //С каким шагом сохранять файл.
        int stepSave = 0;
        //Список файл которые были ранее открыты, при чем элементы на нечетных местах - это номер вкладки,
        //а четные ссылка на документы откуда была открыта вкладка
        List<string> openInfo = new List<string>(3);
        //Номер открытой пользователем рабочей области(вкладки).
        int workinArea = 0;
        //Набор текстовых коробок.
        public RichTextBox[] textBoxes = new RichTextBox[4];
        //Нижний порог автосохрания.
        int LowBarder = 0;
        //Верхний порог.
        int UpBarder = 1000;
        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="args">Ссылка передающаяся при нажатии "открыть с помощью"</param>
        
        public Form1(string[] args)
        {
            try
            {
                globalArgs = args;
                InitializeComponent();
                //Горячие ,очень горячие кнопки, *стон*.
                this.KeyPreview = true;
                this.KeyDown += new KeyEventHandler(Form_KeyDownS);
                this.KeyDown += new KeyEventHandler(Form_KeyDownShiftS);
                this.KeyDown += new KeyEventHandler(Form_KeyDownClose);
                this.KeyDown += new KeyEventHandler(Form_KeyDownAddPage);
                this.KeyDown += new KeyEventHandler(Form_KeyDownNewForm);

            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка запуска", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// Запуск формы
        /// Проверка, была ли программа запущенна через "открыть с помощью", если нет, то обыкновенный запуск,
        /// считывание логов с ссылками на ранее открытые файлы, переход по ним и чтение файлов.
        /// Востановление старый параметров
        /// 
        /// Если массив globalArgs не пустой, открытие было через "открыть с помощью", то запустить соответствующий метод
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] oldLink;
                textBoxes = new RichTextBox[] { richTextBox1, richTextBox2, richTextBox3, richTextBox4 };
                if (globalArgs.Length == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        oldLink = File.ReadAllText($"log{i}.txt").Split('\n');
                        if (oldLink[oldLink.Length - 1] != "")
                        {
                            try
                            {
                                using (StreamReader reader = new StreamReader(oldLink[oldLink.Length - 1]))
                                {
                                    textBoxes[i].Text = reader.ReadToEnd();
                                    tapPage1.TabPages[i].Text = $"вкладка {i + 1}";
                                }
                                openInfo.Add(i.ToString());
                                openInfo.Add(oldLink[oldLink.Length - 1]);
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("Упс... Не удалось получить доступ к одному из открытых ранее файлов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                File.WriteAllText($"log{i}.txt", "");
                            }
                        }
                    }
                    OldParamentrs(sender, e);
                }
                else
                {
                    OpenWithHelp(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Установка старых параметров
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void OldParamentrs(object sender, EventArgs e)
        {
            try
            {
                //Считывание нужного лога и запсук переключения темы, по потребности
                if ("black" == File.ReadAllText("LogColor.txt"))
                {
                    BlackThemeToolStripMenuItem_Click(sender, e);
                }
                //Чтение лога содержащего информацию об автосохранении
                //И установка нужных значений
                stepSave = int.Parse(File.ReadAllText("rateLog.txt"));
                if (stepSave != 0)
                {
                    //Изменение барьеров, равных новому шагу
                    LowBarder = textBoxes[workinArea].TextLength / stepSave;
                    UpBarder = LowBarder + stepSave;
                }
                //вывод на экран
                textBox1.Text = $"Частота автосохранений: {stepSave}";
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, ошибка загрузки старых настроек", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Открытие диалога сохранения
        /// </summary>
        private void OpenDialogSave()
        {
            try
            {
                Stream myStream;
                var fileContent = string.Empty;
                var filePath = string.Empty;
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.FileName = $"вкладка {tapPage1.SelectedIndex + 1}";
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*rtf)|*.rtf|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if ((myStream = saveFileDialog1.OpenFile()) != null)
                        {
                            filePath = saveFileDialog1.FileName;
                            byte[] array = System.Text.Encoding.Default.GetBytes(textBoxes[workinArea].Text);
                            // запись массива байтов в файл
                            myStream.Write(array, 0, array.Length);
                            File.AppendAllText($"log{workinArea}.txt", filePath);
                            myStream.Close();
                            switchSaves[workinArea] = false;
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, ошибка запуска диалога сохранения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Событие сохранения документа.
        /// 
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool flagOpens = false;
            try
            {
                //Просмотр не является ли файл ранее открытым, тогда сохранять туда же где был открыт, не выбрасывая диалога сохранения.
                for (int i = 0; i < openInfo.Count; i = i + 2)
                {
                    if (int.Parse(openInfo[i]) == workinArea)
                    {
                        flagOpens = true;
                        File.WriteAllText(openInfo[i + 1], textBoxes[workinArea].Text);
                    }
                    //Если не является, открыть диалог.
                }
                if (!flagOpens)
                {
                    OpenDialogSave();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка сохранения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        /// <summary>
        /// Открыть диалог открытия.
        /// </summary>
        private void OpenDialogOpen()
        {
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|rtf files (*rtf)|*.rtf|All files (*.*)|*.*";
                    openFileDialog.RestoreDirectory = true;
                    
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        //Добавить в список открытых файлов ,открытый сейчас и добавить туда же номер рабочей области
                        openInfo.Add(workinArea.ToString());
                        openInfo.Add(filePath);
                        //Сохранить ссылку в лог соответсвующей вкладки
                        File.AppendAllText($"log{workinArea}.txt", filePath);
                        var fileStream = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                            textBoxes[workinArea].Text = fileContent;
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, ошибка запуска диалога открытия", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Открытие файла.
        /// Прокручивание вкладок на поиск свободной.
        /// Если нашлась, записывание туда файла ,иначе вывести сообщение и недостатке вкладок.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flagOpenPlace = false;
            try
            {
                for (int i = 1; i < 4; i++)
                {
                    if (openerTab[i] == false)
                    {
                        flagOpenPlace = true;
                        workinArea = i;
                        tapPage1.SelectedIndex = i;
                        break;
                    }

                }
                if (flagOpenPlace)
                {
                    OpenDialogOpen();
                }
                else
                {
                    MessageBox.Show("Ой, к сожалению вкладки кончились, закройте одну из них", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка открытия", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Очистка рабочих областей(Закрытие документов).
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void DeleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < 4; i++)
                {
                    //Прокручиваем вкладки и по очереди удаляем.
                    workinArea = i;
                    tapPage1.SelectedIndex = i;
                    DeleteToolStripMenuItem_Click(sender, e);

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                //вопрос желаете ли сохранить.
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveAllToolStripMenuItem_Click(sender, e);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при закрытии", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Метод для открытия с помощью.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void OpenWithHelp(object sender, EventArgs e)
        {

            var fileContent = string.Empty;
            var filePath = string.Empty;
            try
            {
                //считываем ссылку.
                filePath = globalArgs[0];
                using (StreamReader reader = new StreamReader(filePath))
                {
                    //Читаем файл.
                    fileContent = reader.ReadToEnd();
                    textBoxes[workinArea].Text = fileContent;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка открытия по умолчанию", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик изменения вкладки.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Изменение соответствующих переключателей.
                openerTab[tapPage1.SelectedIndex] = true;
                workinArea = tapPage1.SelectedIndex;
                //Изменение названия вкладки
                tapPage1.TabPages[tapPage1.SelectedIndex].Text = $"вкладка {tapPage1.SelectedIndex + 1}";
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка изменения вкладки", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        /// <summary>
        /// Сохранить все.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Прокручиваем все вкладки, если какая то открыта, то сохраняем ее.
                for (int i = 0; i < 4; i++)
                {
                    if (openerTab[i])
                    {
                        workinArea = i;
                        tapPage1.SelectedIndex = i;

                        SaveToolStripMenuItem_Click(sender, e);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка сохранения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Событие изменения текста.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
               //Если докумен был открыт и он перешел через один из порогов автосохранения, то сохранить его
                for (int i = 0; i < openInfo.Count; i = i + 2)
                {
                    if (int.Parse(openInfo[i]) == workinArea)
                    {                     
                        if ((textBoxes[workinArea].TextLength < LowBarder | textBoxes[workinArea].TextLength > UpBarder) && stepSave > 0)
                        {
                            SaveToolStripMenuItem_Click(sender, e);
                            LowBarder = textBoxes[workinArea].TextLength / stepSave;
                            UpBarder = LowBarder + stepSave;
                        }
                    }
                }
                //Изменяем значение выключателей.
                openerTab[workinArea] = true;
                switchSaves[workinArea] = true;
                //Если вкладка была только открыта(ее название Неиспользуемая вкладка), изменить ее название
                if (tapPage1.TabPages[workinArea].Text[0] == 'Н')
                {
                    tapPage1.TabPages[workinArea].Text = $"вкладка {workinArea + 1}";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка записи текста", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Изменение стиля текста.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StyleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog1.ShowColor = true;
                fontDialog1.Font = textBoxes[workinArea].Font;
                fontDialog1.Color = textBoxes[workinArea].ForeColor;
                //Запуск диалога
                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    textBoxes[workinArea].SelectionFont = fontDialog1.Font;
                    textBoxes[workinArea].SelectionColor = fontDialog1.Color;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка выбора стиля", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        /// <summary>
        /// Включение светлой темы, просто по очереди изменяем нужные цвета.
        /// и записываем их в нужный лог
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void WhiteThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                menuStrip1.BackColor = SystemColors.Control;
                this.BackColor = SystemColors.Control;
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    menuStrip1.Items[i].ForeColor = Color.Black;
                }

                for (int i = 0; i < 4; i++)
                {
                    textBoxes[i].BackColor = SystemColors.Window;
                    textBoxes[i].SelectionColor = Color.Black;
                }
                File.WriteAllText("LogColor.txt", "while");
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка выбора темы", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Включение темной темы, изменение нужный цветов по очереди и изменение значения лога темы 
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void BlackThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                menuStrip1.BackColor = Color.Gray;
                this.BackColor = Color.FromArgb(48, 53, 56);
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    menuStrip1.Items[i].ForeColor = System.Drawing.Color.White;
                }
                for (int i = 0; i < 4; i++)
                {
                    textBoxes[i].BackColor = System.Drawing.Color.FromArgb(27, 63, 84);
                    textBoxes[i].SelectionColor = System.Drawing.Color.White;
                }
                File.WriteAllText("LogColor.txt", "black");
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка выбора темы", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Установка Шага автосохранений в 100 символов и изменения новых границ сохранения.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StepSave100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stepSave = 100;
                textBox1.Text = $"Частота автосохранений: {stepSave}";
                LowBarder = textBoxes[workinArea].TextLength / stepSave;
                UpBarder = LowBarder + stepSave;
                ///изменение значения лога.
                File.WriteAllText("rateLog.txt", "100");
            }
            catch
            {
                //Экстренное отключение.
                MessageBox.Show("Что-то пошло не так,\nавтосохранение будет выключено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stepSave = 0;
                textBox1.Text = $"Частота автосохранений: {stepSave}";
                File.WriteAllText("rateLog.txt", "0");
            }
        }
        /// <summary>
        /// Установка Шага автосохранений в 0 символов(выкл) и изменения новых границ сохранения.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StepSave0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stepSave = 0;
                textBox1.Text = $"Частота автосохранений: {stepSave}";
                //Изменяем значение лога.
                File.WriteAllText("rateLog.txt", "0");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так,\nавтосохранение будет выключено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        /// <summary>
        /// Установка Шага автосохранений в 10 символов и изменения новых границ сохранения.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StepSave10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stepSave = 10;
                textBox1.Text = $"Частота автосохранений: {stepSave}";
                LowBarder = textBoxes[workinArea].TextLength / stepSave;
                UpBarder = LowBarder + stepSave;
                //Изменяем значение лога.
                File.WriteAllText("rateLog.txt", "10");
            }
            catch
            {
                //Экстренное отключение.
                MessageBox.Show("Что-то пошло не так,\nавтосохранение будет выключено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stepSave = 0;
                textBox1.Text = $"Частота автосохранений: {stepSave}";

            }
        }
        /// <summary>
        /// Установка Шага автосохранений в 1000 символов и изменения новых границ сохранения.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StepSave1000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stepSave = 1000;
                textBox1.Text = $"Частота автосохранений: {stepSave}";
                LowBarder = textBoxes[workinArea].TextLength / stepSave;
                UpBarder = LowBarder + stepSave;
                File.WriteAllText("rateLog.txt", "1000");
            }
            catch
            {
                //Экстренное отключение.
                MessageBox.Show("Что-то пошло не так,\nавтосохранение будет выключено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stepSave = 0;
                textBox1.Text = $"Частота автосохранений: {stepSave}";

            }
        }
        /// <summary>
        /// Установка Шага автосохранений в 10000 символов и изменения новых границ сохранения.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StepSave10000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stepSave = 10000;
                textBox1.Text = $"Частота автосохранений: {stepSave}";
                LowBarder = textBoxes[workinArea].TextLength / stepSave;
                UpBarder = LowBarder + stepSave;
                File.WriteAllText("rateLog.txt", "10000");
            }
            catch
            {
                //Экстренное отключение.
                MessageBox.Show("Что-то пошло не так,\nавтосохранение будет выключено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stepSave = 0;
                textBox1.Text = $"Частота автосохранений: {stepSave}";

            }
        }
        /// <summary>
        /// Очень хот кнопка.(сохранить)
        /// Хочешь с*кос по С# коду? 
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Form_KeyDownS(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.S)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                    e.SuppressKeyPress = true;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Очень хот кнопка(сохранить все)
        /// Меееедленно погружается в клавиатуру
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Form_KeyDownShiftS(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.S)
                {
                    tapPage1.SelectedIndex = 0;
                    SaveAllToolStripMenuItem_Click(sender, e);
                    e.SuppressKeyPress = true;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Горячие клавиши на закрытие приложения
        /// Ля, ну раз закрыл , то закрыл, значит обойдешься.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Form_KeyDownClose(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.E)
                {
                    this.Close();
                    e.SuppressKeyPress = true;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Добавить новую вкладку.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Form_KeyDownAddPage(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    int threePage = -1;
                    for (int i = 0; i < 4; i++)
                    {
                        if (openerTab[i] == false)
                        {
                            threePage = i;
                            break;
                        }

                    }
                    if (threePage > -1)
                    {
                        tapPage1.SelectedIndex = threePage;

                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        MessageBox.Show("Нет свободных вкладок");
                        e.SuppressKeyPress = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Открыть документ в новом окне.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Form_KeyDownNewForm(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.N)
                {
                    Form1 f2 = new Form1(globalArgs);
                    f2.Show();
                    e.SuppressKeyPress = true;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Закрытие одного документа, оно же удаление содержимого
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Если об этом документа есть информация как об открытом, то стереть ее.
                for (int i = 0; i < openInfo.Count; i=i+2)
                {
                    if (int.Parse(openInfo[i]) == workinArea)
                    {
                        openInfo[i] = "-1";
                        openInfo[i + 1] = "delete";
                    }
                }
                //Если это не первая вкладка, то кроме очистки содержимого, изменить.
                //название вкладки и переключить выключатили открытия и сохранения.
                if (workinArea != 0)
                {
                    textBoxes[workinArea].Clear();
                    switchSaves[workinArea] = false;
                    openerTab[workinArea] = false;
                    tapPage1.TabPages[workinArea].Text = "Неиспользуемая вкладка";
                    File.WriteAllText($"log{workinArea}.txt", "");
                }
                else
                {
                    textBoxes[0].Clear();
                    tapPage1.SelectedIndex = 0;
                    openerTab[0] = true;
                    File.WriteAllText($"log{0}.txt", "");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка выбора темы удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        /// <summary>
        /// Выреать.
        /// Контекстное меню, при выборе операции, вызвать название соответствующих горячих клавиш.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Cut_Click(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("^{X}");
            }
            catch
            {

            }
        }
        /// <summary>
        /// Копировать.
        /// Контекстное меню, при выборе операции, вызвать название соответствующих горячих клавиш.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Copy_Click(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("^{C}");
            }
            catch
            {

            }
        }
        /// <summary>
        /// Вставить.
        /// Контекстное меню, при выборе операции, вызвать название соответствующих горячих клавиш.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void Paste_Click(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("^{V}");
            }
            catch
            {

            }

        }
        /// <summary>
        /// Выделить все.
        /// Контекстное меню, при выборе операции, вызвать название соответствующих горячих клавиш.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void SelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxes[workinArea].SelectAll();
            }
            catch
            {

            }
        }
        /// <summary>
        /// Выбрать формат, запуск диалога по выбору формата.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        void ChangeFormat_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog1.ShowColor = true;
                fontDialog1.Font = textBoxes[workinArea].Font;
                fontDialog1.Color = textBoxes[workinArea].ForeColor;

                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    textBoxes[workinArea].SelectionFont = fontDialog1.Font;
                    textBoxes[workinArea].SelectionColor = fontDialog1.Color;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, ошибка выбора стиля", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void CloseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }




}
