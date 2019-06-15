using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
	public partial class Tes : Form
	{
		public Tes()
		{
			InitializeComponent();

			KeyDown += MKeyDown;
			KeyPress+= MKeyPress;
			KeyUp += MKeyUp;
		}

		void MKeyDown(object sender, KeyEventArgs e)
		{
			label1.Text += e.KeyData.ToString();
		}

		void MKeyPress(object sender, KeyPressEventArgs e)
		{
			label1.Text += e.KeyChar;
		}

		void MKeyUp(object sender, KeyEventArgs e)
		{
			label1.Text += e.KeyData.ToString();
		}
	}
}
