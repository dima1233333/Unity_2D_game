using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _jumpForse;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGroud;
    [SerializeField] private Collider2D _headCollider;
    [SerializeField] private float _headCheckerRadius;
    [SerializeField] private Transform _headChecker;

    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _runAnimatorKey;
    [SerializeField] private string _jumpAnimatorKey;

    private float _direction;
    private Rigidbody2D _rd;
    private bool _Jump;
    private bool _crawl;

    private void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = Input.GetAxis("Horizontal");

        _animator.SetFloat(_runAnimatorKey, Mathf.Abs(_direction));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _Jump = true;

        }
        if (_direction > 0 && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction < 0 && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
        }

        _crawl = (Input.GetKey(KeyCode.C));
    }

    private void FixedUpdate()
    {
        _rd.velocity = new Vector2(_direction * _speed, _rd.velocity.y);

        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGroud);
        bool canStand = !Physics2D.OverlapCircle(_headChecker.position, _headCheckerRadius, _whatIsGroud);

        _headCollider.enabled = !_crawl && canStand;

        if (_Jump && canJump)
        {
            _rd.AddForce(Vector2.up * _jumpForse);
            _Jump = false;
        }

        _animator.SetBool(_jumpAnimatorKey, !canJump);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_headChecker.position, _headCheckerRadius);
    }
    public void AddHp(int hpPoints)
    {
        Debug.Log("Hp raised " + hpPoints);
    }

    public void AddBronze(int bronzeCoin)
    {
        Debug.Log("Bronze " + bronzeCoin);
    }

    public void AddChestCoin(int chestcoin)
    {
        Debug.Log("Coin" + chestcoin);
    }
    public void AddSilver(int siverCoin)
    {
        Debug.Log("Coin " + siverCoin);
    }


}
