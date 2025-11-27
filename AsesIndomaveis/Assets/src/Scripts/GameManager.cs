using UnityEngine;


namespace AsesIndomaveis
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