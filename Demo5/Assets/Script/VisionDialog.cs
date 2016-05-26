using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
	public class VisionDialog : VisionRangeBase<DialogTrigger>
	{
		protected override void UpdateLayer()
		{
			gameObject.layer = CampUtil.FireLayer( camp );
		}
	}
}
