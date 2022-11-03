using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SwipeControl : MonoBehaviour
{
    public GameObject player;
    private bool sol;
    private bool sag;
    public float hiz = 3.0f;
    private bool isgameon;
    [SerializeField]
    public Animator anim;
    public GameObject[] CanvasKapat;
    public  int level;
    void FixedUpdate()
    {

        if (isgameon)
        {
            player.transform.Translate(0, 0, hiz * Time.deltaTime);
            anim.SetBool("isgameon", true);
            for (int i = 0; i < CanvasKapat.Length; i++)
            {
                CanvasKapat[i].SetActive(false);
            }
        }

        Vector3 sag_git = new Vector3(3.5f, player.transform.position.y, player.transform.position.z);
        Vector3 sol_git = new Vector3(-3.5f, player.transform.position.y, player.transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            if (parmak.phase == TouchPhase.Began)
            {
                isgameon = true;

            }
            if (parmak.deltaPosition.x > 6.0f)
            {
                sag = true;
                sol = false;
            }
            if (parmak.deltaPosition.x < -6.0f)
            {

                sag = false;
                sol = true;
            }

            if (sag == true)
            {
                player.transform.position = Vector3.Lerp(transform.position, sag_git, 1.4f * Time.deltaTime);
            }

            if (sol == true)
            {
                player.transform.position = Vector3.Lerp(transform.position, sol_git, 1.4f * Time.deltaTime);

            }

        }

    }


    public void NextLevel()
    {
        SceneManager.LoadScene(level);
    }
   
}