using UnityEngine;

namespace Ghost
{
	/// <summary>
	/// UIを保持出来るクラス
	/// HPバー、チャージバー等自分専用のUIがあるクラスに持たせる
	/// </summary>
	public interface IUIHoldable
	{
		Transform GetHoldingPosition();
	}
}