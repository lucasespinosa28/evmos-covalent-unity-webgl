using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 m_startPosition;
    private bool m_Hit = false;
    private Rigidbody2D m_Rigidbody;
    void Start()
    {
        m_startPosition = gameObject.transform.position;
        m_startPosition = new Vector3(m_startPosition.x, Random.Range(-0.5f, 3f), 1f);
        m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_Rigidbody.gravityScale = Random.Range(1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Hit)
        {
            transform.Translate(10 * Time.deltaTime * Vector3.up);
        }
        if(gameObject.transform.position.y > m_startPosition.y)
        {
            m_Rigidbody.gravityScale = +Mathf.Abs(m_Rigidbody.gravityScale);
            m_Hit = false;
        }
        if (Random.Range(0, 500) == 200)
        {
            gameObject.GetComponent<Animator>().SetTrigger("isBlink");
        }
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "groundCollider")
        {
            m_Rigidbody.gravityScale = -Mathf.Abs(m_Rigidbody.gravityScale);
            m_Hit = true;
        }
    }
}
