using UnityEngine;

public class FollowUV : MonoBehaviour
{
	[SerializeField] private float parallax;
	
	private MeshRenderer mr;
	private Material m;

	private void Awake()
	{
		mr = GetComponent<MeshRenderer>();
		m = mr.material;
	}

	private void Update()
	{
		var offset = m.mainTextureOffset;
		offset.x = transform.position.x / transform.localScale.x / parallax;
		offset.y = transform.position.y / transform.localScale.y / parallax;

		m.mainTextureOffset = offset;
	}
}