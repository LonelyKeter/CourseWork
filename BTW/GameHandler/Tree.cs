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
		List<Node<K>> Nodes = new List<Node<K>>();

		public void AddNode(K body)
		{
			Nodes.Add(new Node<K>(body, Nodes.Count));
		}

		public void LinkNode(int node, int targetNode, BTWDirection direction)
		{			
			Nodes[targetNode][direction].Add(Nodes[node]);
		}

		public Node<K> this[int index] { get { return Nodes[index]; } }

		public class Node<T>
		{
			public T Body { get; set; }
			public int Id { get; set; }

			List<Node<T>>[] Nodes = new List<Node<T>>[4];

			public Node(T body, int id)
			{
				Body = body;
				Id = id;

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
