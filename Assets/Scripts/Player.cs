using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _speed = 1f;
    [SerializeField] Transform _direction;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        // moves player relative to his orientation
        transform.Translate (movement * Time.deltaTime * _speed, _direction);

        // when moving, run will be set to true > animator
        _animator.SetBool("Run", movement.magnitude > 0);
    }
}
