using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	public class GhostView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		public void SetVisible(bool visible)
		{
			_renderer.enabled = visible;
		}

		public void SetSprite(Sprite sprite)
		{
			_renderer.sprite = sprite;
		}
	}
}