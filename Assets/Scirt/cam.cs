using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < 93.51651 && player.transform.position.x > 0)
        {
            if(transform.position.x <= player.transform.position.x)
            {
                transform.position = new Vector3(player.transform.position.x,2,-10);
            }
        }

        
    }
}
