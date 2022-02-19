using System;

namespace tutorial
{
	class Program
	{
		public static void Main(string[] args)
		{
			Node<double> n1 = new Node<double>(100);
			Node<double> n2 = new Node<double>(200, n1);
			Node<double> n3 = new Node<double>(300, n2);
			Node<double> n4 = new Node<double>(400, n3);
			Node<double> p = new Node<double>(250, n4);
			printNodes(insertToList(250, n4));
			Console.ReadLine();
		}
		static void printNodes(Node<double> list)
        {
			Node<double> temp = list;
			while (temp != null)
            {
				Console.WriteLine(temp.ToString());
				temp = temp.GetNext();

			}
        }
		static double[] convertToArray(Node<double> list)
        {
			double[] array = new double[list.GetLength()];
			for (int i = 0; i < array.Length; i++)
            {
				array[i] = list.GetValue();
				list = list.GetNext();
            }
			return array;
        }
		static double[] bubbleSort(double[] array)
        {
			bool continuSort = true;
            while (continuSort){
				continuSort = false;
				for (int i = 0;i < array.Length - 1; i++)
                {
					if (array[i] > array[i + 1])
                    {
						double holder = array[i];
						array[i] = array[i + 1];
						array[i + 1] = holder;
						continuSort = true;
                    }
                }
            }
			return array;
        }
		
		static void printItems(double[] array)
        {
			foreach(double item in array)
            {
				Console.WriteLine(item);
            }
        }
		static Node<double> arrayToList(double[] array)
        {
			Node<double> list = new Node <double>(array[0]); 
			for (int i = 1; i < array.Length; i++)
            {
				Node<double> newlist = new Node<double>(array[i], list);
				list = newlist;
            }


			return list;
        }
		static Node<double> insertToList(double item, Node<double> list)
		{
			Node<double> itemNode = new Node<double>(item, list);
			double[] listArray = convertToArray(itemNode);
			listArray = bubbleSort(listArray);
			itemNode = arrayToList(listArray);
			return itemNode;

		}


		class Node<T>
		{
			private T value;
			private Node<T> next;
			public Node(T value)
			{
				this.value = value;
				this.next = null;
			}
			public Node(T value, Node<T> next)

			{
				this.value = value;
				this.next = next;

			}

			public T GetValue()

			{
				return value;

			}
			public Node<T> GetNext()

			{
				return next;

			}


			public void SetValue(T value)

			{
				this.value = value;

			}
			public void SetNext(Node<T> next)

			{
				this.next = next;

			}

			public bool HasNext()

			{
				return this.next != null;

			}
			public override String ToString()
			{
				return "" + this.value.ToString();
			}

			public int GetLength()
			{

				int length = 0;
				Node<T> temp = new Node<T>(this.value, this.next);
				while (temp != null)
				{
					length++;
					temp = temp.GetNext();
				}
				return length;
			}


		}
	}
}
