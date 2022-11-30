using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private Transform player = null;
    public float x;
    public float y;
    public float z;
  
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").transform;
        }

        if (player)
        {
            transform.position = Vector3.Lerp(transform.position,player.transform.position + new Vector3(x, y, z), 0.1f);
        }
    }
}
