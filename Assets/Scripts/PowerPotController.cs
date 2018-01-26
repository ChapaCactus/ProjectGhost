using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using HedgehogTeam.EasyTouch;
using DG.Tweening;

namespace Ghost
{
	[RequireComponent(typeof(PowerPotView))]
	[RequireComponent(typeof(QuickTap))]
	public class PowerPotController : MonoBehaviour
	{
		[SerializeField]
		private Constants.PotType _potType;

		public bool IsCharging => _chargingCoroutine != null;

		private Coroutine _chargingCoroutine { get; set; } = null;

		private PowerPotModel _model { get; set; }
		private PowerPotView _view { get; set; }
		private GhostController _ghost { get; set; }
		private QuickTap _quickTap { get; set; }

		private void Awake()
		{
			_view = GetComponent<PowerPotView>();
			_quickTap = GetComponent<QuickTap>();

			PrepareChargeBar();

			_quickTap.onTap.AddListener(OnTouch);
		}

		private void Update()
		{
			return;

			if (_ghost == null) return;

			if (!IsCharging)
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

			if (_ghost == null)
			{
				GhostController.Create(Constants.GhostID.Com, transform, ghost =>
				{
					SetGhost(ghost);
				});
			}
			else
			{
				RemoveGhost();
			}
		}

		public void SetGhost(GhostController ghost)
		{
			if (_ghost != null) RemoveGhost();

			_view.ChargeBar.SetVisible(false);
			_ghost = ghost;

			SetChargeBarValue(_ghost.ChargePower);
		}

		public void RemoveGhost()
		{
			Destroy(_ghost.gameObject);
			_ghost = null;
			_view.ChargeBar.SetVisible(false);
			_view.ChargeBar.Reset();
		}

		private void SetChargeBarValue(float value)
		{
			DOTween.To(v => _view.ChargeBar.Slider.value = v, _view.ChargeBar.Slider.value, value, 0.4f)
				   .OnStart(() => _view.ChargeBar.SetVisible(true));
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
				_view.ChargeBar.SetVisible(false);
				var barPosition = Utilities.GetScreenPosition(_view.ChargeBarPosition.position);
				_view.ChargeBar.transform.localPosition = barPosition;
			});
		}
	}
}