using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
	private LineRenderer lr;

	private void Awake()
	{
		lr = GetComponent<LineRenderer>();
	}

	private void LateUpdate()
	{
		lr.positionCount = 2;
		lr.SetPosition(0, GameManager.Instance.Players[0].position);
		lr.SetPosition(1, GameManager.Instance.Players[1].position);
	}
}
