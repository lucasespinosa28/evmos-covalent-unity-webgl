using UnityEngine;

public class Prize : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Animator>().SetTrigger("isCollected");
    }
}
