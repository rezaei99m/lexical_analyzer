using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer
{
    class DeterministicFSM
    {
        private readonly List<State> Q = new List<State>();
        private readonly List<string> Sigma = new List<string>();
        private readonly List<Transition> Delta = new List<Transition>();
        private State Q0;
        private readonly List<State> F = new List<State>();
        private char buffer ;
        private Dictionary<string/* Value of the token*/, Token> symboleTable = new Dictionary<string, Token>();
        private List<string> keywords = new List<string> { "auto", "break", "case", "char",
                                                           "const", "continue", "default",
                                                           "do", "double", "else", "enum",
                                                           "extern", "float", "for", "goto",
                                                           "if", "int", "long", "register",
                                                           "return", "short", "signed", "sizeof",
                                                           "static", "struct", "switch", "typedef",
                                                           "union", "unsigned", "void", "volatile",
                                                           "while"
        };
        
        public DeterministicFSM(List<State> q, List<string> sigma,
                                List<Transition> delta, State q0,
                                List<State> f)
        {
            Q = q;
            Sigma = sigma;
            AddTransitions(delta);
            AddInitialState(q0);
            AddFinalStates(f);
        }

        private void AddTransitions(List<Transition> transitions)
        {
            foreach (var transition in transitions.Where(ValidTransition))
            {
                Delta.Add(transition);
            }
        }

        private bool ValidTransition(Transition transition)
        {
            return Q.Contains(transition.StartState) &&
                    Q.Contains(transition.EndState) &&
                    //Sigma.Contains(transition.Symbol.Where<char>) &&
                    !TransitionAlreadyDefined(transition);
        }

        private bool TransitionAlreadyDefined(Transition transition)
        {
            return Delta.Any(t => t.StartState == transition.StartState &&
                                  t.Symbol == transition.Symbol);
        }

        private void AddInitialState(State q0)
        {
            if (Q.Contains(q0))
            {
                Q0 = q0;
            }
        }

        private void AddFinalStates(List<State> finalStates)
        {
            foreach (var finalState in finalStates.Where(finalState => Q.Contains(finalState) )) 
            {
                F.Add(finalState);
            }
        }
        /*
        public void string_Lexicer(string input)
        {
            var currentState = Q0;
            var steps = new StringBuilder();
            var _input = new StringBuilder();

            foreach (var symbol in input.ToCharArray())
            {
                var transition = Delta.Find(t => t.StartState == currentState &&
                                                 t.Symbol.Exists(a => a == symbol) == true);
                Console.WriteLine(symbol);
                Console.WriteLine("Curent State is " + currentState.ToString());
                _input.Append(symbol);
                if (transition == null)
                {
                    Console.WriteLine("No transitions for current state and symbol");
                    Console.WriteLine(" Error has occured");
                    Console.WriteLine(steps);
                    return;
                }
                currentState = transition.EndState;
                steps.Append(transition + "\n");
                if (F.Contains(currentState))
                {
                    Console.WriteLine("Accepted the input with steps:\n" + steps);
                    //Console.WriteLine(_input);
                    if (_input.ToString() == "==" || _input.ToString() == "<=" || _input.ToString() == ">=")
                    {

                    }
                    else
                    {
                        _input.Remove(_input.Length - 1, 1);
                        // We should now creat and make the new Token for the _input.
                        var temp = input.Remove(0, _input.Length);
                        //Console.WriteLine(" The temp is " + temp);
                        string_Lexicer(temp);
                    }
                    return;
                }
            }

            Console.WriteLine("Stopped in state " + currentState.fnGetName() +
                                 " which is not a final state.");
            Console.WriteLine(" Error has occured.");
            Console.WriteLine(steps);
        }

        public void Lexicer (string input)
        {
            string[] _input = input.Split((char)32, (char)9, (char)10);
            foreach (var item in _input)
            {
                var temp = item + " ";
                string_Lexicer(temp);
            }
        }
        */
        public State tokenize(string input)
        {
            var currentState = Q0;
            var steps = new StringBuilder();
            buffer = 'e';
            var value = new StringBuilder();
            foreach (var symbol in input.ToCharArray())
            {
                var transition = Delta.Find(t => t.StartState == currentState && t.Symbol.Contains(symbol.ToString()) == true);
                //Console.WriteLine(input);
                //Console.WriteLine(steps);
                if (transition == null)
                {
                    //Console.WriteLine("No transitions for current state and symbol");
                    //Console.WriteLine(" Error has occured");

                    State temp2 = new State(null, null);
                    if (value.ToString() == "") temp2.token.fnSetAttributeValue(symbol.ToString());
                    else temp2.token.fnSetAttributeValue(value.ToString());
                    return temp2;
                }
                steps.Append(transition + "\n");
                currentState = transition.EndState;
                if (currentState.isBuffer == true)
                {
                    buffer = symbol;
                    //Console.WriteLine(" The buffer is " + buffer);
                }
                else
                {
                    value.Append(symbol);
                }
                if (F.Contains(currentState))
                {
                    
                    //Console.WriteLine("Accepted the input with steps:\n" + steps);
                    //Console.WriteLine(value);
                    var temp = currentState;
                    for (int i = 0; i < input.Length; i++)
                    {
                        //if (input.ToCharArray()[i] == symbol)
                        //{
                        //    if (input.ToCharArray()[i] != '$' && input.ToCharArray()[i+1] != ' ')
                        //    {
                        //        temp.isBuffer = true;
                        //    }
                        //}
                    }
                    //Console.WriteLine(" The temp value is " + temp.token.fnGetAttributeName());
                    temp.token.fnSetAttributeValue(value.ToString());
                    return temp;
                }
            }
            State temp1 = new State(null, null);
            temp1.token.fnSetAttributeValue(value.ToString());
            return temp1;
        }

        public void lexicer(string input)
        {
            var overrideInput = input;
            State value = null;
            while (overrideInput != "$")
            {
                value = tokenize(overrideInput);
                overrideInput = overrideInput.Remove(0, value.token.fnGetAttributeValue().Length);
                
                if (overrideInput.ToCharArray()[0] != (char)32)
                {
                    //Console.WriteLine(overrideInput[0]);
                    value.ungetchar = true;
                    //Console.WriteLine("The first charechter of the overrideinput is: " + (char)overrideInput[0]);
                }
                if (value.token.fnGetAttributeName() == "KEYWORD || IDENTIFIER")
                {
                    if (keywords.Contains(value.token.fnGetAttributeValue()))
                    {
                        Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "KEYWORD");
                        if (value.ungetchar == true) Console.WriteLine("ungetch");
                    }
                    else
                    {
                        if (symboleTable.ContainsKey(value.token.fnGetAttributeValue()) == true)
                        {
                            Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "IDENTIFIER");
                            Console.WriteLine("false");
                            if (value.ungetchar == true) Console.WriteLine("ungetch");
                        }
                        else
                        {
                            symboleTable.Add(value.token.fnGetAttributeValue(), value.token);
                            Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "IDENTIFIER");
                            Console.WriteLine("true");
                            if (value.ungetchar == true)
                            {
                                Console.WriteLine("ungetch");
                            }

                        }
                    }
                }
                else if (value.token.fnGetAttributeName() == "PUNCTUATION") Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "PUNCTUATION");
                else if (value.token.fnGetAttributeName() == "INT")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "INT");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "SCI")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "SCI");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "REAL")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "REAL");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "EQ")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "EQ");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "NE")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "NE");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "LE")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "LE");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "LT")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "LT");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "GE")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "GE");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "GT")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "GT");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "STR")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "STR");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "ASSIGN")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "ASSIGN");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "INC")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "INC");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "ADD_ASSIGN")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "ADD_ASSIGN");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "ADD")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "ADD");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "DEC")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "DEC");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "SUB_ASSIGN")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "SUB_ASSIGN");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "SUB")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "SUB");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "AND")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "AND");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "BITWISE_OP")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "BITWISE_OP");    // This might need to be deleted
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "OR")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "OR");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "DIV_ASSIGN")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "DIV_ASSIGN");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "DIV")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "DIV");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "MUL_ASSIGN")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "MUL_ASSIGN");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "MUL")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "MUL");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "NOT")
                {
                    Console.WriteLine(value.token.fnGetAttributeValue() + "    " + "NOT");
                    if (value.ungetchar == true) Console.WriteLine("ungetch");
                }
                else if (value.token.fnGetAttributeName() == "COMMENT") { }
                else if (value.token.fnGetAttributeName() == "NEW_LINE") { }
                else if (value.token.fnGetAttributeName() == "Delim") { }
                else if (value.token.fnGetAttributeName() == "$") { }
                else Console.WriteLine("error");
                value.ungetchar = false;
            }
            foreach (var item in symboleTable)
            {
                Console.WriteLine(item.Key);
            }
            
        }
    }
}
