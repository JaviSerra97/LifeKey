using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Changer : MonoBehaviour
{
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Fade_In");
    }

    // Update is called once per frame
    void Update()
    {

    }
}