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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lexical_Analyzer.Business_Layer;
namespace Lexical_Analyzer
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //State Ns0 = new State("0", ())
            State s0 = new State("0", "NaN - s0");
            State s1 = new State("1", "NaN - s1");
            State s2 = new State("2", "SEOP");    // Smaller than or equal
            State s3 = new State("3", "SOP");     // Smaller than
            State s4 = new State("4", "NaN - s4");    
            State s5 = new State("5", "GEOP");    // Greater than or equal
            State s6 = new State("6", "GOP");     // Greater than
            State s7 = new State("7", "NaN - s7");     
            State s8 = new State("8", "compareOP"); // compareOP     
            State s9 = new State("9", "assignOP");  // assignOP     
            State s10 = new State("10", "NaN - s10");     
            State s11 = new State("11", "ID");  // ID
            State s12 = new State("12", "NaN - s12");
            State s13 = new State("13", "NaN - s13");
            State s14 = new State("14", "NaN - s14");
            State s15 = new State("15", "NaN - s15");
            State s16 = new State("16", "NaN - s16");
            State s17 = new State("17", "NaN - s17");
            State s18 = new State("18", "number");
            State s19 = new State("19", "number");
            State s20 = new State("20", "number");
            
            var States = new List<State> { s0, s1, s2, s3, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20 };
            var sigma = new List<char> { };

            var digit = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var letter = new List<char> { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z', '_' };
            var other1 = new List<char> { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z', '_', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' '};
            var digit_letter = new List<char> { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z', '_', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var letter_1 = new List<char> { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z', '_', '~', '`', '!', '@', '#', '$', '%', '^', '&', '(', ')', '|', '[', ']', ':', ';', '"', '/', '?', '*', ' '};
            var Ndigit_letter = new List<char> { '~', '`', '!', '@', '#', '$', '%', '^', '&', '(', ')', '|', '[', ']', ':', ';', '"', '/', '?', '.', ' '};
            var delim = new List<char> { ' ', '\t', '\n' };
            var delta = new List<Transition> {  new Transition(s0, new List<char>{ '=' }, s7),
                                                new Transition(s0, new List<char>{ '<' }, s1),
                                                new Transition(s0, new List<char>{ '>' }, s4),
                                                new Transition(s0, letter, s10),
                                                new Transition(s0, digit, s12),
                                                new Transition(s7, new List<char>{ '=' }, s8),
                                                new Transition(s7, other1, s9),
                                                new Transition(s1, new List<char>{ '=' }, s2),
                                                new Transition(s1, other1, s3),
                                                new Transition(s4, new List<char>{ '=' }, s5),
                                                new Transition(s4, other1, s6),
                                                new Transition(s10, digit_letter, s10),
                                                new Transition(s10, Ndigit_letter, s11),
                                                new Transition(s12, new List<char>{ 'e', 'E' }, s15),
                                                new Transition(s12, new List<char>{ '.' }, s13),
                                                new Transition(s12, letter_1, s20),
                                                new Transition(s12, digit, s12),
                                                new Transition(s13, digit, s14),
                                                new Transition(s14, digit, s14),
                                                new Transition(s14, letter_1, s19),
                                                new Transition(s14, new List<char>{ 'e', 'E'}, s15),
                                                new Transition(s15, new List<char>{ '-', '+'}, s16),
                                                new Transition(s15, digit, s17),
                                                new Transition(s16, digit, s17),
                                                new Transition(s17, digit, s17),
                                                new Transition(s17, letter_1, s18),
                                             
            };
            var S0 = s0;
            var finishStates = new List<State> { s8, s9, s2, s3, s5, s6, s11, s20, s19, s18 };
            var FSM = new DeterministicFSM(States, sigma, delta, S0, finishStates);
            FSM.Accepts("==123");
            
            Window a = new LA();
            a.Show();
            

        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
