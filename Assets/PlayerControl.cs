using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    Rigidbody rb;
    float speed = 5f;
    float jump = 8f;
    float dash = 3f;

    Vector3 dir = Vector3.zero;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();

        if(Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

        if(Input.GetButtonDown("Dash")) {
            rb.AddForce(transform.forward * dash, ForceMode.Impulse);
        }
    }

    void FixedUpdate() {

        if (dir != Vector3.zero) {
            Debug.Log("FixedUpdate!!");
            if (Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z)) {
                transform.Rotate(new Vector3(0f, 1f, 0f));
            }

            transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * 15f);
        }

        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
    }
}
