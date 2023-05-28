using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private SpawnPoint[] _spawnPoints;
    private Coin[] _coins;
    private int _currentPoint;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _coins = new Coin[_spawnPoints.Length];
    }

    private void OnEnable()
    {
        Generate();
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
        {
            coin.Collected -= Generate;
        }
    }

    private void Generate()
    {
        if (_currentPoint < _spawnPoints.Length)
        {
            Coin coin = Instantiate(_coinPrefab, _spawnPoints[_currentPoint].transform.position, Quaternion.identity);
            coin.Collected += Generate;
            _coins[_currentPoint] = coin;
            _currentPoint++;
        }
    }
}
