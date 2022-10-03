using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrip_tiroTudo : MonoBehaviour
{
    bool canCollide = false;
    string tagDono;
    GameObject qualquerCoisa;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canCollide && collision.gameObject.tag != tagDono)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                //GameObject.Find("obj_adm").GetComponent<script_admTudo>().ShipDestroy(collision.gameObject.GetComponent<script_enemyTudo>().id);

                LinkedList<GameObject> cu2 = GameObject.Find("obj_adm").GetComponent<script_admTudo>().buceta;

                foreach (GameObject go in cu2)
                {
                    if (go.GetInstanceID() == collision.gameObject.GetInstanceID())
                    {
                        qualquerCoisa = go;
                    }
                }
                cu2.Remove(qualquerCoisa);

                GameObject.Find("obj_adm").GetComponent<script_admTudo>().ChangeScoreText();

                Destroy(collision.gameObject);

                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Ship")
            {
                SceneManager.LoadScene("Scene_Game");
            }
        }
    }
    public void ControlDamage(string tag)
    {
        canCollide = true;

        tagDono = tag;
    }
}
