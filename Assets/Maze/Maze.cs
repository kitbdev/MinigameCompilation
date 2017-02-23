using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{

    public GameObject repGO;
	public Text timeText;

	float timeTaken = 0;
    bool started = false;
    bool finished = false;

    void Start()
    {

    }

    void Update()
    {
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       	Vector3 repPos = ray.GetPoint(8);
		//repPos.y = 5;
		repGO.transform.position = repPos;
		//Debug.Log("mpos "+Input.mousePosition+", "+ray);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 40))
        {
            Collider col = hit.collider;
            if (!started)
            {
                if (col.CompareTag("Respawn"))// && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Debug.Log("Started");
                    started = true;
                }
            } 
			else if (!finished)
			{
				timeTaken+=Time.deltaTime;

                if (col.CompareTag("Damage") )//|| Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Debug.Log("failed");
                    started = false;
                }
				else if (col.CompareTag("Finish"))
				{
					Debug.Log("finished");
					finished = true;
                    started = false;
				}
			}
        } else {
			//Debug.Log("no hit!");
		}
    }
}
