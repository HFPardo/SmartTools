using System;
using System.Collections.Generic;
using System.Text;

namespace SmartTest
{
    public class ActionNode : Node
    {
        /* Method signature for the action. */
        public delegate NodeStates ActionNodeDelegate();

        /* The delegate that is called to evaluate this node */
        private ActionNodeDelegate m_action;

        /* Because this node contains no logic itself, 
         * the logic must be passed in in the form of  
         * a delegate. As the signature states, the action 
         * needs to return a NodeStates enum */
        public ActionNode(ActionNodeDelegate action)
        {
            m_action = action;
        }

        /* Evaluates the node using the passed in delegate and  
         * reports the resulting state as appropriate */
        public override NodeStates Evaluate()
        {
            return (m_action()) switch
            {
                NodeStates.SUCCESS => NodeStates.SUCCESS,
                NodeStates.FAILURE => NodeStates.FAILURE,
                NodeStates.RUNNING => NodeStates.RUNNING,
                _ => NodeStates.FAILURE,
            };
        }
    }
}
