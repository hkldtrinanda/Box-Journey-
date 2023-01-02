using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Transform target;
   
    private void Update()
    {
        gameObject.transform.position = new Vector2(target.position.x, transform.position.y);
        /*target*/
    }
}
