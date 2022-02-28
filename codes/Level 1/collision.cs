using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            if (!other.collider.GetComponent<PlayerController>().isDead)
            {
                other.collider.GetComponent<PlayerController>().killPlayer();
            }
        }
    }
}
