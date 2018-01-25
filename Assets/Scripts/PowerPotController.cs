using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using HedgehogTeam.EasyTouch;

namespace Ghost
{
	[RequireComponent(typeof(PowerPotView))]
	public class PowerPotController : MonoBehaviour
	{
		[SerializeField]
		private Constants.PotType _potType;

		public bool IsCharging => _chargingCoroutine != null;

		private Coroutine _chargingCoroutine { get; set; } = null;

		private PowerPotModel _model { get; set; }
		private PowerPotView _view { get; set; }
		private GhostController _ghost { get; set; }

		private void Awake()
		{
			_view = GetComponent<PowerPotView>();

			PrepareChargeBar();
		}

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

		public static void Create(PowerPotModel model, Action<PowerPotController> callback)
		{
			var prefab = Resources.Load("") as GameObject;
			var go = Instantiate(prefab, null);

			var res = go.GetComponent<PowerPotController>();
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

		private void PrepareChargeBar()
		{
			ChargeBar.Create(this, chargeBar =>
			{
				_view.SetChargeBar(chargeBar);
				var barPosition = Utilities.GetScreenPosition(_view.ChargeBarPosition.position);
				_view.ChargeBar.transform.localPosition = barPosition;
			});
		}
	}
}