using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource audio;
    public float speed;
    public Transform shootpoint;
    public float gravity = -9.81f;
    Vector3 velocity;

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        move();
    }
    void move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) && !startmenu.GameIsPaused)
        {
            GameObject temp = NewPooler.Instance.GetPooledObject("Bullet", shootpoint.position);
            audio.Play();
        }
    }
}

