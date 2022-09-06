using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_enemyTudo : MonoBehaviour
{

    public GameObject spr_nave;
    public int id;
    [SerializeField] GameObject[] takeSprites;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite()
    {
        switch (id)
        {
            case 1:
                takeSprites[0].SetActive (true);
                spr_nave = takeSprites[0];
                break;
            case 2:
                takeSprites[1].SetActive(true);
                spr_nave = takeSprites[1];
                break;
            case 3:
                takeSprites[2].SetActive(true);
                spr_nave = takeSprites[2];
                break;
            case 4:
                takeSprites[3].SetActive(true);
                spr_nave = takeSprites[3];
                break;
        }
        
    }
}
