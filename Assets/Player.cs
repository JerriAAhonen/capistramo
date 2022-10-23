using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
	[SerializeField] private float movementForce;
	[SerializeField] private float rotationForce;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			// Rotate left
			rb.AddTorque(Vector3.up * -rotationForce);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			// Rotate right
			rb.AddTorque(Vector3.up * rotationForce);
		}
		
		rb.AddForce(transform.forward * movementForce, ForceMode.Force);
	}
}
