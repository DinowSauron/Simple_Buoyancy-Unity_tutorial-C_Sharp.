using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(FixedJoint))]
public class Flutuability : MonoBehaviour
{
    [HideInInspector]
    public float Força, ForçaAtual, Ondulação, AlturaMinima, Flutuação;

    private float AlturaVariavel;
    private bool Changed;
    private void Awake()
    {
        AlturaVariavel = AlturaMinima;
        GetComponent<FixedJoint>().connectedBody = transform.root.GetComponent<Rigidbody>();

        FloaterController Controler = transform.root.GetComponent<FloaterController>();
        Controler.Floaters.Add(gameObject.GetComponent<Flutuability>());
    }
    void Update()
    {
        if (transform.position.y < AlturaVariavel)
        {
            
            if (!Changed)
            {
                AlturaVariavel = AlturaMinima + Random.Range(-Ondulação, Ondulação);
                ForçaAtual = 0;
                Changed = true;
            }

            if (ForçaAtual < Força)
                ForçaAtual += Força * Time.deltaTime * 2;

            if (GetComponent<Rigidbody>().velocity.y < Flutuação + (Mathf.Abs(AlturaVariavel - transform.position.y) * 2)) // coloque * ao invés de + para navios longos/jogadores boiantes(se quiser).
                GetComponent<Rigidbody>().AddForce(Vector3.up * ForçaAtual * Time.deltaTime * 60, ForceMode.Impulse);
            else
                ForçaAtual = 0; // remova isto para mais estabilidade.
        }
        else
        {
            Changed = false;
        }
    }
}
