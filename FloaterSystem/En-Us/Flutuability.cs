using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(FixedJoint))]
public class Flutuability : MonoBehaviour
{
    [HideInInspector]
    public float Force, ActualForce, WaveEfect, MinHeight, Flutuação;

    private float RandHeight;
    private bool Changed;

    private void Awake()
    {
        RandHeight = MinHeight;
        GetComponent<FixedJoint>().connectedBody = transform.root.GetComponent<Rigidbody>();

        FloaterController Controler = transform.root.GetComponent<FloaterController>();
        Controler.Floaters.Add(gameObject.GetComponent<Flutuability>());
    }
    void Update()
    {
        if (transform.position.y < RandHeight)
        {
            
            if (!Changed)
            {
                RandHeight = MinHeight + Random.Range(-WaveEfect, WaveEfect);
                ActualForce = 0;
                Changed = true;
            }

            if (ActualForce < Force)
                ActualForce += Force * Time.deltaTime * 2;

            if (GetComponent<Rigidbody>().velocity.y < Flutuação + (Mathf.Abs(RandHeight - transform.position.y) * 2)) // put * instead of + for long ships / floating players(if you want).
                GetComponent<Rigidbody>().AddForce(Vector3.up * ActualForce * Time.deltaTime * 60, ForceMode.Impulse);
            else
                ActualForce = 0; // remove this for more stability.
        }
        else
        {
            Changed = false;
        }
    }
}
