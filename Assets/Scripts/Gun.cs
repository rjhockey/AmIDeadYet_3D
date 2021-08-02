using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _delay = 0.2f;
    [SerializeField] float _bulletSpeed = 5f;

    float _nextShootTime;
    Vector3 _direction;
    Queue<Bullet> _pool = new Queue<Bullet>();
    

    // Update is called once per frame
    void Update()
    {
        // place where mouse is and players transform point
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var raycastHit, Mathf.Infinity))
        {
            _direction = raycastHit.point - _shootPoint.position;
            _direction.Normalize();
            // shoot out bullets on x plane at one speed
            _direction = new Vector3(_direction.x, 0, _direction.z);
            // make player face same direction as bullets firing
            transform.forward = _direction;
        }

        if (CanShoot())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        _nextShootTime = Time.time + _delay;
        var bullet = GetBullet();
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;
        bullet.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed;
    }

    Bullet GetBullet()
    {
        if (_pool.Count > 0)
        {
            var bullet = _pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            //var bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            //bullet.SetGun(this);
            //return bullet;
            var bullet = _pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
    }

    bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }

    public void AddToPool(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }
}

