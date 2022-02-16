using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
     {
         if (collision.gameObject.GetComponent<Bullet>() != null) //if the asteroid is hit by a bullet
         {
            Destroy(collision.gameObject); // it destroys itself
            ServiceLocator.GetGameManager().AddScore(10); //adds ten to the score calling serviceLocator
            if(transform.localScale.x >= 1f) //
            {
            GameObject a1 = Instantiate(gameObject, transform.position, transform.rotation); //creates 2 new gameobjects
            GameObject a2 = Instantiate(gameObject, transform.position, transform.rotation);
            a1.transform.localScale *= 0.5f; //sets them half the scale of the parent object
            a2.transform.localScale *= 0.5f;

            Vector2 forward = GetComponent<Rigidbody2D>().velocity.normalized;  
            float speed = GetComponent<Rigidbody2D>().velocity.magnitude;
            Vector2 right = Vector2.Perpendicular(forward);

                a1.GetComponent<Rigidbody2D>().velocity = forward * 0.5f * speed * right * 0.5f * speed;
                a2.GetComponent<Rigidbody2D>().velocity = forward * 0.5f * speed * -right * 0.5f * speed;
            }

            ServiceLocator.GetGameManager().DestroyAsteroid(this);
         }
        
    }

    //rigidBody == something that moves
    private void OnTriggerExit2D (Collider2D collision)
    {
     if(collision.tag =="PlayArea")
     {
     ServiceLocator.GetGameManager().DestroyAsteroid(this);
     }
    }


}
