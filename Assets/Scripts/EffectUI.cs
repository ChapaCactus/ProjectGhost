using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

namespace Ghost
{
	public class EffectUI : MonoBehaviour, IEffectUI
	{
		public static void Create(Constants.EffectUIType type, Transform parent, Action<IEffectUI> callback)
		{
			var prefab = Resources.Load($"Prefabs/UI/{type}") as GameObject;
			var go = Instantiate(prefab, parent);

			var res = go.GetComponent<IEffectUI>();
			callback(res);
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Play(Vector3 move, bool isAutoDestroy)
		{
			transform.DOLocalMove(move, 1)
			         .SetEase(Ease.OutExpo)
					 .SetRelative()
					 .OnComplete(() =>
					 {
						 if (isAutoDestroy)
						 {
							 Destroy(gameObject);
						 }
					 });
		}

		public void SetLocalPosition(Vector3 pos)
		{
			transform.localPosition = pos;
		}
	}

	public interface IEffectUI
	{
		void Show();
		void Hide();

		void SetLocalPosition(Vector3 pos);

		void Play(Vector3 move, bool isAutoDestroy);
	}
}