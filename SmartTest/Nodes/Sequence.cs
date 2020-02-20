using System;
using System.Collections.Generic;
using System.Text;

namespace SmartTest
{
    using _ = Node;
    public class Sequence : Node
    {
        /** Children nodes that belong to this sequence */
        private List<_> m_nodes = new List<_>();

        /** Must provide an initial set of children nodes to work */
        public Sequence(List<_> nodes)
        {
            m_nodes = nodes;
        }

        /* If any child node returns a failure, the entire node fails. Whence all  
         * nodes return a success, the node reports a success. */
        public override NodeStates Evaluate()
        {
            bool anyChildRunning = false;

            foreach (Node node in m_nodes)
            {
                switch (node.Evaluate())
                {
                    case NodeStates.FAILURE:
                        m_nodeState = NodeStates.FAILURE;
                        return m_nodeState;
                    case NodeStates.SUCCESS:
                        continue;
                    case NodeStates.RUNNING:
                        anyChildRunning = true;
                        continue;
                    default:
                        m_nodeState = NodeStates.SUCCESS;
                        return m_nodeState;
                }
            }

            return anyChildRunning ? NodeStates.RUNNING : NodeStates.SUCCESS;
        }
    }
}
