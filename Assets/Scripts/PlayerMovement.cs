using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float xySpeed = 2;

    //i dont think yaw makes sense
    //if we are copying SF, the ship animates into a roll and pitch
    //but you're just holding down left right
    //not sure how that translates to physics

    private float pitch;
    private float yaw;

    private float v;
    private float h;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs(){
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleInputs();
        LocalMove(h, v, xySpeed);
        ClampPosition();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision has happened!");
    }

    /*
    void OnTriggerEnter(Collision collision)
    {
        //Debug.Log(collision);
    }
    */

    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }

    void ClampPosition(){
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        //pos.z = Mathf.Clamp01(pos.z);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }


    
}
