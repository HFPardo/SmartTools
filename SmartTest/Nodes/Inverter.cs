using System;
using System.Collections.Generic;
using System.Text;

namespace SmartTest
{
    public class Inverter : Node
    {
        public Node Node { get; }

        /* The constructor requires the child node that this inverter decorator 
         * wraps*/
        public Inverter(Node node)
        {
            Node = node;
        }

        /* Reports a success if the child fails and 
         * a failure if the child succeeds. Running will report 
         * as running */
        public override NodeStates Evaluate()
        {
            return (Node.Evaluate()) switch
            {
                NodeStates.FAILURE => NodeStates.SUCCESS,
                NodeStates.SUCCESS => NodeStates.FAILURE,
                NodeStates.RUNNING => NodeStates.RUNNING,
                _ => NodeStates.SUCCESS,
            };           
        }
    }
}
