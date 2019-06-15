using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	class Tree<K>
	{
		public List<Node<K>> Nodes { get; } = new List<Node<K>>();

		public void AddFirstNode(K body)
		{
			Nodes.Add(new Node<K>(body));
		}

		public void AddNode(K body, int targetNode, BTWDirection direction)
		{
			Node<K> Result = new Node<K>(body);
			Nodes.Add(Result);
			Nodes[targetNode][direction].Add(Result);
		}

		public class Node<T>
		{
			public T Body { get; set; }

			List<Node<T>>[] Nodes = new List<Node<T>>[4];

			public Node(T body)
			{
				Body = body;

				for (int i = 0; i < 4; i++) Nodes[i] = new List<Node<T>>();
			}

			public void AddNode(Node<T> node, BTWDirection direction)
			{
				this[direction].Add(node);
			}

			public List<Node<T>> this[BTWDirection direction]
			{
				get
				{
					return Nodes[(int)direction - 1];
				}
			}
		}
	}
}
