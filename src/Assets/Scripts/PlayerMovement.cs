
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D _body;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            _body.velocity = new Vector2(0, 7);
        }

    }
}