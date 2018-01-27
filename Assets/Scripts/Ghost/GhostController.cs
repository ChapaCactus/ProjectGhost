using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	[RequireComponent(typeof(GhostView))]
	public class GhostController : MonoBehaviour
	{
		public float ChargePower => _model.BasePower;

		public bool IsLinkTo1 => _model.IsLinkTo1;
		public bool IsLinkTo2 => _model.IsLinkTo2;
		public bool IsLinkTo3 => _model.IsLinkTo3;
		public bool IsLinkTo4 => _model.IsLinkTo4;
		public bool IsLinkTo5 => _model.IsLinkTo5;
		public bool IsLinkTo6 => _model.IsLinkTo6;
		public bool IsLinkTo7 => _model.IsLinkTo7;
		public bool IsLinkTo8 => _model.IsLinkTo8;
		public bool IsLinkTo9 => _model.IsLinkTo9;

		private GhostView _view { get; set; }
		private GhostModel _model { get; set; }

		private void Awake()
		{
			_view = GetComponent<GhostView>();
		}

		public static void Create(Constants.GhostID id, Transform parent, Action<GhostController> callback)
		{
			var prefab = Resources.Load("Prefabs/Ghost/Ghost") as GameObject;
			var go = Instantiate(prefab, parent);
			var res = go.GetComponent<GhostController>();

			var model = new GhostModel(10, true, true, true, true, true, true, true, true, true);
			res.Setup(model);

			callback(res);
		}

		public void Setup(GhostModel model)
		{
			_model = model;
		}
	}
}