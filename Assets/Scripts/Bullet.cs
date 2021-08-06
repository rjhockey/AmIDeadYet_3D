using UnityEngine;

public class Bullet : MonoBehaviour
{
    Gun _gun;

    public void SetGun(Gun gun) => _gun = gun;

    // when bullet collides it will disable itself and load itself into the queue
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        //add ? to get rid of error cause by first unpooled bullet
        _gun?.AddToPool(this);

        // get the enemy componet of the enemy we hit
        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
            // contacts[0] is the first area hit on enemy, built in array
            enemy.TakeDamage(collision.contacts[0].point);
    }
} //nothing
