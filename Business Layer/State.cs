using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer.Business_Layer
{
    public class State
    {
        private string _name;
        public Token token;
        public State (string name, string sTokenAttributeName)
        {
            _name = name;
            token = new Token(sTokenAttributeName);
        }

        public string fnGetName()
        {
            return _name;
        }
    }
}
