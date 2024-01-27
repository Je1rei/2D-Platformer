using TMPro;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class PhysicsMovement : MonoBehaviour
{
    private readonly string _horizontal = "Horizontal";
    private readonly string _jump = "Jump";
    private readonly string _groundLayer = "Ground";

    [SerializeField] private Transform _groundCheckPoint;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    public bool IsRun { get; private set; }

    private void Awake()
    {
        IsRun = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(float speed)
    {
        float horizontal = Input.GetAxisRaw(_horizontal);
        transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

        IsRun = horizontal != 0 ? true : false;
        _spriteRenderer.flipX = horizontal < 0 ? true : false;
    }

    public void Jump(float jumpForce)
    {
        if (IsGround())
        {
            float jump = Input.GetAxis(_jump);

            _rigidbody.AddForce(new Vector2(0, jump * jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    public bool IsGround()
    {
        float _radiusOverlap = 0.7f;
        LayerMask groundLayer = LayerMask.GetMask(_groundLayer);
        return Physics2D.OverlapCircle(_groundCheckPoint.position, _radiusOverlap, groundLayer);
    }
}
