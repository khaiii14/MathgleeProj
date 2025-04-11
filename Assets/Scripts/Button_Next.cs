using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Next : MonoBehaviour
{
    public GameObject Panel; // Panel soal quiz
    public GameObject doorFrame;
    // Start is called before the first frame update
    void Start()
    {
        if (doorFrame != null)
            doorFrame.SetActive(true);
    }

    public void OnNextButtonClicked()
    {
        if (doorFrame != null)
            doorFrame.SetActive(false); // Hilangkan doorFrame

        if (Panel != null)
            Panel.SetActive(false); // Sembunyikan panel quiz (opsional)
    }
}
