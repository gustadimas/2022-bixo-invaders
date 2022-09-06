using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_admTudo : MonoBehaviour
{
    [SerializeField] float offset;

    [SerializeField] float offset2;

    [SerializeField] GameObject prefab_obj_bulletEnemy;

    [SerializeField] GameObject ship;

    [SerializeField] GameObject prefab_obj_enemy;

    [SerializeField] GameObject lifeBar;

    Queue<GameObject> spaceships = new Queue<GameObject>();
    Queue<GameObject> spaceships2 = new Queue<GameObject>();
    Queue<GameObject> spaceships3 = new Queue<GameObject>();
    Queue<GameObject> spaceships4 = new Queue<GameObject>();

    float bulletEnemy = 1f;

    bool enemyCanShoot = false;

    public TextMeshProUGUI textScore;

    public TextMeshProUGUI textStatus;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("EnemySpawn", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    if (spaceships.Count > 0)
        //    {
        //        Destroy(spaceships.Peek());

        //        spaceships.Dequeue();
        //    }
        //}

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            EnemySpawn();
        }

        if (enemyCanShoot)
        {
            GameObject bullet = null;

            enemyCanShoot = false;

            switch (Random.Range(1, 5))
            {
                case 1:
                    if (spaceships.Count > 0)
                    {
                        bullet = Instantiate(prefab_obj_bulletEnemy, spaceships.Peek().transform.position + new Vector3(0, -1, 0), Quaternion.identity);
                    }
                    break;

                case 2:
                    if (spaceships2.Count > 0)
                    {
                        bullet = Instantiate(prefab_obj_bulletEnemy, spaceships2.Peek().transform.position + new Vector3(0, -1, 0), Quaternion.identity);                       
                    }
                    break;

                case 3:
                    if (spaceships3.Count > 0)
                    {
                        bullet = Instantiate(prefab_obj_bulletEnemy, spaceships3.Peek().transform.position + new Vector3(0, -1, 0), Quaternion.identity);
                    }
                    break;

                case 4:
                    if (spaceships4.Count > 0)
                    {
                        bullet = Instantiate(prefab_obj_bulletEnemy, spaceships4.Peek().transform.position + new Vector3(0, -1, 0), Quaternion.identity);
                    }
                    break;
            }

            Invoke("BulletReset", bulletEnemy);
            
            if (bullet != null)
            {
                bullet.GetComponent<scrip_tiroTudo>().ControlDamage(tag);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5), ForceMode2D.Impulse);
            }
            
            Destroy(bullet, 2f);
        }

        textScore.text = "Score : " + score.ToString();

        textStatus.gameObject.SetActive(score % 20 == 0 && score != 0);
    }

    void EnemySpawn()
    {
        if (spaceships.Count < 4)
        {
            spaceships.Enqueue(Instantiate(prefab_obj_enemy, new Vector3(0, 0, 0), Quaternion.identity));
            spaceships2.Enqueue(Instantiate(prefab_obj_enemy, new Vector3(0, 0, 0), Quaternion.identity));
            spaceships3.Enqueue(Instantiate(prefab_obj_enemy, new Vector3(0, 0, 0), Quaternion.identity));
            spaceships4.Enqueue(Instantiate(prefab_obj_enemy, new Vector3(0, 0, 0), Quaternion.identity));

            Invoke("EnemySpawn", 1f);

            EnemyPosicion();
        }
        else
        {
            enemyCanShoot = true;

            ship.SetActive(true);

            lifeBar.SetActive(true);
        }
    }   
    
    void EnemyPosicion()
    {
        int count = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;

        foreach(GameObject obj in spaceships)
        {
            obj.transform.position = new Vector3(-6, offset2 + (spaceships.Count - count) * -offset, 0);
            count++;
            obj.GetComponent<script_enemyTudo>().id = 1;
            obj.GetComponent<script_enemyTudo>().SetSprite();
        }
        foreach(GameObject obj in spaceships2)
        {
            obj.transform.position = new Vector3(-2, offset2 + (spaceships2.Count - count2) * -offset, 0);
            count2++;
            obj.GetComponent<script_enemyTudo>().id = 2;
            obj.GetComponent<script_enemyTudo>().SetSprite();
        }
        foreach(GameObject obj in spaceships3)
        {
            obj.transform.position = new Vector3(2, offset2 + (spaceships3.Count - count3) * -offset, 0);
            count3++;
            obj.GetComponent<script_enemyTudo>().id = 3;
            obj.GetComponent<script_enemyTudo>().SetSprite();
        }
        foreach(GameObject obj in spaceships4)
        {
            obj.transform.position = new Vector3(6, offset2 + (spaceships4.Count - count4) * -offset, 0);
            count4++;
            obj.GetComponent<script_enemyTudo>().id = 4;
            obj.GetComponent<script_enemyTudo>().SetSprite();
        }
    }
    void BulletReset()
    {
        enemyCanShoot = true;
    }

    public void ShipDestroy(int id)
    {
        if (id == 1)
        {
            Destroy(spaceships.Peek());

            spaceships.Dequeue();

            ChangeScoreText();
        }

        if (id == 2)
        {
            Destroy(spaceships2.Peek());

            spaceships2.Dequeue();

            ChangeScoreText();
        }

        if (id == 3)
        {
            Destroy(spaceships3.Peek());

            spaceships3.Dequeue();

            ChangeScoreText();
        }

        if (id == 4)
        {
            Destroy(spaceships4.Peek());

            spaceships4.Dequeue();

            ChangeScoreText();
        }
    }
    void ChangeScoreText()
    {
        score += 5;
    }
}
