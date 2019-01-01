using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drown : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject water;
    [SerializeField]
    private GameObject EndGamePanel;
    [SerializeField]
    private Text countDownText;

    private int currCountDown;

    private void Start()
    {
        EndGamePanel.SetActive(false);
    }

    void Update()
    {
        //in water
        if (player.transform.position.y <= water.transform.position.y)
        {
            StartCoroutine(Timer());
        }
    }

    void Drowned()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().FreezePlayer();
        EndGamePanel.SetActive(true);
    }


    //FIXXXXX with broadcast message maybe???

    public IEnumerator Timer()
    {
        currCountDown = 10;
        while (currCountDown > 0)
        {
            countDownText.text = "Drowning! " + currCountDown;
            yield return new WaitForSeconds(1.0f);
            currCountDown--;
        }

        Drowned();
    }
}
