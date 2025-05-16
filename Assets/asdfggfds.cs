using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdfggfds : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(10, 10, 10);

        // transform.rotation = new Quaternion(0,10,0,0);

        // transform.rotation = Quaternion.Euler(30, 10, 20);

        transform.RotateAround(Target.transform.position, Vector3.forward, 0.2f);
    }
}
