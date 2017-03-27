using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WhackAMole : MonoBehaviour
{


	public GameObject molePrefab;
	public List<GameObject> moles = new List<GameObject>();
	public int dimension = 3;

	public int curScore = 0;

    void Start()
    {
		// instantiate all of the moles
		for (int i = 0; i < dimension; i++)
		{
			for (int j = 0; j < dimension; j++)
			{
				GameObject m = Instantiate(molePrefab);
				m.transform.SetParent(transform);
				m.transform.position = new Vector3(i-dimension/2f,j-dimension/2f,0);
				//m.GetComponent<EventTrigger>().triggers[0].callback.AddListener((data)=>MoleTapped(i*dimension+j)); 
				moles.Add(m);
			}
		}
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//.GetTouch(0).position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 40))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
				if (hit.collider.GetComponent<Mole>().TappedOn()) {
					curScore += 1;
				} else {
					curScore -= 1;
				}
            }
        }
    }
}
