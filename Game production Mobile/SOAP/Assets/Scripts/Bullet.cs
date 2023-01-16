using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Vector3 movement;
    
    void Start()
    {
        
    }

    void Update()
    {
        movement = new Vector3(0, moveSpeed, 0);
        gameObject.transform.position += movement * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true) 
        {
            collision.gameObject.GetComponent<Health>().RemoveHP(1);
            Destroy(gameObject);
        }
    }
}
