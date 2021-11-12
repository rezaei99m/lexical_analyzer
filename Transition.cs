using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer
{
    public class Transition
    {
        public State StartState { get; private set; }
        public List<string> Symbol { get; private set; }
        public State EndState { get; private set; }

        public Transition(State startState, List<string> symbol, State endState)
        {
            StartState = startState;
            Symbol = symbol;
            EndState = endState;

        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) -> {2}", StartState.fnGetName(), "Symbol", EndState.fnGetName());
        }

    }
}
