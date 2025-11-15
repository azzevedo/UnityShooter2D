using UnityEngine;


namespace Assets.src.Scripts.Fase1
{
	[RequireComponent(typeof(Renderer))]
	public class Parallax : MonoBehaviour
	{
		[SerializeField] float _speed = 10f;
		Renderer _mesh;
		Vector2 _offset = Vector2.zero;

		void Start()
		{
			_mesh = GetComponent<Renderer>();
		}

		void Update()
		{
			// _offset.y = _speed * Time.time;
			// _mesh.material.mainTextureOffset = _offset;
			_offset.y = _speed * Time.deltaTime;
			_mesh.material.mainTextureOffset += _offset;
		}
	}
}