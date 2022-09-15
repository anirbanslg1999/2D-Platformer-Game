using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D playerRb2d;
    BoxCollider2D playerBoxCollider;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpHeight;
    // dont use layermask instead try tags and eventually use enums
    [SerializeField]
    LayerMask platformLayermask;

    [SerializeField]
    ScoreController scoreController;

    private float _horizontalInput;
    private float _verticalInput;


    Vector3 scale;
    bool isCrouching;

    private void Awake()
    {
        playerBoxCollider = GetComponent<BoxCollider2D>();
        playerRb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Jump");

        PlayerAnnimation(_horizontalInput, _verticalInput);
        PlayerMovement(_horizontalInput, _verticalInput);

    }
    public void PlayerMovement(float _horizontal,float  _vertical)
    {
        Vector3 pos = transform.position;
        pos.x += _horizontal * moveSpeed * Time.deltaTime;
        transform.position = pos;
        if(_vertical > 0 && IsGrounded())
        {
            //rb2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Force);
            playerRb2d.velocity = Vector2.up * jumpHeight;
        }
    }
    public void PlayerAnnimation(float _horizontalInput, float _verticalInput)
    {
        if (IsGrounded())
        {
        // Move animation
        _animator.SetFloat("Speed", Mathf.Abs(_horizontalInput));
        }
        // Direction to look
        scale = transform.localScale;
        if (_horizontalInput < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (_horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // Jump Animation
        if (_verticalInput > 0 && !isCrouching)
        {
            _animator.SetBool("isJumping", true);
        }
        else
        {
            _animator.SetBool("isJumping", false);
        }

        // Crouch Animation
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
/*            float xOffset = -0.1433218f;
            float yOffset = 0.595759f;

            float xSize = 0.8866436f;
            float ySize = 1.291518f;*/
            CrouchAnimationm(isCrouching);

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
/*            float xOffset = 0f;
            float yOffset = 1f;

            float xSize = 0.6f;
            float ySize = 2.1f;*/
            CrouchAnimationm(isCrouching);
        }
    }
    public void CrouchAnimationm(bool _isCrouching)
    {
        _animator.SetBool("isCrouching", isCrouching);
/*        boxCollider2d.offset = new Vector2(xOff, yOff);
        boxCollider2d.size = new Vector2(xSiz, ySiz);*/
    }

    private bool IsGrounded()
    {
        RaycastHit2D rayCast2d = Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size,0f, Vector2.down , 0.1f, platformLayermask);
        return rayCast2d.collider != null;
    }
    public void GotKey()
    {
        scoreController.IncrementScore(10);

    }
}
