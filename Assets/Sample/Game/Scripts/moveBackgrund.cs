using UnityEngine;

public class moveBackgrund : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").transform;
        }

        if (player)
        {
            transform.Translate(1 * Time.deltaTime * Vector3.down);
            if(gameObject.transform.position.y < -4)
            {
                gameObject.transform.position = new Vector3(player.position.x, 4,3);
            }
        }
        
    }
}
