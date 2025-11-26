using UnityEngine;


namespace AsesIndomaveis
{
	[RequireComponent(typeof(Renderer))]
	public class Parallax : MonoBehaviour
	{
		[SerializeField] float m_speed = 10f;
		Renderer m_mesh;
		Vector2 m_offset = Vector2.zero;

		void Start()
		{
			m_mesh = GetComponent<Renderer>();
		}

		void Update()
		{
			// _offset.y = _speed * Time.time;
			// _mesh.material.mainTextureOffset = _offset;
			m_offset.y = m_speed * Time.deltaTime;
			m_mesh.material.mainTextureOffset += m_offset;
		}
	}
}