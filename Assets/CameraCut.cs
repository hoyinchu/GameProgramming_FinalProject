using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCut : MonoBehaviour
{

    public GameObject Cam1;
    public GameObject Cam2;

    // Start is called before the first frame update
    void Start()
    {
        Cam2.SetActive(false);
        Cam1.SetActive(true);
    }

    private void OnEnable()
    {
        Debug.Log("Playing video");
        StartCoroutine(TheSequence());
    }

    public IEnumerator TheSequence()
    {
        Cam2.SetActive(true);
        Cam1.SetActive(false);

        yield return new WaitForSeconds(4);

        Cam2.SetActive(false);
        Cam1.SetActive(true);
    }
}
