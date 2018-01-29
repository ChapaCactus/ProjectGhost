using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Ghost
{
	public class GhostSelectList : MonoBehaviour
	{
		private Action<GhostModel> _onSelectGhost;

		public void Setup(Action<GhostModel> onSelectGhost)
		{
			_onSelectGhost = onSelectGhost;
		}
	}
}