using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer
{
    public class State
    {
        private string _name;
        public Token token;
        public bool isBuffer;
        public bool ungetchar = false;
        public State(string name, string sTokenAttributeName, bool _isBuffer = false)
        {
            _name = name;
            token = new Token(sTokenAttributeName);
            isBuffer = _isBuffer;
        }

        public string fnGetName()
        {
            return _name;
        }

        public override string ToString()
        {
            return token.fnGetAttributeValue();
        }

        public int fnValueLength()
        {
            return token.fnGetAttributeValue().Length;
        }
    }
}
