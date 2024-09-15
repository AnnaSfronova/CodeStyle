using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] float _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new(_delay);

        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.Init(direction, _target);

            yield return wait;
        }
    }
}