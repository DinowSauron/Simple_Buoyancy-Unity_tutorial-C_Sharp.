using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I'm sorry, but I didn't test the version of the script I made in English, so if there are errors please send a comment on the video or comment on your solution
// if you can't solve it, download the portuguese version, and if you still have errors, see if they are script errors or application errors, like something you did wrong, review the tutorial more carefully

[RequireComponent(typeof(Rigidbody))]
public class FloaterController : MonoBehaviour
{
    [HideInInspector]
    public List<Flutuability> Floaters; //  List of "Flutuability" scripts
    public float Density = 1; // (the bigger, the more it will float)
    public float WaveAfects = 0; // variation, to "simulate" the waves ...
    public float UpFloatingVelocity = 2; // speed that it will return to the surface after contacting the water.

    public float OceanHeight = 0; // '-'
    
    void Update()
    {
        foreach (Flutuability floaters in Floaters)
        {
            floaters.Force = Density / (Density/4);
            floaters.WaveEfect = WaveAfects;
            floaters.Flutuação = UpFloatingVelocity;
            floaters.MinHeight = OceanHeight;
        }
    }
}
