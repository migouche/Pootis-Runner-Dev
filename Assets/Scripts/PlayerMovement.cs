using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, sidespeed;
    public float jumpforce;
    public float offset;
    public int side;
    public Rigidbody rb;
    public bool grounded, crouching;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            --side;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ++side;
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            Jump();
        if (Input.GetKeyDown(KeyCode.DownArrow) && !crouching)
            StartCoroutine(Crouch());
        side = Mathf.Clamp(side, -1, 1);
        rb.AddForce(new Vector3 { z = speed * Time.deltaTime }, ForceMode.VelocityChange);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(offset * side, transform.position.y, transform.position.z), sidespeed);
    }
    
    public IEnumerator Crouch()
    {
        crouching = true;
        transform.localScale /= 2;
        yield return new WaitForSecondsRealtime(1);
        transform.localScale *= 2;
        crouching = false;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
        grounded = false;

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "floor")
            grounded = true;
    }
    
    void OnCollisionStay(Collision col)
    {/*
        if (col.collider.tag == "floor")
            grounded = true;*/
    }
    
    void OncollisionExit(Collision col)
    {
        if (col.collider.tag == "floor")
            grounded = false;
    }
}
