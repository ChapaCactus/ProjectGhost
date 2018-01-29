using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Ghost
{
	public class GhostInfoPanel : MonoBehaviour
	{
		[SerializeField]
		private Text _ghostName;

		[SerializeField]
		private Image _ghostImage;

		private void Awake()
		{
			CheckComponents();
			Reset();
		}

		public void Setup(GhostModel model)
		{
			SetName(model.Name);
		}

		private void SetName(string name)
		{
			_ghostName.text = name;
		}

		private void SetGhostImage(Sprite sprite)
		{
			_ghostImage.sprite = sprite;
		}

		private void Reset()
		{
			_ghostName.text = "";
			_ghostImage.sprite = null;
		}

		private void CheckComponents()
		{
			Assert.IsNotNull(_ghostName);
			Assert.IsNotNull(_ghostImage);
		}
	}
}