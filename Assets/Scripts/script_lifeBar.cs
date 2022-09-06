using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class script_lifeBar : MonoBehaviour
{
    [SerializeField] int barHealth = 100;

    public TextMeshProUGUI lifeText;

    public TextMeshProUGUI lifeInformation;

    private int healthInitial;

    private void Start()
    {
        lifeText.text = "Lifebar : " + barHealth;

        healthInitial = barHealth;
    }

    private void Update()
    {
        if (barHealth == (healthInitial / 2))
        {

            lifeInformation.text = "Vida pela metade!!";
        }
        else
        {
            lifeInformation.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);

            ManageLife();
        }
    }

    private void ManageLife()
    {
        if ((barHealth - 2) > 0)
        { 
            barHealth -= 2;

            lifeText.text = "Lifebar : " + barHealth;
        }
        else
        {
            barHealth = 0;

            lifeText.text = "Morreu!!";

            Invoke("ResetScene", 1.5f);
        } 
    }

    private void ResetScene() 
    {
        SceneManager.LoadScene("Scene_Game");
    }
}
