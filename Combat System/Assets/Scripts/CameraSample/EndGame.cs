using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            player.GetComponent<Move>().enabled = false;
            transform.parent.parent.GetComponent<NavMeshAgent>().isStopped = true;
            transform.parent.parent.GetComponent<NavMeshAgent>().velocity = new Vector3();
            transform.parent.GetChild(0).GetComponent<Animator>().SetTrigger("EndNow");
            Camera.main.transform.GetChild(0).gameObject.SetActive(true);  
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
