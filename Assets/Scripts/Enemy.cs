using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _hitPrefab;
    [SerializeField] GameObject _explosionPrefab;
    [SerializeField] int _health = 3;
    [SerializeField] int _pointValue = 100;

    AudioSource _audioSource;
    int _currentHealth;
    
    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
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
        // or write below as _audioSource?.Play();
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
        

        if (_currentHealth <= 0)
        {
            Instantiate(_explosionPrefab, impactPoint, transform.rotation);
            gameObject.SetActive(false);

            ScoreSystem.Add(_pointValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
