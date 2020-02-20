using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SmartTest
{

    [Serializable]
    public abstract class Node
    {

        /* Delegate that returns the state of the node.*/
        public delegate NodeStates NodeReturn();

        /* The current state of the node */
        protected NodeStates m_nodeState;

        public NodeStates NodeState
        {
            get { return m_nodeState; }
        }

        /* The constructor for the node */
        public Node() { }

        /* Implementing classes use this method to evaluate the desired set of conditions */
        public abstract NodeStates Evaluate();

    }

}
