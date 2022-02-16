using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject asteroids_prefab; 

    private Vector3 max_screen_point; 
    
    List<Asteroid> asteroids = new List<Asteroid>();

    private int score = 0;
    [SerializeField] private Text score_text;

    // Start is called before the first frame update
    void Start()
    {
      ServiceLocator.SetGameManager(this);
      max_screen_point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
      score_text.text = score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
      while(asteroids.Count <10)
      {
      SpawnAsteroid();
      }

    }

    void SpawnAsteroid()
    {
     float x = Random.Range(-max_screen_point.x, max_screen_point.x);
     float y = Random.Range(-max_screen_point.y, max_screen_point.y);
     GameObject spawned_asteroid = Instantiate(asteroids_prefab,new Vector3 (x, y, 0), Quaternion.identity );
      if (spawned_asteroid.GetComponent<Rigidbody2D>() != null)
       {
        spawned_asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * Random.Range(20f, Mathf.Max(100f, Time.timeSinceLevelLoad)));
       }
      
      asteroids.Add(spawned_asteroid.GetComponent<Asteroid>());

    }

    public void DestroyAsteroid(Asteroid a)
    {
        if (asteroids.Contains(a))
        {
        asteroids.Remove(a);
        Destroy(a.gameObject);
        }
    Destroy(a.gameObject);
    }


public void AddScore (int s)
  {
    score +=s;
    score_text.text = score.ToString();
    }


}
