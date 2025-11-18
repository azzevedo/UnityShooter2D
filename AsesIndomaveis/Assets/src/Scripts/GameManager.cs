using UnityEngine;


namespace Assets.src.Scripts
{
	public class GameManager : MonoBehaviour
	{
		public void Pause()
		{
			Time.timeScale = 0;
		}

		public void UnPause()
		{
			Time.timeScale = 1;
		}
	}
}