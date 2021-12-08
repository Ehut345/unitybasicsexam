using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float timer;
    GameObject playerref;

    void Start()
    {
        playerref = FindObjectOfType<Player>().gameObject;
    }
    void FixedUpdate()
    {
        rb.AddForce(playerref.transform.forward * speed);
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Bullet");
            timer = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
