using System.Collections;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _coin;

    private Coroutine _spawnJob;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];
        _spawnJob = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitingUntilSpawn = new WaitForSeconds(3);

        while (true)
        {
            for (int i = 0; i < _spawnPoints.childCount; i++)
            {
                _points[i] = _spawnPoints.GetChild(i);
                Instantiate(_coin, _points[i].transform.position, Quaternion.identity);
                yield return waitingUntilSpawn;
            }
        }
    }
}
