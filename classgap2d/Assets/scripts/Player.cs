using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //i need to call it cause i access the UI for add score text and lives text on screen
using UnityEngine.SceneManagement;//i have to scenes intro and gamescene i access scenemanagement to change scene when i die


public class Player : MonoBehaviour //MonoBehaviour is very important needs always to be there 

{
    // Start is called before the first frame update
    
   [SerializeField] private float speed = 10f; //player's speed
   [SerializeField] private float turn_speed = 360f; //turn speed its in degrees (?)
   [SerializeField] private GameObject Bullet_prefab; // recall prefab of bullets
   [SerializeField] private GameObject BulletSpawn; 
   [SerializeField] private float fire_rate = 10f; //bullet x seconds ex: 1/s 

   private float last_time_fired = 0;
   private float lives = 3f; //number of lives

    [SerializeField] private Text lives_text; //text on screen indicates number of lives i have


    void Start() //everything i want to have at the start of the screen from inside the player script
    {
        lives_text.text = "Lives:" + lives; //print the lives var i create in the lives text
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetAxisRaw("Vertical") > 0)   //moves player
    {
        transform.Translate(Input.GetAxisRaw("Vertical") * transform.up * speed * Time.deltaTime, Space.World);
                            //input i press buttons      //goes up     //speed var is player speed  
                            //time deltatime is the fallout thing he was talking about the movement is related to time and not the speed of computer of people playing the game
                            //Space world i don't remember, something related to the coordinates of the world and not linked to the player(?)
    }
     if (Input.GetAxis("Horizontal")!=0) // rotates player
     {
        transform.Rotate(transform.forward, -Input.GetAxisRaw("Horizontal") * turn_speed * Time.deltaTime);
     }

     if (Input.GetButton("Fire1") && Time.timeSinceLevelLoad > last_time_fired + 1/fire_rate) // fire bullets makes sure the timing is right
     {
        GameObject spawned_bullet = Instantiate(Bullet_prefab, BulletSpawn.transform.position, Quaternion.identity);
        spawned_bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f);
        last_time_fired =Time.timeSinceLevelLoad;
        spawned_bullet.GetComponent<Bullet>().owner = this; //the bullet is owned by the player
     }
        
    }
    void TakeDamage () //Take Damage, did we create it or was it already there 
    { // removes one life when we take damage and reupload the text
        lives--;
        lives_text.text = "Lives : " + lives;
        if (lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
        //if i die i will be automatically redirected to the main scene

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.GetComponent<Asteroid>() !=null) //when i collide with an asteroid i take damage and the asteroid is destroyed
      {
        ServiceLocator.GetGameManager().DestroyAsteroid(collision.GetComponent<Asteroid>());
        TakeDamage();
           
      }
    }
}
