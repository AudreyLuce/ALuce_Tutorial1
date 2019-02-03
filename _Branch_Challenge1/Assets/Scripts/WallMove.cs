using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform target;
    public float z = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        target = cylinder.transform;
        target.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
        target.transform.position = new Vector3(16f, 0.0f, z);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (Vector3.Distance(transform.position, target.position) < 1.5f)
        {
            z = -z;
            target.transform.position = new Vector3(16f, 0.0f, z);
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
