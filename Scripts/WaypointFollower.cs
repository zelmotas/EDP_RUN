using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    //sa c'est pour que le jeux save ou bouger le platform
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    //Cette variable est pour la vitesse du platform
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        //Cela signifie que si la distance actuelle entre la plate-forme et l'objet est de 0,1f, il faut changer de direction.  
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime* speed);
    }
}
