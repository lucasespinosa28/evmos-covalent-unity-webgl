using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator n_animator;
    void Start()
    {
        n_animator = gameObject.GetComponent<Animator>();
    }

    public static int count = 0;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -6.5)
        {
            if (Input.GetKey(KeyCode.A))
            {
                PlayerRun(true);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                transform.Translate(10 * Time.deltaTime * Vector3.left);
            }
        }
        if(transform.position.x < 52.2)
        {
            if (Input.GetKey(KeyCode.D))
            {
                PlayerRun(true);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                transform.Translate(10 * Time.deltaTime * Vector3.right);
            }
        }
        if(Input.GetKeyUp(KeyCode.A) | Input.GetKeyUp(KeyCode.D))
        {
            PlayerRun(false);
        }
    }
    void PlayerRun(bool _bool)
    {
        n_animator.SetBool("isRun", _bool);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Pineapple"))
        {
            count++;
            GameObject.Find("Wallet")
                .GetComponent<UIDocument>()
                .rootVisualElement
                .Q<Label>("Pineapple")
                .text = $"PINEAPPLE: {count}";
        }
        
        if (collision.gameObject.name.Contains("Enemy") || collision.gameObject.name.Contains("Pineapple"))
        {
            n_animator.SetTrigger("isHit");
            Destroy(gameObject,0.5f);
        }
    }
}
