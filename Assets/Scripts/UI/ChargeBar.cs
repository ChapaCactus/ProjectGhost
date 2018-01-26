using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Ghost
{
	[RequireComponent(typeof(Slider))]
	public class ChargeBar : MonoBehaviour
	{
		[SerializeField]
		private Slider _slider;
		public Slider Slider => _slider;

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

			Reset();
		}

		public void SetVisible(bool visible)
		{
			if (!visible) return;
			gameObject.SetActive(visible);
		}

		public void Reset()
		{
			Slider.maxValue = 100;
			Slider.minValue = 0;
			Slider.value = 0;
		}
	}
}