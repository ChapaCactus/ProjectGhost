using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Ghost
{
	public class GhostSelectPanel : SingletonMonoBehaviour<GhostSelectPanel>
	{
		[SerializeField]
		private GhostSelectList _selectList;

		[SerializeField]
		private GhostInfoPanel _infoPanel;

		private GhostModel _currentSelectGhost { get; set; }

		private void Awake()
		{
			CheckComponents();
		}

		public void Setup()
		{
		}

		public void OnSelect(GhostModel model)
		{
			_infoPanel.Setup(model);
		}

		private void CheckComponents()
		{
			Assert.IsNotNull(_selectList);
			Assert.IsNotNull(_infoPanel);
		}
	}
}