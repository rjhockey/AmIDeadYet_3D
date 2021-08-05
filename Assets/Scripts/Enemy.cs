using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _hitPrefab;
    [SerializeField] GameObject _explosionPrefab;
    [SerializeField] int _health = 3;

    int _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<Player>();
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }

    public void TakeDamage(Vector3 impactPoint)
    {
        _currentHealth--;
        Instantiate(_hitPrefab, impactPoint, transform.rotation);
        

        if (_currentHealth <= 0)
        {
            Instantiate(_explosionPrefab, impactPoint, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
