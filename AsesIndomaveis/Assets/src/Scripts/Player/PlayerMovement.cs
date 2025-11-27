using NaughtyAttributes;
using UnityEngine;

namespace AsesIndomaveis
{
	public class PlayerMovement : MonoBehaviour
	{
		[Required("Transform que representa o Player"), SerializeField]
		Transform m_player;

		[Required("Input Handler"), SerializeField] InputHandler m_inputHandler;

		[SerializeField] float m_speed = 1;

		[Header("Ditâncias máximas e mínimas para se mover em X e Y")]
		[Space]
		[SerializeField] float m_maxHorizontal;
		[SerializeField] float m_minHorizontal;
		[SerializeField] float m_maxVertical;
		[SerializeField] float m_minVertical;

		void Update()
		{
			Move();
		}

		void Move()
		{
			Vector3 direction = GetAxis();
			m_player.position += m_speed * Time.deltaTime * direction;

			direction = LimitMovement(direction);
			m_player.position = direction;
		}

		Vector2 GetAxis()
		{
			float x = m_inputHandler.GetHorizontalAxis();
			float y = m_inputHandler.GetVerticalAxis();

			return new(x, y);
		}

		Vector2 LimitMovement(Vector2 direction)
		{
			direction.x = Mathf.Clamp(m_player.position.x, m_minHorizontal, m_maxHorizontal);
			direction.y = Mathf.Clamp(m_player.position.y, m_minVertical, m_maxVertical);

			return direction;
		}
	}
}