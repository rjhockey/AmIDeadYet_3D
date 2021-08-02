using UnityEngine;

public class Gun : MonoBehaviour
{
    float _nextShootTime;

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _delay = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        _nextShootTime = Time.time + _delay;
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }

    bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }
}
