using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class GhostModel
	{
		public string Name { get; private set; }

		public int BasePower { get; private set; }

		public bool IsLinkTo1 { get; private set; } = false;
		public bool IsLinkTo2 { get; private set; } = false;
		public bool IsLinkTo3 { get; private set; } = false;
		public bool IsLinkTo4 { get; private set; } = false;
		public bool IsLinkTo5 { get; private set; } = false;
		public bool IsLinkTo6 { get; private set; } = false;
		public bool IsLinkTo7 { get; private set; } = false;
		public bool IsLinkTo8 { get; private set; } = false;
		public bool IsLinkTo9 { get; private set; } = false;

		public GhostModel(int basePower, bool isLinkTo1, bool isLinkTo2, bool isLinkTo3, bool isLinkTo4
		                  , bool isLinkTo5, bool isLinkTo6, bool isLinkTo7, bool isLinkTo8, bool isLinkTo9)
		{
			BasePower = basePower;

			IsLinkTo1 = isLinkTo1;
			IsLinkTo2 = isLinkTo2;
			IsLinkTo3 = isLinkTo3;
			IsLinkTo4 = isLinkTo4;
			IsLinkTo5 = isLinkTo5;
			IsLinkTo6 = isLinkTo6;
			IsLinkTo7 = isLinkTo7;
			IsLinkTo8 = isLinkTo8;
			IsLinkTo9 = isLinkTo9;
		}
	}
}