using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyPS;
    
    private Vector3 rotation;
    private ObstacleSpawner obsSpawner;
    private Transform playerTm;
    private float despawnDist;

    public ParticleSystem DestroyPS => destroyPS;
    
    private void Start()
    {
        rotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    public void Init(ObstacleSpawner spawner, Transform player, float despawnDistance)
    {
        obsSpawner = spawner;
        playerTm = player;
        despawnDist = despawnDistance;
    }

    private void Update()
    {
        transform.Rotate(rotation);

        if ((transform.position - playerTm.position).sqrMagnitude > despawnDist * despawnDist)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        obsSpawner.Remove(this);
    }
}
