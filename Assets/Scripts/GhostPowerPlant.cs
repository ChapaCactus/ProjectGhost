using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Ghost
{
	public class GhostPowerPlant : MonoBehaviour
	{
		[SerializeField]
		private List<PowerPotController> _pots;

		public float GetTotalChargePower => _pots.Sum(pot => pot.ChargePower);
	}
}