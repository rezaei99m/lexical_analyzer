using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer.Business_Layer
{
    public class Token
    {
        public Token (string sAttributeName, string sAttributeValue = null)
        {
            _sAttributeName = sAttributeName;
            _sAttributeValue = sAttributeValue;
        }
        private string _sAttributeName;
        private string _sAttributeValue;
        
        public void fnSetAttributeValue(string _temp)
        {
            _sAttributeValue = _temp;
        }

        public string fnGetAttributeValue()
        {
            return _sAttributeValue;
        }

        public string fnGetAttributeName()
        {
            return _sAttributeName;
        }

    }
}
