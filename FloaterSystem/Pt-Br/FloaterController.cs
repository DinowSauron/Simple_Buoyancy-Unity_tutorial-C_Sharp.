using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloaterController : MonoBehaviour
{
    [HideInInspector]
    public List<Flutuability> Floaters; // Lista dos scripts "Flutuability"
    public float Densidade = 0.997f; // (quanto maior, mais irá boiar)
    public float Ondulação = 0; // variação, para "simular" as ondas...
    public float VelocidadeDeSubida = 2; // velocidade que ele irá voltar pra superficie após entrar em contato com a água.

    public float AlturaDoMar = 0; 
    
    void Update()
    {
        foreach (Flutuability floaters in Floaters)
        {
            floaters.Força = Densidade / (Densidade/4);
            floaters.Ondulação = Ondulação;
            floaters.Flutuação = VelocidadeDeSubida;
            floaters.AlturaMinima = AlturaDoMar;
        }
    }
}
