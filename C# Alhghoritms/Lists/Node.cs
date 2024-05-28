using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Alhghoritms.Lists
{
    public class Node
    {
        public string Data { get; set; }
        public Node? PreviousNode { get; set; }
        public Node? NextNode { get; set; }

        public Node(string data)
        {
            Data = data;
            PreviousNode = null;
            NextNode = null;
        }
    }
}
