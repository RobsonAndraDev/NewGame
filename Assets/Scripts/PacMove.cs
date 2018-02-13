using UnityEngine;
using System.Collections;

public class PacMove : MonoBehaviour {
    Animator animator;
    float x, y;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        // transform.position.z = 0;
        Walk();
	}

    void Walk()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.RightArrow))
        {
            setDirectionsFalse();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetBool("clickLeft", true);
                x = -0.05F;
            }
            else
            {
                animator.SetBool("clickRight",  true);
                x = 0.05F;
            }
            //setNoAcation();
            y = 0;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)
                || Input.GetKeyDown(KeyCode.DownArrow))
        {
            setDirectionsFalse();
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.SetBool("clickDown", true);
                y = -0.05F;
            }
            else
            {
                animator.SetBool("clickUp", true);
                y = 0.05F;
            }
            x = 0;
        }
        Debug.Log("Position x: " + transform.position.x);
        if(transform.position.x <= -5.81f && (transform.position.y <= 0.50f && transform.position.y >= 0.05)) {
            // transport pacman
            transform.Translate(11.72f, y, 0, Space.World); // 
        } else if(transform.position.x >= 5.91f && (transform.position.y <= 0.50f && transform.position.y >= 0.05)) {
            // transport pacman
            transform.Translate(-11.72f, y, 0, Space.World);
        } else {
            transform.Translate(x, y, 0, Space.World);
        }
        transform.Rotate(0, 0, 0, Space.World);
    }

    void setNoAcation()
    {
        //System.Threading.Thread.Sleep(5000);
        setDirectionsFalse();
        animator.SetBool("noAction", true);
    }

    void setDirectionsFalse()
    {
        animator.SetBool("noAction", false);
        animator.SetBool("clickLeft", false);
        animator.SetBool("clickRight", false);
        animator.SetBool("clickUp", false);
        animator.SetBool("clickDown", false);
    }
}
