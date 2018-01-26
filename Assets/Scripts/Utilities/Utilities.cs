using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	public static class Utilities
	{
		public static string ConvertMasterRowID(int id)
		{
			var padleft = id.ToString().PadLeft(3, '0');
			var combine = ("ID_" + padleft);
			return combine;
		}

		/// <summary>
		/// ワールド座標をスクリーン座標に変換
		/// </summary>
		/// <returns>スクリーン座標</returns>
		public static Vector2 GetScreenPosition(Vector3 worldPos)
		{
			var pos = Vector2.zero;

			var screenPos = RectTransformUtility.WorldToScreenPoint(UIManager.I.MainCamera, worldPos);

			RectTransformUtility.ScreenPointToLocalPointInRectangle(
				UIManager.I.CanvasRect, screenPos, UIManager.I.UICamera, out pos);

			return pos;
		}

		public static void ToggleCanvasGroup(CanvasGroup canvasGroup, bool value)
		{
			if (value)
			{
				// => ON
				canvasGroup.alpha = 1;
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
			}
			else
			{
				// => OFF
				canvasGroup.alpha = 0;
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
			}
		}

		public static void SafeCall<T>(this Action<T> action, T arg)
		{
			if (action != null)
			{
				action(arg);
			}

			Debug.Assert(action != null, "action is null.");
		}

		public static void SafeCall(this Action action)
		{
			if (action != null)
			{
				action();
			}
		}
	}
}