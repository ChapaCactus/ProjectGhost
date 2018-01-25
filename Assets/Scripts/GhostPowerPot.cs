using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using HedgehogTeam.EasyTouch;

namespace Ghost
{
	public class GhostPowerPot : MonoBehaviour
	{
		[SerializeField]
		private Constants.PotType _potType;

		public bool IsCharging => _chargingCoroutine != null;

		private Coroutine _chargingCoroutine { get; set; } = null;

		private PowerPotModel _model { get; set; }
		private GhostController _ghost { get; set; }

		private void Update()
		{
			return;

			if (_ghost == null) return;

			if(!IsCharging)
			{
				var chargeSpeed = _model.ChargeSpeed;
				_chargingCoroutine = StartCoroutine(ChargeTimer(chargeSpeed));
			}
		}

		public static void Create(PowerPotModel model, Action<GhostPowerPot> callback)
		{
			var prefab = Resources.Load("") as GameObject;
			var go = Instantiate(prefab, null);

			var res = go.GetComponent<GhostPowerPot>();
			res.Setup(model);

			callback(res);
		}

		public void Setup(PowerPotModel model)
		{
			_model = model;
		}

		public void OnTouch(Gesture gesture)
		{
			Debug.Log($"{gameObject.name} is touched.");

			GhostController.Create(Constants.GhostID.Com, transform, ghost => {
				SetGhost(ghost);
			});
		}

		public void SetGhost(GhostController ghost)
		{
			if (_ghost != null) RemoveGhost();

			_ghost = ghost;
		}

		public void RemoveGhost()
		{
			_ghost = null;
		}

		private IEnumerator ChargeTimer(float chargeSpeed)
		{
			var timer = new WaitForSeconds(chargeSpeed);
			yield return timer;

			// End
			_chargingCoroutine = null;
		}
	}

	public class PowerPotModel
	{
		public string ID { get; set; } = "";
		public float ChargeSpeed { get; set; } = 1.0f;

		public PowerPotModel(string id, float chargeSpeed)
		{
			ID = id;

			ChargeSpeed = chargeSpeed;
		}
	}
}