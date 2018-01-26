using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Ghost
{
	public class UIManager : SingletonMonoBehaviour<UIManager>
	{
		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private Camera _mainCamera;

		[SerializeField]
		private Camera _uiCamera;

		[SerializeField]
		private Transform _chargeBarParent;

		public Canvas Canvas => _canvas;
		public RectTransform CanvasRect => Canvas.rectTransform();
		public Camera MainCamera => _mainCamera;
		public Camera UICamera => _uiCamera;
		public Transform ChargeBarParent => _chargeBarParent;

		private void Awake()
		{
			Assert.IsNotNull(_canvas);
			Assert.IsNotNull(_mainCamera);
			Assert.IsNotNull(_uiCamera);
		}
	}
}