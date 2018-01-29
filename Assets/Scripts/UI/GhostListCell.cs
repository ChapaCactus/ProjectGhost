using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Ghost
{
	public class GhostListCell : MonoBehaviour
	{
		[SerializeField]
		private Image _ghostImage;

		[SerializeField]
		private Image[] _arrowImages = new Image[10];

		public void SetArrowsEnable(int[] enables)
		{
			Array.ForEach(_arrowImages, image => image.enabled = false);
			Array.ForEach(enables, num => _arrowImages[num].enabled = true);
		}
	}
}