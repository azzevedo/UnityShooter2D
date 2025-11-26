using UnityEngine;


// namespace Assets.src.Scripts.Utils
namespace AsesIndomaveis
{
	public class GameObjectKiller : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent(out IReturnable returnable))
			{
				returnable.ReturnToPool();
			}
		}
	}
}