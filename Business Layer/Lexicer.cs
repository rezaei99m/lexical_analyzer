//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections;
//using Lexical_Analyzer.Business_Layer;
//using System.Windows.Controls;

//namespace Lexical_Analyzer.Business_Layer
//{
//    public class Lexicer
//    {
//        public Lexicer(string input)
//        {
//            sInput = input;
//        }
//        /// <summary>
//        /// Fields and properties
//        /// </summary>
//        private string sInput;

//        private Dictionary<string, Token> symboleTable = new Dictionary<string, Token>();   //we use the value as the key for each down table
//        private Dictionary<string, Token> numberTable = new Dictionary<string, Token>();
//        private List<string> listErrorList = new List<string>();

//        private string buffer = "";

//        int iSymboleTableCounter = 0;
//        int iNumberTableCounter = 0;

//        public List<string> keywords = new List<string>(){
//                "using","import","include","asm","auto","bool","break","case","catch","char","class","const","const_cast",
//                "continue","default","delete","do","double","dynamic_cast","else","enum","explicit",
//                "export","extern","false","float","for","friend","goto","if","inline","int","long",
//                "main","mutable","namespace","new","operator","private","protected","public",
//                "register","reinterpret_cast","return","short","signed","sizeof","static",
//                "static_cast","struct","switch","template","this","throw","true","try","typedef",
//                "typeid","typename","union","unsigned","virtual","void","volatile","wchar_t","while", "and", "or"};

//        public List<Token> inOrderTokens = new List<Token>();  //Here we add all Token and then show them in the Token table and for other table we have their dictionary so we can use that as the refrence for displaying the result in the symbole table or others table.
//        /// <summary>
//        /// Functions
//        /// </summary>
//        public void fnsetInput(string _sInput)
//        {
//            sInput = _sInput;
//        }

//        public void fnAddToSymboleTable(Token temp)
//        {
//            symboleTable.Add(temp.fnGetAttributeValue(), temp);
            
//        }

//        public void fnAddToNumberTable(Token temp)
//        {
//            numberTable.Add(temp.fnGetAttributeValue(), temp);
//        }

//        public Dictionary<string, Token> fnGetSymboleTable()
//        {
//            return symboleTable;
//        }

//        public Dictionary<string, Token> fnGetNumberTable()
//        {
//            return numberTable;
//        }

//        public List<string> fnGetErrorList()
//        {
//            return listErrorList;
//        }
        

//        public void fnGenerateAllToken()
//        {
//            int iInputCharIndex = 0;
//            string _sInput = sInput + " ";
//            while (iInputCharIndex + 1 < _sInput.Length)
//            {
//                int rowCounterMainTokenTable = 0;
//                int rowCounterSymboleTable = 0;
//                int columnCounterSymboleTable = 0;
//                bool isNumberCreated = false;

