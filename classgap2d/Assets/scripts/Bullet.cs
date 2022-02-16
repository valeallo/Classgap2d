using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   

    public Player owner;
    private float lifespan = 5f; //5 seconds
    // Start is called before the first frame update
    void Start()
    {
    StartCoroutine(Despawn());//what is coroutine
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Despawn ()
    {

        yield return new WaitForSeconds(lifespan);// Yield (???) 
        Destroy(gameObject);
       
    }

}
