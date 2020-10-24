using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//программа пропускает пробелы при переводе на азбуку Морза, есть возможность перевода и кириллиццы и латиницы
//проверка на допустимость символов производиться при самом переводе, пользователю даётся возможность продолжить перевод при ошибке,
//но неизвестный символ обозначается как ········ в азбуке Морза обозначает ошибку
namespace Dz_33
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] Morse = new string[]
    {"аa·−","бb−···","вw·−−","гg−−·","дd−··","еe·","ёe·","жv···−","зz−−··","иi··","йj·−−−","кk−·−","лl·−··","мm−−","нn−·","оo−−−","пp·−−·","рr·−·","сs···","тt−","уu··−","фf··−·","хh····",
"цc−·−·","чч−−−·","шш−−−−","щq−−·−","ъъ−−·−−","ыy−·−−","ьx−··−","ээ··−··","юю··−−","яя·−·−","11·−−−−","22··−−−","33···−−","44····−","55·····","66−····","77−−···","88−−−··","99−−−−·","00−−−−−","..······",",,·−·−·−","::−−−···",";;−·−·−·","((−·−−·−","))−·−−·−","''·−−−−·","\"\"·−··−·",
"——−····−","\\\\−··−·","__··−−·−","??··−−··","!!−−··−−","++·−·−·","//−···−","--−····−"};
            string stroutput = "", strinput = tbInput.Text.ToLower(), err = "········"; ;
            bool f;
            try
            {
                for (int i = 0; i < strinput.Length; i++)
                {
                    f = false;
                    foreach (string cop in Morse)
                    {
                        if (cop.IndexOf(strinput[i]) == 0 || cop.IndexOf(strinput[i]) == 1)
                        {
                            stroutput += cop.Remove(0, 2);
                            f = true;
                            break;
                        }
                        if (Char.IsWhiteSpace(strinput[i]))
                        {
                            f = true;
                            break;
                        }
                    }
                    if (f == true)
                        continue;
                    var result = MessageBox.Show($@"К сожалению символ '{strinput[i]}' не удалось преобразовать!
Возможно он отсутствует в базе.
Желаете ли вы продолжить перекодировку? Если да, то этот символ будет отмечен как '{err}'.",
                                     "Ошибка!",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Error);
                    if (result == MessageBoxResult.Yes)
                    {
                        stroutput += err;
                    }
                    else
                    {

                        stroutput = string.Empty;
                        break;
                    }

                }
                tbOutput.Text = stroutput;
            }
            catch (OutOfMemoryException) 
            {
              var result=MessageBox.Show("К сожалению произошла ошибка связанная с нехваткой памяти",
                                "Ошибка!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes) 
                {
                    tbInput.Clear();
                    tbOutput.Clear();
                }
            }
        }
    }
}