//                // IDs and Keywords
//                if (char.IsLetter(_sInput[iInputCharIndex]) || _sInput[iInputCharIndex] == '_')
//                {
//                    //Console.WriteLine(" Enter Here - 1");
//                    buffer += _sInput[iInputCharIndex];
//                    iInputCharIndex++;
//                    if (!(char.IsLetter(_sInput[iInputCharIndex]) || _sInput[iInputCharIndex] == '_'))
//                    {
//                        //Console.WriteLine(" Enter Here - 2");
//                        // for checking that our token is the keyword or an ID
//                        bool bIsKeyword = false;
//                        for (int i = 0; i < keywords.Count; i++)
//                        {
//                            //Console.WriteLine(" Enter Here - 3");
//                            if (buffer == keywords[i])
//                            {
//                                //Console.WriteLine(" Enter Here - 4");
//                                Token res = new Token();
//                                res.fnSetAttributeName("Keyword");
//                                res.fnSetAttributeValue(buffer);
//                                inOrderTokens.Add(res);
//                                buffer = null;
//                                rowCounterMainTokenTable++;
//                                bIsKeyword = true;
//                                break;
//                            }
//                        }
//                        // for inserting our token to the related table and also to check that it wasn't exist there before
//                        if (bIsKeyword == false)
//                        {
//                            //Console.WriteLine(" Enter Here - 5");
//                            Token res = new Token();
//                            res.fnSetAttributeName(buffer);
//                            res.fnSetAttributeValue("NaN");
//                            if (symboleTable.Count == 0)
//                            {
//                                //Console.WriteLine(" Enter Here - 6");
//                                inOrderTokens.Add(res);
//                                buffer = null;
//                            }
//                            for (int i = 0; i < symboleTable.Count; i++)
//                            {
//                                //Console.WriteLine(" Enter Here - 7");
//                                if (symboleTable.ContainsKey(res.fnGetAttributeValue()))
//                                {
//                                    //Console.WriteLine(" Enter Here - 8");
//                                    //Console.WriteLine(res.fnGetAttributeValue() + " were added before");
//                                    // Here we return that the ID were before in the symbole table
//                                }
//                                else
//                                {
//                                    //Console.WriteLine(" Enter Here - 9");
//                                    symboleTable.Add(res.fnGetAttributeValue(), res);
//                                    inOrderTokens.Add(res);
//                                    buffer = null;
//                                }
//                            }
//                        }
//                    }
//                }
//                // Whitespaces
//                else if (char.IsWhiteSpace(_sInput[iInputCharIndex]))
//                {
//                    iInputCharIndex++;
//                }
//                // Numbers
//                else if (char.IsDigit(_sInput[iInputCharIndex]))
//                {
//                    bool E_e = false;
//                    bool dot = false;
//                    buffer += _sInput[iInputCharIndex];
//                    iInputCharIndex++;

//                    // Here we just check after the first number
//                    if (_sInput[iInputCharIndex] == '.')
//                    {
//                        // Error: 12.e || 12.E || 12..
//                        if (!(_sInput[iInputCharIndex + 1] == 'e' || _sInput[iInputCharIndex + 1] == 'E' || char.IsDigit(_sInput[iInputCharIndex + 1]))) throw new Exception("1 - Not a meaningful number.");
//                        dot = true;
//                    }
//                    else if (_sInput[iInputCharIndex] == 'e' || _sInput[iInputCharIndex] == 'E')
//                    {
//                        if (!(char.IsDigit(_sInput[iInputCharIndex + 1]) || _sInput[iInputCharIndex] == '+' || _sInput[iInputCharIndex] == '-')) throw new Exception("2 - Not a meaningful number.");
//                        E_e = true;
//                    }

//                    while ( !( dot || E_e) )
//                    {
//                        buffer += _sInput[iInputCharIndex];
//                        iInputCharIndex++;
//                        if (_sInput[iInputCharIndex] == '.')
//                        {
//                            // Error: 12.e || 12.E || 12..
//                            if (!(_sInput[iInputCharIndex + 1] == 'e' || _sInput[iInputCharIndex + 1] == 'E' || char.IsDigit(_sInput[iInputCharIndex + 1]))) throw new Exception("3 - Not a meaningful number.");
//                            dot = true;
//                        }
//                        else if (_sInput[iInputCharIndex] == 'e' || _sInput[iInputCharIndex] == 'E')
//                        {
//                            if (!(char.IsDigit(_sInput[iInputCharIndex + 1]) || _sInput[iInputCharIndex] == '+' || _sInput[iInputCharIndex] == '-')) throw new Exception("4 - Not a meaningful number.");
//                            E_e = true;
//                        }

//                        if (dot == false && E_e == false && char.IsWhiteSpace(_sInput[iInputCharIndex]))
//                        {
//                            break;
//                        }
//                    }

//                    //Console.WriteLine(buffer);
//                    //Console.WriteLine(_sInput[iInputCharIndex]);

