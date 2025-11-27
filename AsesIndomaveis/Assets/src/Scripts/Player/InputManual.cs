using UnityEngine;

namespace AsesIndomaveis
{
	public class InputManual : InputHandler
	{
		[SerializeField] string horizontalAxisName = "Horizontal";
		[SerializeField] string verticalAxisName = "Vertical";
		[SerializeField] string fireButtonName = "Fire1";

		public override float GetHorizontalAxis()
		{
			return Input.GetAxis(horizontalAxisName);
		}

		public override float GetVerticalAxis()
		{
			return Input.GetAxis(verticalAxisName);
		}

		public override bool IsFireButtonPressed()
		{
			return Input.GetButton(fireButtonName);
		}
	}
}