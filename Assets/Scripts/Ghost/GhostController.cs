using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	[RequireComponent(typeof(GhostView))]
	public class GhostController : MonoBehaviour
	{
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

			var model = new GhostModel();
			res.Setup(model);

			callback(res);
		}

		public void Setup(GhostModel model)
		{
			_model = model;
		}
	}
}