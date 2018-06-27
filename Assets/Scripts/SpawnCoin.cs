using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{

    public GameObject coinToSpawn;
    private int spawnCount;
    public float timeToReset = 4;
    public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
	    timer += Time.deltaTime;
	    if (Input.touchCount != 0)
	    {
	        Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
	        if(GetComponent<BoxCollider>() == Physics2D.OverlapPoint(screenToWorld))
	        {
	            Instantiate(coinToSpawn,screenToWorld,Quaternion.identity);
	            spawnCount += 1;
	            timer = 0;
	        }
	    }
	    if (Input.GetMouseButtonDown(0))
	    {
	        RaycastHit hit;
	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        if(Physics.Raycast(ray, out hit))
	        {
	            if (hit.transform.name == name)
	            {
	                if (spawnCount < 6)
	                {
	                    var getDistance = Vector3.Distance(ray.origin, hit.transform.position);
	                    var spawnpoint = ray.GetPoint(getDistance);
	                    spawnpoint = spawnpoint + Vector3.up/2;
	                    Instantiate(coinToSpawn,spawnpoint,Quaternion.identity);
	                    spawnCount += 1;
	                    timer = 0;
	                }
	            }
	        }
	    }

	    if (timer >= timeToReset)
	    {
	        spawnCount = 0;
	    }
	        
	}
}
