using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    [System.Serializable]
    public class MovementSettings
    {
        public float forwardvelocity = 10;
        public float jumpVelocity = 20;
    }

    [System.Serializable]
    public class PhysicsSettings
    {
        public float downAccel = 0.75f;
    }


    public MovementSettings movementSettings = new MovementSettings();
    public PhysicsSettings physicsSettings = new PhysicsSettings();
    public Vector3 _velocity;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private int _jumpInput = 0;
    private bool _onGround = false;
    public float sidewaysforce = 500f;
    private int speed = 10;
    public bool isDead=false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _animator = GetComponent<Animator>();
        _velocity = Vector3.zero;

    }
    void FixedUpdate()
    {
        InputHandling();
        Run();
        CheckGround();
        Jump();
        _rigidbody.velocity = _velocity;
        if (Input.GetKey("d"))
        {
            _rigidbody.AddForce(sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            _rigidbody.AddForce(-sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }


    }

    // void OnCollisionEnter(Collision other)
    // {
    //     if (other.collider.tag == "obstacles")
    //     {
    //         movementSettings.forwardvelocity = 0;
    //         speed = 0;
    //     }
    // }
    void Run()
    {
        _velocity.z = movementSettings.forwardvelocity;
    }


    // Update is called once per frame
    void Jump()
    {
        if (_jumpInput == 1 && _onGround)
        {
            _velocity.y = movementSettings.jumpVelocity;
            _animator.SetTrigger("Jump");
        }
        else if (_jumpInput == 0 && _onGround)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y -= physicsSettings.downAccel;
        }
        _jumpInput = 0;
    }
    void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit[] hits = Physics.RaycastAll(ray, 0.5f);
        _onGround = false;
        _rigidbody.useGravity = true;
        foreach (var hit in hits)
        {
            if (!hit.collider.isTrigger)
            {
                if (_velocity.y <= 0)
                {
                    _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Time.deltaTime * 10);
                }
                _rigidbody.useGravity = false;
                _onGround = true;
                break;
            }
        }
    }
    void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpInput = 1;
        }
    }
    public void killPlayer(){
        isDead=true;
        movementSettings.forwardvelocity=0;
        _animator.SetTrigger("Die");
    }
}

