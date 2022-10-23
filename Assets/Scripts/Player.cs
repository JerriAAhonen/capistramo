using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
	[SerializeField] private float movementForce;
	[SerializeField] private float boostForce;
	[SerializeField] private float rotationForce;
	[SerializeField] private float collisionForce;
	[SerializeField] private ParticleSystem rearThrustPS;
	[SerializeField] private ParticleSystem rightThrustPS;
	[SerializeField] private ParticleSystem leftThrustPS;
	
	private Rigidbody rb;
	private bool turningRight;
	private bool turningLeft;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			turningLeft = true;
			rightThrustPS.Play();
			leftThrustPS.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}

		if (Input.GetKeyUp(KeyCode.A))
		{
			turningLeft = false;
			rightThrustPS.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			turningRight = true;
			leftThrustPS.Play();
			rightThrustPS.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}

		if (Input.GetKeyUp(KeyCode.D))
		{
			turningRight = false;
			leftThrustPS.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}
		
		if (turningLeft)
		{
			// Rotate left
			rb.AddTorque(Vector3.up * -rotationForce);
		}
		
		if (turningRight)
		{
			// Rotate right
			rb.AddTorque(Vector3.up * rotationForce);
		}

		var finalMovementForce = movementForce;
		var rearThrustPSMain = rearThrustPS.main;
		if (Input.GetKey(KeyCode.Space))
		{
			finalMovementForce = boostForce;
			rearThrustPSMain.startSize = 3f;
		}
		else
		{
			rearThrustPSMain.startSize = 1f;
		}
		
		rb.AddForce(transform.forward * finalMovementForce, ForceMode.Force);
	}

	private void OnCollisionEnter(Collision collision)
	{
		var obs = collision.gameObject.GetComponent<Obstacle>();
		if (obs)
		{
			var dir = (transform.position - obs.transform.position).normalized;
			rb.AddForce(dir * collisionForce, ForceMode.Impulse);
			var ps = obs.DestroyPS;
			var instance = Instantiate(ps);
			instance.transform.position = obs.transform.position;
			
			Destroy(obs.gameObject);
		}
	}
}
