using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Ghost
{
	public class PowerPotLinker : MonoBehaviour
	{
		// テンキーに対応した方向のポットを登録する
		// 0と5は自身を登録する
		[SerializeField]
		private PowerPotController[] _eachDirectionPots = new PowerPotController[9];
		public PowerPotController[] EachDirectionPots => _eachDirectionPots;
	}
}