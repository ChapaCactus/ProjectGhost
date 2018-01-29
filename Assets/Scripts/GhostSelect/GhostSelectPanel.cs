using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Ghost
{
	public class GhostSelectPanel : SingletonMonoBehaviour<GhostSelectPanel>
	{
		[SerializeField]
		private GhostSelectList _ghostSelectList;

		[SerializeField]
		private GhostInfoPanel _ghostInfoPanel;

		private GhostModel _currentSelectGhost { get; set; } = null;

		private void Awake()
		{
			CheckComponents();
		}

		public void Setup()
		{
		}

		public void OnSelect(GhostModel model)
		{
			_ghostInfoPanel.Setup(model);
		}

		private void CheckComponents()
		{
			Assert.IsNotNull(_ghostSelectList);
			Assert.IsNotNull(_ghostInfoPanel);
		}
	}
}