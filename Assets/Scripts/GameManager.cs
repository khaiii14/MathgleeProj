using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalSoal = 10;
    public int currentSoal = 0;
    private int nilai = 0;

    public GameObject PanelMenang;
    public Text Nilai;
    public GameObject[] Stars;
    
    public void JawabanBenar()
    {
        nilai += 10;
        currentSoal++;
        Debug.Log("Jawaban benar, skor sekarang: " + nilai);
        HasilAkhir();
    }

    public void JawabanSalah()
    {
        currentSoal++;
        HasilAkhir();
    }

    private void HasilAkhir()
    {
        if (currentSoal >= totalSoal)
        {
            Invoke("PopUpMenang", 1.5f);
        }
    }

    public void PopUpMenang()
    {
        PanelMenang.SetActive(true);
        Nilai.text = "Nilai: " + nilai;

        int bintang = 0;
        if (nilai > 80) bintang = 3;
        else if (nilai >= 40) bintang = 2;
        else if (nilai > 0) bintang = 1;

        for (int i = 0; i < Stars.Length; i++)
        {
            Stars[i].SetActive(i < bintang);
        }

    }
}
