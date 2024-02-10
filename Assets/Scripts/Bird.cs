using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    private float speed;
    [SerializeField]
    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        if (rigidbody2D == null)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    private void Update()
    {
        //code Android
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rigidbody2D.velocity = Vector2.up * speed;
            }
        }
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity = Vector2.up * speed;
        }
#endif
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Debug.Log("Bird :: OnCollisionEnter2D()");

        if (collision2D.collider.CompareTag("Pipe") || collision2D.collider.CompareTag("Ground"))
        {
            GameManager.Instance.Gameover();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("Bird :: OnTriggerEnter2D()");
        if (collider2D.CompareTag("PipeTrigger"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }
    public void UnfrezeeBirdPosition()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
        rigidbody2D.AddForce(Vector3.zero);
    }
}
