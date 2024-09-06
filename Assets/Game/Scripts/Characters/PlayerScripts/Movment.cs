using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movment : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private VariableJoystick _variableJoystick;

    [SerializeField] private float _moveSpeed;
    private float _maxMoveSpeed;
    private PlayerInput _playerInputSystem;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private InputAction _move;
    private bool _isModile;

    public float MoveSpeed => _moveSpeed;
    public float MaxMoveSpeed => _maxMoveSpeed;
    public Rigidbody PlayerRigidbody => _rigidbody;
    public Vector3 Direction => _direction;
    public Camera Camera => _camera;

    public void Initialize(float speed, bool isMoving)
    {
        _isModile = isMoving;

        if (isMoving)
            _moveSpeed = speed * 12.7f;
        else
            _moveSpeed = speed;

        _maxMoveSpeed = speed * 2;
    }

    private void Awake()
    {
        if (Agava.WebUtility.Device.IsMobile)
            _isModile = true;
        else
        {
            _isModile = false;
            _playerInputSystem = new PlayerInput();
        }

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if(_isModile == false)
        {
            _playerInputSystem.Enable();
            _move = _playerInputSystem.Player.Move;
        }
    }

    private void OnDisable()
    {
        if(_playerInputSystem != null)
            _playerInputSystem.Disable();
    }

    private void FixedUpdate()
    {
        if (_isModile)
        {
            MobileMove();
            MobileLookAt();
        }
        else
        {
            DekstopMove();
            DekstopLookAt();
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        }
    }

    private void DekstopMove()
    {
        _direction += _move.ReadValue<Vector2>().x * GetCameraRight(_camera) * _moveSpeed;
        _direction += _move.ReadValue<Vector2>().y * GetCameraForward(_camera) * _moveSpeed;

        _rigidbody.AddForce(_direction, ForceMode.Impulse);
        _direction = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > _maxMoveSpeed * _maxMoveSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * _maxMoveSpeed + Vector3.up * _rigidbody.velocity.y;

        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
    }

    private void MobileMove()
    {
        _direction = Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal;
        _rigidbody.AddForce(_direction * _moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 forward = camera.transform.right;
        forward.y = 0;

        return forward.normalized;
    }

    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 right = camera.transform.forward;
        right.y = 0;

        return right.normalized;
    }

    private void DekstopLookAt()
    {
        Vector3 direction = _rigidbody.velocity;
        direction.y = 0;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            _rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rigidbody.angularVelocity = Vector3.zero;
    }

    private void MobileLookAt()
    {
        Vector3 direction = _rigidbody.velocity;
        direction.y = 0;
        Vector2 turn = new Vector2(_variableJoystick.Horizontal, _variableJoystick.Vertical);

        if (turn.sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            _rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rigidbody.angularVelocity = Vector3.zero;
    }
}