using System.Collections;
using UnityEngine;

public sealed class AsteroidWaves : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public int[] waves = new int[] {
        4,
        5,
        6,
        8,
        10,
    };

    public float timeBetweenWavesInSeconds = 2.0f;

    private Player player;

    private int currentWave = 0;
    private int asteroidCount = 0;
    private float minDistanceFromPlayer = 2.0f;

    private void OnValidate()
    {
        if (waves.Length == 0)
        {
            waves = new int[] { 1 };
        }

        for (var i = 0; i < waves.Length; i++)
        {
            waves[i] = Mathf.Max(waves[i], 1);
        }
    }

    private void Awake()
    {
        Asteroid.OnSpawned += OnAsteroidSpawned;
        Asteroid.OnDestroyed += OnAsteroidDestroyed;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();

        StartCoroutine(SpawnWave());
    }

    private void OnDestroy()
    {
        Asteroid.OnSpawned -= OnAsteroidSpawned;
        Asteroid.OnDestroyed -= OnAsteroidDestroyed;
    }

    private void OnAsteroidSpawned(Asteroid asteroid)
    {
        asteroidCount += 1;
    }

    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        asteroidCount -= 1;
        if (asteroidCount == 0)
        {
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(timeBetweenWavesInSeconds);

        var gameCamera = GameCamera.instance;
        var cameraPosition = (Vector2)gameCamera.transform.position;
        var maxX = gameCamera.myCamera.orthographicSize;
        var maxY = maxX * gameCamera.myCamera.aspect;

        var asteroidCount = waves[currentWave];
        if (currentWave < waves.Length - 1)
        {
            currentWave += 1;
        }

        for (var i = 0; i < asteroidCount; i++)
        {
            var position = new Vector2();
            for (; ; )
            {
                position.x = Random.Range(-maxX, maxX);
                position.y = Random.Range(-maxY, maxY);

                if (Vector2.Distance(position, player.myRigidbody.position) > minDistanceFromPlayer)
                {
                    break;
                }
            }

            Instantiate(asteroidPrefab, position, Quaternion.identity);
        }
    }
}
