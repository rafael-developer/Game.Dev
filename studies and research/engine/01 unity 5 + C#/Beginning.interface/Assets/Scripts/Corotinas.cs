using System.Collections;
using UnityEngine;

public class Corotinas : MonoBehaviour
{
    public float segundosDeEspera = 1;
    void Start()
    {
        StartCoroutine(CorotinaTeste1(segundosDeEspera));   
    }
    IEnumerator CorotinaTeste (float segundos)
    {
        //executa alguns comandos
        // espera por alguns segundos
        //volta a executar comandos
        print("Comecei a executar uma corotina.");
        yield return new WaitForSeconds(segundos); //espere por 5 segundo depois volta a executar a linha seguinte
        print("Depois de 5 segundos, volto a executar a função normalmente.");

    }
    IEnumerator CorotinaTeste1 (float segundos)
    {
        print("Comecei a executar uma corotina.");
        float tempoAtual = 0;
        while (tempoAtual < segundos)
        {
            //passar pro próximo frame
            tempoAtual += Time.deltaTime; //o tempo que o ultimo frame demorou pra ser executado
            print("Esperando...");
            yield return new WaitForEndOfFrame();
        }
        print("Depois de " + segundos + "segundos, volto a executar a função normalmente.");

    }
    // Essa corotina conta até 10 e depois executa outra coisa
    IEnumerator CorotinaBase ()
    {
        yield return new WaitForEndOfFrame();
        print("Vou contar até 10...");
        StartCoroutine(ContarAte10());
        //as linhas só serão executadas quando as corotinas acima forem executadas
        int soma = 10 + 4;
        print("O resultado da soma: " + soma);
    }
    IEnumerator ContarAte10()
    {
        for(int i = 1; i<= 10; i++)
        {
            print(i);
            yield return new WaitForSeconds(1);
        }
    }
}
