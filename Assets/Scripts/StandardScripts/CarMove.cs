using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float carSpeed = 5f;
    Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up  * carSpeed;
    }


    void OnTriggerEnter2D(Collider2D hitInfo) {
    
    CarWall barrier = hitInfo.GetComponent<CarWall>();
    
    if(barrier != null)
    {
        Debug.Log("ALOOOO");
        rb.position = new Vector2(Random.Range(7.944f,8.573f),Random.Range(3.725f,-4.725f));
    }
   }
}
