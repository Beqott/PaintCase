using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChangeAndPickBall : MonoBehaviour
{
    public GameObject player;
    public Animator anim;

    private bool isGrowed;
    public GameObject plane2;
    public static bool firstHit=false;
    private float getbigger = 0.1f;
    public static float cameraYoffset;
    public static bool cameraoffset;
    public FollowCamera cam;
    private GameObject firstobject;
    public Color characterColor;
    public GameObject counter;
    public static int ballcounter;
    public static int percentBall;
    public static int ballsayac;
    public GameObject splashBox;
    public Text percenttext;
    public GameObject camera,nextlevelbutton;
    public GameObject orangeTuv;
    public static float howBigger;
    
    
    private void OnCollisionEnter(Collision collision)
   
    {
        if (collision.gameObject.CompareTag("tuzak"))
        {
            howBigger -= 0.082f;
            player.transform.localScale = new Vector3(player.transform.localScale.x - getbigger, player.transform.localScale.y - getbigger, player.transform.localScale.z - getbigger);

        }
        if (collision.gameObject.CompareTag("red") || collision.gameObject.CompareTag("yellow") || collision.gameObject.CompareTag("blue"))
        {
            ballsayac += percentBall; 
            howBigger += 0.032f;
            isGrowed = true;
   
            player.transform.localScale = new Vector3(player.transform.localScale.x+getbigger, player.transform.localScale.y+getbigger, player.transform.localScale.z+getbigger);
            cam.offset.y = cam.offset.y + 0.13f;
            cam.offset.z = cam.offset.z - 0.13f;

           



            Destroy(collision.gameObject,0.02f);

        }

        if (collision.gameObject.CompareTag("finish"))
        {
            anim.SetBool("isfinish", true);
            anim.SetBool("floating", true);
            splashBox.SetActive(true);
            orangeTuv.SetActive(true);
            camera.SetActive(true);
        }
        if (collision.gameObject.CompareTag("orange"))
        {
            Debug.Log("tuvale .çarpt");
            
            plane2.SetActive(true);
            player.SetActive(false);
            counter.SetActive(true);
            nextlevelbutton.SetActive(true);
        }
       
       
    }

    
    private void Update()
    {
        if(ballsayac >= 100)
        {
            Debug.Log("2 KATI KAZANÇ");
        }
        percenttext.text ="% " + ballsayac.ToString();
        if (isGrowed)
        {
            
            splashBox.GetComponent<PaintIn3D.P3dPaintDecal>().Radius += howBigger;
            isGrowed = false;
        }
        Debug.Log(ballcounter);


    }

    void Start()
    {

        percentBall = 100 / ballcounter;
    }



















}
