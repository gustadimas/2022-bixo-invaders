using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_enemyTudo : MonoBehaviour
{
    public GameObject spr_nave;
    public int id;
    [SerializeField] GameObject[] takeSprites;

    public void SetSprite(int _id)
    {
        takeSprites[_id - 1].SetActive(true);
    }
}
