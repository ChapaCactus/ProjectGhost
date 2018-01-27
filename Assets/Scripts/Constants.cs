using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	public class Constants
	{
		public enum GhostID
		{
			Com,
		}

		public enum Direction
		{
			無し = 5,

			上 = 8,
			下 = 2,

			右上 = 9,
			右 = 6,
			右下 = 3,

			左上 = 7,
			左 = 4,
			左下 = 1,
		}
	}
}