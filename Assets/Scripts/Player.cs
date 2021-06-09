using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private Rigidbody rigidbody;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        
        rigidbody.velocity = (movement * Speed);
    }
}