//                    if (!char.IsWhiteSpace(_sInput[iInputCharIndex])) //123 '\s'
//                    {
//                        if (dot == true)   // If our number has a dot in it or not.
//                        {
//                            buffer += _sInput[iInputCharIndex];
//                            iInputCharIndex++;
//                            while (!E_e)
//                            {
//                                if (char.IsDigit(_sInput[iInputCharIndex]) /*|| ((_sInput[iInputCharIndex] == 'e' || _sInput[iInputCharIndex] == 'E') && !(_sInput[iInputCharIndex - 1] == '.'))*/)
//                                {
//                                    buffer += _sInput[iInputCharIndex];
//                                    iInputCharIndex++;
//                                    while (char.IsDigit(_sInput[iInputCharIndex]))
//                                    {
//                                        buffer += _sInput[iInputCharIndex];
//                                        iInputCharIndex++;
//                                    }
//                                    if (_sInput[iInputCharIndex] == 'e' || _sInput[iInputCharIndex] == 'E')
//                                    {
//                                        E_e = true;
//                                    }
//                                    else if (char.IsWhiteSpace(_sInput[iInputCharIndex]))
//                                    {

//                                    }


//                                    // These line must go after the while
//                                    if (_sInput[iInputCharIndex] == '+' || _sInput[iInputCharIndex] == '-') // Here if we have either + or - i our number.
//                                    {
//                                        buffer += _sInput[iInputCharIndex];
//                                        iInputCharIndex++;
//                                        if (char.IsDigit(_sInput[iInputCharIndex]) || (char.IsWhiteSpace(_sInput[iInputCharIndex]) && char.IsDigit(_sInput[iInputCharIndex - 1])))
//                                        {
//                                            buffer += _sInput[iInputCharIndex];
//                                            iInputCharIndex++;
//                                            while (!char.IsWhiteSpace(_sInput[iInputCharIndex]))
//                                            {
//                                                if (char.IsDigit(_sInput[iInputCharIndex]))
//                                                {
//                                                    buffer += _sInput[iInputCharIndex];
//                                                    iInputCharIndex++;
//                                                }
//                                                else
//                                                {
//                                                    throw new Exception("5 - not a meaningful number.");
//                                                }
//                                            }
//                                            // There is a number here after + or - 
//                                        }
//                                        else
//                                        {
//                                            throw new Exception("6 - Not a meaningful number.");
//                                        }
//                                    }
//                                    else if (char.IsDigit(_sInput[iInputCharIndex]))   // Here if we don't have any + or - in our number.
//                                    {
//                                        buffer += _sInput[iInputCharIndex];
//                                        iInputCharIndex++;
//                                        while (!char.IsWhiteSpace(_sInput[iInputCharIndex]))
//                                        {
//                                            if (char.IsDigit(_sInput[iInputCharIndex]))
//                                            {
//                                                buffer += _sInput[iInputCharIndex];
//                                                iInputCharIndex++;
//                                            }
//                                            else
//                                            {
//                                                throw new Exception("7 - not a meaningful number.");    //12.32E1A
//                                            }
//                                        }
//                                        Console.WriteLine(buffer + " It is Here 1 ");
//                                    }
//                                    else
//                                    {
//                                        throw new Exception("8 - Not a meaningful number.");    //12.32EA
//                                    }
//                                }
//                                else
//                                {
//                                    throw new Exception("9 - Not a meaningful number.");    //12.E
//                                }
//                            }
//                        }
//                        else if (E_e == true)  // If our number doesn't have any dot in it.
//                        {

//                        }
//                        else
//                        {
//                            throw new Exception(" - Not a meaningful number.");
//                        }
//                    }
//                    else if (!char.IsDigit(_sInput[iInputCharIndex -1]))
//                    {
//                        throw new Exception(" - not a meanigful number.");  //123E
//                    }
//                }
//                // punctuation
//                else if (true)
//                {
//                }


//            }
//        }
        
//    }
//}
