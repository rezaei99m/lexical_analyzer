using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer.Business_Layer
{
    class DeterministicFSM
    {
        private readonly List<State> Q = new List<State>();
        private readonly List<char> Sigma = new List<char>();
        private readonly List<Transition> Delta = new List<Transition>();
        private State Q0;
        private readonly List<State> F = new List<State>();

        public DeterministicFSM(List<State> q, List<char> sigma,
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
            foreach (var finalState in finalStates.Where(
                       finalState => Q.Contains(finalState)))
            {
                F.Add(finalState);
            }
        }

        public void Accepts(string input)
        {
            var currentState = Q0;
            var steps = new StringBuilder();
            var _input = new StringBuilder();
            foreach (var symbol in input.ToCharArray())
            {
                var transition = Delta.Find(t => t.StartState == currentState &&
                                                 t.Symbol.Find(a => a == symbol) == symbol);
                Console.WriteLine(symbol);
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
                    if (_input.ToString() == "==" || _input.ToString() == "<=" || _input.ToString() == ">=")
                    {
                        
                    }
                    else
                    {
                        _input.Remove(_input.Length - 1, 1);
                        // We should now creat and make the new Token for the _input.
                        var temp = input.Remove(0, _input.Length);
                        Console.WriteLine(" The temp is " + temp);
                        Accepts(temp);
                    }
                    return;
                }
            }
            
            Console.WriteLine("Stopped in state " + currentState.fnGetName() +
                                 " which is not a final state.");
            Console.WriteLine(" Error has occured.");
            Console.WriteLine(steps);
        }
    }
}
