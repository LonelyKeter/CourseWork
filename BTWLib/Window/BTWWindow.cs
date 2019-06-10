using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keter.Core;

namespace BTWLib
{
	public class BTWWindow : KTWindow
	{
		public BTWForm Form { get; private set; } = new BTWForm();

		public override void Render(object RenderData)
		{
			Form.SuspendDrawing();

			BTWRenderData data = (BTWRenderData)RenderData;

			Form.Controls.Clear();
			Form.Controls.AddRange(data.Labels);

			Form.ResumeDrawing();
		}
	}
}
