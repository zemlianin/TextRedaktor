using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRedaktor
{
    static class Program
    {
       /// <summary>
       /// ����, ��� ������
       /// </summary>
       /// <param name="args">������ ������������ ��� ������� "������� � �������"</param>
        [STAThread]
        static void Main(string[] args)
        {
          
                try
                {
                    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(args));
                }
                catch (Exception)
                {
                    MessageBox.Show("������ � ����");
                    
                }
          
            
        }
    }
}
