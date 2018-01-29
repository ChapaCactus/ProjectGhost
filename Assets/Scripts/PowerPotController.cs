using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

using HedgehogTeam.EasyTouch;
using DG.Tweening;

namespace Ghost
{
	[RequireComponent(typeof(PowerPotView))]
	[RequireComponent(typeof(QuickTap))]
	[RequireComponent(typeof(PowerPotLinker))]
	public class PowerPotController : MonoBehaviour
	{
		[SerializeField]
		private int _potNumber;

		[SerializeField]
		private ParticleSystem _sparkParticlePrefab;

		public bool IsCharging => _chargingCoroutine != null;
		public float ChargePower => _ghost.ChargePower;

		public bool IsEnablePot => gameObject.activeSelf;

		private Coroutine _chargingCoroutine { get; set; } = null;

		private PowerPotModel _model { get; set; }
		private PowerPotView _view { get; set; }
		private PowerPotLinker _linker { get; set; }
		private GhostController _ghost { get; set; }
		private QuickTap _quickTap { get; set; }

		private void Awake()
		{
			_view = GetComponent<PowerPotView>();
			_linker = GetComponent<PowerPotLinker>();
			_quickTap = GetComponent<QuickTap>();

			PrepareChargeBar();

			_quickTap.onTap.AddListener(OnTouch);

			CheckComponents();
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
			_ghost.transform.localPosition += new Vector3(0, 50, 0);

			SetChargeBarValue(ChargePower);

			PlaySparkParticle();
			SendLinkPower(true);
		}

		public void RemoveGhost()
		{
			SendLinkPower(false);

			Destroy(_ghost.gameObject);
			_ghost = null;
			_view.ChargeBar.SetVisible(false);
			_view.ChargeBar.Reset();
		}

		public void SendLinkPower(bool isUpLink)
		{
			if (_ghost.IsLinkTo1)
			{
				if (isUpLink)
					_linker.EachDirectionPots[1]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[1]?.OutLinkPower();
			}

			if (_ghost.IsLinkTo2)
			{
				if (isUpLink)
					_linker.EachDirectionPots[2]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[2]?.OutLinkPower();
			}

			if (_ghost.IsLinkTo3)
			{
				if (isUpLink)
					_linker.EachDirectionPots[3]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[3]?.OutLinkPower();
			}

			if (_ghost.IsLinkTo4)
			{
				if (isUpLink)
					_linker.EachDirectionPots[4]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[4]?.OutLinkPower();
			}

			if (_ghost.IsLinkTo6)
			{
				if (isUpLink)
					_linker.EachDirectionPots[6]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[6]?.OutLinkPower();
			}

			if (_ghost.IsLinkTo7)
			{
				if (isUpLink)
					_linker.EachDirectionPots[7]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[7]?.OutLinkPower();
			}

			if (_ghost.IsLinkTo8)
			{
				if (isUpLink)
					_linker.EachDirectionPots[8]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[8]?.OutLinkPower();
			}

			if (_ghost.IsLinkTo9)
			{
				if (isUpLink)
					_linker.EachDirectionPots[9]?.ReceiveLinkPower();
				else
					_linker.EachDirectionPots[9]?.OutLinkPower();
			}
		}

		public void ReceiveLinkPower()
		{
			Debug.Log($"{_potNumber} is power received.");

			PlayUpEffect();
		}

		public void OutLinkPower()
		{
			PlayDownEffect();
		}

		public void PlayUpEffect()
		{
			PlayEffect(Constants.EffectUIType.PowerUp, new Vector3(0, 30, 0));
		}

		public void PlayDownEffect()
		{
			PlayEffect(Constants.EffectUIType.PowerDown, new Vector3(0, -30, 0) );
		}

		private void PlayEffect(Constants.EffectUIType key, Vector3 move)
		{
			if (_ghost == null) return;

			var parent = UIManager.I.EffectUIParent;
			EffectUI.Create(key, parent, effect =>
			{
				var startPos = Utilities.GetScreenPosition(transform.position);
				effect.SetLocalPosition(startPos);
				effect.Play(move, isAutoDestroy:true);
			});
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
				_view.ChargeBar.GetComponent<RectTransform>().localPosition = barPosition;
			});
		}

		private void PlaySparkParticle()
		{
			var particle = Instantiate<ParticleSystem>(_sparkParticlePrefab, transform);
			particle.Emit(20);
			Destroy(particle.gameObject, 2);
		}

		private void CheckComponents()
		{
			Assert.IsNotNull(_sparkParticlePrefab);
		}
	}
}