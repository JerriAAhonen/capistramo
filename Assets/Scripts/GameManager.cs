using System.Collections;
using System.Collections.Generic;
using Game.Shared;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] private List<Transform> players;

	public List<Transform> Players {  get { return players; } }
	public Vector3 PlayerCenter {  get; private set; }
	public float PlayerDistanceFromEachother {  get; private set; }

	private void Update()
	{
		var bounds = new Bounds(players[0].position, Vector3.zero);
		foreach (var player in players)
		{
			bounds.Encapsulate(player.position);
		}

		PlayerCenter = bounds.center;
		PlayerDistanceFromEachother = Mathf.Max(bounds.size.x, bounds.size.z);
	}
}
