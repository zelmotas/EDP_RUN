using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    
    private void Update()
    {
        //Sa fais que l'image de scie puisse faire des rotations
        transform.Rotate(0, 0, 260 * speed * Time.deltaTime);
    }
}
