using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "CoinCount: " + coinCount.ToString(); 
        
        if(coinCount == 13)
        {
            Destroy(door);
        }
    }

     public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
