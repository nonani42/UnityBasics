using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float rotationSpeed = 1000f;
    [SerializeField] Rigidbody _rbPlayer;
    private Animator _anim;
    private Player player;
    private float jumpHeight = 250f;
    bool _isJump = false;
    Vector3 _direction;
    Vector3 _jump;
    float rotX;
    float rotY;
    void Awake()
    {
        _direction = Vector3.zero;
        _jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _rbPlayer = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        player = gameObject.GetComponent<Player>();
    }
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown("space") && !_isJump)
        {
            Jump();
        }
        if (player.Buff != 0)
        {
            _speed = _speed + player.Buff;
            player.Buff = 0;
        }
    }
    void FixedUpdate()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = 0;
        _direction.z = Input.GetAxis("Vertical");
        if (_direction != Vector3.zero)
            _anim.SetBool("Moves", true);
        else
            _anim.SetBool("Moves", false);
        _direction = transform.TransformDirection(_direction);
        _rbPlayer.MovePosition(transform.position + _direction.normalized * _speed * Time.fixedDeltaTime);
        rotX += Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
        rotY += Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
        rotY = Mathf.Clamp(rotY, -90f, 90f);
        _rbPlayer.MoveRotation(Quaternion.Euler(0f, rotX, 0f));
        gameObject.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.Euler(-rotY, 0f, 0f);
    }
    void OnCollisionStay()
    {
        _isJump = false;
    }
    private void Jump()
    {
        _isJump = true;
        Debug.Log("Jump");
        _rbPlayer.AddForce(_jump * jumpHeight, ForceMode.Impulse);
    }
}
