using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Ghost
{
	public class ChargeBar : MonoBehaviour
	{
		public PowerPotController Owner { get; private set; }

		public static readonly string PrefabPath = "Prefabs/UI/ChargeBar";

		public static void Create(PowerPotController owner, Action<ChargeBar> callback)
		{
			var prefab = Resources.Load(ChargeBar.PrefabPath) as GameObject;
			var go = Instantiate(prefab, UIManager.I.ChargeBarParent);

			var res = go.GetComponent<ChargeBar>();
			res.Setup(owner);

			callback(res);
		}

		public void Setup(PowerPotController owner)
		{
			Owner = owner;
		}
	}
}