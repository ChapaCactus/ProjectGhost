using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	public class Constants
	{
		public enum PotType
		{
			A = 0,
			B = 1,
			C = 2,
			D = 3,
			E = 4,
			F = 5,
			G = 6,
			H = 7,
			I = 8,
		}

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