using UnityEngine;

public class Bullet : MonoBehaviour
{
    Gun _gun;

    public void SetGun(Gun gun) => _gun = gun;

    // when bullet collides it will disable itself and readd itself into the queue
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        _gun.AddToPool(this);
    }
}
