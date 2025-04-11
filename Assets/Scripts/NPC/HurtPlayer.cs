using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Hit");
            if (timer != null)
            {
                timer.ReduceTime(5F);
            }
            else{
                Debug.LogWarning("Timer belum aktif");
            }
        }
    }
}
