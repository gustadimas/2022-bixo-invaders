using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_admTudo : MonoBehaviour
{
    [SerializeField] float offset;

    [SerializeField] float offset2;

    [SerializeField] GameObject ship;

    [SerializeField] GameObject prefab_obj_enemy;

    public LinkedList<GameObject> buceta = new LinkedList<GameObject>();

    public TextMeshProUGUI textScore;

    public TextMeshProUGUI textStatus;

    int score = 0;

    [SerializeField] int quantH;

    [SerializeField] int quantV;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
        
        ship.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            EnemySpawn();
        }
    }
    void EnemySpawn()
    {
        for (int i = 0; i < quantH; i++)
        {
            for (int j = 0; j < quantV; j++)
            {
                GameObject cu = Instantiate(prefab_obj_enemy, transform.position, Quaternion.identity);

                buceta.AddLast(cu);

                cu.transform.position = new Vector3(i - (quantH - 1) / 2, 2.5f - (j * 1.5f), 0);

                //cu.GetComponent<script_enemyTudo>().id = 1;
                cu.GetComponent<script_enemyTudo>().SetSprite(Random.Range(1, 5));
            }
        }
    }
    public void ChangeScoreText()
    {
        score += 5;

        textScore.text = "Score : " + score.ToString();

        textStatus.gameObject.SetActive(score % 20 == 0 && score != 0);
    }
}
