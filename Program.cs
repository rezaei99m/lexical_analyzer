using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            State s0 = new State("0", "NaN - s0");
            State s1 = new State("1", "NaN - s1");
            State s2 = new State("2", "Delim", true);
            State s3 = new State("3", "NaN - s3");
            State s4 = new State("4", "KEYWORD || IDENTIFIER", true);
            State s5 = new State("5", "NaN - s5");
            State s6 = new State("6", "EQ");
            State s7 = new State("7", "NaN - s7");
            State s8 = new State("8", "NE");
            State s9 = new State("9", "NaN - s9");
            State s10 = new State("10", "LE");
            State s11 = new State("11", "LT", true);
            State s12 = new State("12", "NaN - s12");
            State s13 = new State("13", "GE");
            State s14 = new State("14", "GT", true);
            State s15 = new State("15", "NaN - s15");
            State s16 = new State("16", "NaN - s16");
            State s17 = new State("17", "NaN - s17");
            State s18 = new State("18", "NaN - s18");
            State s19 = new State("19", "NaN - s19");
            State s20 = new State("20", "NaN - s20");
            State s21 = new State("21", "SCI", true);
            State s22 = new State("22", "INT", true);
            State s23 = new State("23", "REAL", true);
            State s24 = new State("24", "PUNCTUATION");
            State s25 = new State("25", "NaN - s25");
            State s26 = new State("26", "STR");
            State s27 = new State("27", "ASSIGN", true);
            State s28 = new State("28", "NaN - s28");
            State s29 = new State("29", "INC");
            State s30 = new State("30", "ADD_ASSIGN");
            State s31 = new State("31", "ADD", true);
            State s32 = new State("32", "NaN - s32");
            State s33 = new State("33", "DEC");
            State s34 = new State("34", "SUB_ASSIGN");
            State s35 = new State("35", "SUB", true);
            State s36 = new State("36", "NaN - s36");
            State s37 = new State("37", "AND");
            State s38 = new State("38", "BITWISE_OP", true);
            State s39 = new State("39", "NaN - s39");
            State s40 = new State("40", "OR");
            State s41 = new State("41", "BITWISE_OP", true);
            State s42 = new State("42", "NaN - s42");
            State s43 = new State("43", "NaN - s43");
            State s44 = new State("44", "NEW_LINE");
            State s45 = new State("45", "NaN - s45");
            State s46 = new State("46", "NaN - s46");
            State s47 = new State("47", "COMMENT");
            State s48 = new State("48", "DIV_ASSIGN");
            State s49 = new State("49", "DIV", true);
            State s50 = new State("50", "NaN - s50");
            State s51 = new State("51", "MUL_ASSIGN");
            State s52 = new State("52", "MUL", true);
            State s53 = new State("53", "NOT", true);

            var States = new List<State> {  s0, s1, s2, s3, s4, s5, s6, s7, s8, s9,
                                            s10, s11, s12, s13, s14, s15, s16, s17, s18, s19,
                                            s20, s21, s22, s23, s24, s25, s26, s27, s28, s29,
                                            s30, s31, s32, s33, s34, s35, s36, s37, s38, s39,
                                            s40, s41, s42, s43, s44, s45, s46, s47, s48, s49,
                                            s50, s51, s52, s53};

            var sigma = new List<string> { };

            /************ Digit ************/
                var digit = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            /************ Others_Except Digit and e and E ************/
                var other_except_digitANDsmalleANDbige = new List<string>{ };
                for (int i = 0; i < 128; i++)
                {
                    if (digit.Exists(a => a == (((char)i).ToString()).ToString()) == true || (char)i == 'e' || (char)i == 'E') continue;
                    other_except_digitANDsmalleANDbige.Add((((char)i).ToString()).ToString());
                }

            /************ Others_Except Digit  ************/
                var other_except_digit = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if (digit.Contains(((char)i).ToString())) continue;
                    other_except_digit.Add(((char)i).ToString());
                }


            /************* English Alphabet ************/
                var englishAlphabet = new List<string> { };
                // Big Alphabet
                for (int i = 65; i < 91; i++)
                {
                    englishAlphabet.Add(((char)i).ToString());
                }
                // Small Alphabet
                for (int i = 97; i < 123; i++)
                {
                    englishAlphabet.Add(((char)i).ToString());
                }

            /************ English Alphabet + '_' ************/
                var englishAlphabetPLUS_ = new List<string> { "_" };
                // Big Alphabet
                for (int i = 65; i < 91; i++)
                {
                    englishAlphabetPLUS_.Add(((char)i).ToString());
                }
                // Small Alphabet
                for (int i = 97; i < 123; i++)
                {
                    englishAlphabetPLUS_.Add(((char)i).ToString());
                }

            /************ English Alphabet + '_' + Digits ************/
                var englishAlphabetPLUS_PLUSdigits = new List<string> {   "_", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                // Big Alphabet
                for (int i = 65; i < 91; i++)
                {
                    englishAlphabetPLUS_PLUSdigits.Add(((char)i).ToString());
                }
                // Small Alphabet
                for (int i = 97; i < 123; i++)
                {
                    englishAlphabetPLUS_PLUSdigits.Add(((char)i).ToString());
                }

            /************ Others_Except English Alphabet + '_' + Digits ************/
                var other_except_englishAlphabetPLUS_PLUSdigits = new List<string>();
                other_except_englishAlphabetPLUS_PLUSdigits.Add(Environment.NewLine.ToString());
                for (int i = 0; i < 128; i++)
                {
                    if (englishAlphabetPLUS_PLUSdigits.Exists(a => a == ((char)i).ToString()) == true) continue;
                    other_except_englishAlphabetPLUS_PLUSdigits.Add(((char)i).ToString());
                }

            /************ Others_Except '=' ************/
                var other_except_equal = new List<string>();
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '=') continue;
                    other_except_equal.Add(((char)i).ToString());
                }

            /************ Others_Except '!' ************/
                var other_except_exclamation = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '!') continue;
                    other_except_exclamation.Add(((char)i).ToString());
                }

            /************ Others_Except '<' ************/
                var other_except_lessBracket = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '<') continue;
                    other_except_lessBracket.Add(((char)i).ToString());
                }

            /************ Others_Except '>' ************/
                var other_except_bigerBracket = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '>') continue;
                    other_except_bigerBracket.Add(((char)i).ToString());
                }

            /************ Others_Except '.' and 'e' and 'E' ************/
                var other_except_dotANDsmalleANDbige = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '.' || (char)i == 'e' || (char)i == 'E') continue;
                    other_except_dotANDsmalleANDbige.Add(((char)i).ToString());
                }

            /************ Others_Except '=' and '*' ************/
                var other_except_starANDequal = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '*' || (char)i == '=' ) continue;
                    other_except_starANDequal.Add(((char)i).ToString());
                }

            /************ Others_Except '=' and '-' ************/
                var other_except_minusANDequal = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '-' || (char)i == '=') continue;
                    other_except_minusANDequal.Add(((char)i).ToString());
                }

            /************ Others_Except '=' and '+' ************/
                var other_except_plusANDequal = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '+' || (char)i == '=') continue;
                    other_except_plusANDequal.Add(((char)i).ToString());
                }

            /************ Others_Except '&' ************/
                var other_except_and = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '&' ) continue;
                    other_except_and.Add(((char)i).ToString());
                }

            /************ Others_Except '|' ************/
                var other_except_or = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '|') continue;
                    other_except_or.Add(((char)i).ToString());
                }

            /************ Others_Except '/' and '=' and '*' ************/
                var other_except_equalANDslashANDstar = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '=' || (char)i == '/' || (char)i == '*') continue;
                    other_except_equalANDslashANDstar.Add(((char)i).ToString());
                }

            /************ Others_Except '*' ************/
                var other_except_star = new List<string> { };
                other_except_star.Add("\r\n");
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '*') continue;
                    other_except_star.Add(((char)i).ToString());
                }

            /************ Others_Except '/' ************/
                var other_except_slash = new List<string> { };
                other_except_slash.Add("\r\n");
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '/') continue;
                    other_except_slash.Add(((char)i).ToString());
                }

            /************ Others_Except '\n' ************/
                var other_except_newline = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '\n') continue;
                    other_except_newline.Add(((char)i).ToString());
                }

            /************ Others_Except '"' ************/
                var other_except_quation = new List<string> { };
                for (int i = 0; i < 128; i++)
                {
                    if ((char)i == '"') continue;
                    other_except_quation.Add(((char)i).ToString());
                }

            
            /************ Delimiter ************/
                var delim = new List<string> { "\r", "\t", Environment.NewLine.ToString(), "\n", " ", "\r\n" };
                                
            /************ Punctuation ************/
                var punctuation = new List<string> {  ";", ":", "{", "}", "[", "]", "(", ")", ".", ","};

            /************ Others_Except delim ************/
                var other_except_delim = new List<string>();
                for (int i = 0; i < 128; i++)
                {
                    if (i == 32 || i == 9 || i == 10) continue;
                    other_except_delim.Add(((char)i).ToString());
                }
                
            var delta = new List<Transition> { new Transition(s0, delim, s1),
                                               new Transition(s1, delim, s1),
                                               new Transition(s1, other_except_delim, s2),
                                               new Transition(s0, englishAlphabetPLUS_, s3),
                                               new Transition(s3, englishAlphabetPLUS_PLUSdigits, s3),
                                               new Transition(s3, other_except_englishAlphabetPLUS_PLUSdigits, s4),
                                               new Transition(s0, new List<string>{ "=" }, s5),
                                               new Transition(s5, other_except_equal, s27),
                                               new Transition(s5, new List<string>{ "=" }, s6),
                                               new Transition(s0, new List<string>{ "!" }, s7),
                                               new Transition(s7, other_except_exclamation, s53),
                                               new Transition(s7, new List<string>{ "=" }, s8),
                                               new Transition(s0, new List<string>{ "<" }, s9),
                                               new Transition(s9, new List<string>{ "=" }, s10),
                                               new Transition(s9, other_except_lessBracket, s11),
                                               new Transition(s0, new List<string>{ ">" }, s12),
                                               new Transition(s12, new List<string>{ "=" }, s13),
                                               new Transition(s12, other_except_bigerBracket, s14),
                                               new Transition(s0, digit, s15),
                                               new Transition(s15, digit, s15),
                                               new Transition(s15, other_except_dotANDsmalleANDbige, s22),
                                               new Transition(s15, new List<string>{ "." }, s16),
                                               new Transition(s15, new List<string>{ "e", "E" }, s18),
                                               new Transition(s16, digit, s17),
                                               new Transition(s17, digit, s17),
                                               new Transition(s17, other_except_digitANDsmalleANDbige, s23),
                                               new Transition(s17, new List<string>{ "e", "E"}, s18),
                                               new Transition(s18, new List<string>{ "-", "+"}, s19),
                                               new Transition(s18, digit, s20),
                                               new Transition(s19, digit, s20),
                                               new Transition(s20, digit, s20),
                                               new Transition(s20, other_except_digit, s21),
                                               new Transition(s0, punctuation, s24),
                                               new Transition(s0, new List<string>{ "*" }, s50),
                                               new Transition(s50, new List<string>{ "=" }, s51),
                                               new Transition(s50, other_except_starANDequal, s52),
                                               new Transition(s0, new List<string>{ "-" }, s32),
                                               new Transition(s32, new List<string>{ "-" }, s33),
                                               new Transition(s32, new List<string>{ "=" }, s34),
                                               new Transition(s32, other_except_minusANDequal, s35),
                                               new Transition(s0, new List<string>{ "+" }, s28),
                                               new Transition(s28, new List<string>{ "+" }, s29),
                                               new Transition(s28, new List<string>{ "=" }, s30),
                                               new Transition(s28, other_except_plusANDequal, s31),
                                               new Transition(s0, new List<string>{ "&" }, s36),
                                               new Transition(s36, new List<string>{ "&" }, s37),
                                               new Transition(s36, other_except_and, s38),
                                               new Transition(s0, new List<string>{ "|" }, s39),
                                               new Transition(s39, new List<string>{ "|" }, s40),
                                               new Transition(s39, other_except_or, s41),
                                               new Transition(s0, new List<string>{ "/" }, s42),
                                               new Transition(s42, new List<string>{ "=" }, s48),
                                               new Transition(s42, other_except_equalANDslashANDstar, s49),
                                               new Transition(s42, new List<string>{ "*" }, s45),
                                               new Transition(s42, new List<string>{ "/" }, s43),
                                               new Transition(s45, other_except_star, s45),
                                               new Transition(s45, new List<string>{ "*" }, s46),
                                               new Transition(s46, other_except_slash, s45),
                                               new Transition(s46, new List<string>{ "/" }, s47),
                                               new Transition(s46, new List<string>{ "/" }, s47),
                                               new Transition(s43, other_except_newline, s43),
                                               new Transition(s43, new List<string>{ "\n" }, s44),
                                               new Transition(s0, new List<string>{ "\"" }, s25),
                                               new Transition(s25, new List<string>{ "\"" }, s26),
                                               new Transition(s25, other_except_quation, s25),
            };

            var S0 = s0;
            var finalStates = new List<State> { s2, s4, s26, s27, s6,
                                                s53, s8, s11, s10, s13,
                                                s14, s21, s22, s23, s24,
                                                s52, s51, s34, s33, s35,
                                                s30, s29, s31, s38, s37,
                                                s41, s40, s44, s47, s48, s49 };

            var FSM = new DeterministicFSM(States, sigma, delta, S0, finalStates);
            //Console.WriteLine((int)Environment.NewLine.ToCharArray()[0]);
            string input = null;
            int temp = 0;
            while ((char)temp != '$')
            {
                temp = Console.Read();
                input += (char)temp;
            }
            FSM.lexicer(input);
            Console.ReadKey();
        }
    }
}
