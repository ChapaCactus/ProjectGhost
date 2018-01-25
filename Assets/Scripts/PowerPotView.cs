using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	public class PowerPotView : MonoBehaviour
	{
		[SerializeField]
		private Transform _chargeBarPosition;

		public Transform ChargeBarPosition => _chargeBarPosition;

		public ChargeBar ChargeBar { get; private set; }
		public void SetChargeBar(ChargeBar bar) => ChargeBar = bar;
	}
}