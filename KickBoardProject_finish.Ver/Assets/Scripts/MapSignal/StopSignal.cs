using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSignal : MonoBehaviour
{
    public GameObject stopText;
    public GameObject goodText;
    public GameObject Signal_Steady;

    Control2 control2;

    private void Awake()
	{
		control2 = GameObject.Find("Kick_ver.3").GetComponent<Control2>();
	}

    void Start()
    {
        stopText.SetActive(false);
        goodText.SetActive(false);
        Signal_Steady.SetActive(false);
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ShowStop());
        }
    }

    IEnumerator ShowStop()
    {
        Signal_Steady.SetActive(false);
        int count = 0;
        while (count < 3)
        {
            if (control2.currentSpeed == 0f)
            {
                stopText.SetActive(false);
                goodText.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                goodText.SetActive(false);
            }
            else
            {
                stopText.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                stopText.SetActive(false);
                yield return new WaitForSeconds(0.5f);                
            }
            // stopText.SetActive(true);
            // yield return new WaitForSeconds(0.5f);
            // stopText.SetActive(false);
            // yield return new WaitForSeconds(0.5f);
            count++;
        }
        Signal_Steady.SetActive(true);
    }
}
