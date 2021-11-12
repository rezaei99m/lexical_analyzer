using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lexical_Analyzer.Business_Layer;
namespace Lexical_Analyzer
{
    /// <summary>
    /// Interaction logic for LA.xaml
    /// </summary>
    public partial class LA : Window
    {
        public LA()
        {
            InitializeComponent();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Lexicer lexicer = new Lexicer(inputBox.Text);
            //lexicer.fnGenerateAllToken();
            //MessageBox.Show(lexicer.inOrderTokens.Count.ToString());
            //for (int i = 0; i < lexicer.inOrderTokens.Count; i++)
            //{
            //    UI.fnDisplayTokens(tokenDisplay, lexicer.inOrderTokens[i], i);
            //}
            ////Token temp = new Token();
            //temp.fnSetAttributeName("mahdi");
            //temp.fnSetAttributeValue("123");

            //for (int i = 0; i < 100; i++)
            //{
            //    UI.fnDisplayTokens(tokenDisplay, temp, i);
            //}

            //for (int i = 1; i < 100; i++)
            //{
            //    UI.fnDisplaySymboleTable(symboleTable, temp, i);
            //}

            //for (int i = 1; i < 100; i++)
            //{
            //    UI.fnDisplayError(errorList, "error", i);
            //}

            /***/


        }
    }
}
