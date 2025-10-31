using UnityEngine;
using UnityEngine.UI;

public class PlayerFightScript : MonoBehaviour
{
    public float _hp;
    float _baseHp;
    public RectTransform _jauge;
    public Image _jaugeImage;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded = true;
    bool _isCrouching;
    public PivotPlayer _pivot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _baseHp = _hp;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _jauge.localScale = new Vector3(1 - (_baseHp - _hp) / _baseHp, 1, 1);

        if (_hp <= _baseHp / 2)
        {
            _jaugeImage.color = Color.yellow;
        }
        if (_hp <= _baseHp / 4)
        {
            _jaugeImage.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {
            this.transform.localScale = new Vector3(1, 0.5f, 1);
            _isCrouching = true;
            _pivot.rotationSpeed = _pivot.rotationSpeed / 2;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && isGrounded)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            _isCrouching = false;
            _pivot.rotationSpeed = _pivot.rotationSpeed * 2;
        }

    }

          private void OnCollisionEnter(Collision collision)
    {
        // Si l'objet touche quelque chose sous lui, il peut ressauter
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}

