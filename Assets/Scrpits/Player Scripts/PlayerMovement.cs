using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Varibles For movments of player
    private CharacterAnimation player_Anim;
    private Rigidbody mybody;
    public float walk_Speed     = 2f; 
    public float z_Speed        = 1.5f;
    public float rotation_Y     = -90;
    public float rotation_Speed = 15f;

    // Start is called before the first frame update
    void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayeralk();


    }
    private void FixedUpdate()
    {
        DetectMovement(); 


    }
    // for Detect player moveement when he press a,s,d,w or using Arrows
    void DetectMovement()
    {
        mybody.velocity = new Vector3(
           Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
           mybody.velocity.y,
           Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed)
            );
    }
    // for rotate player
    void RotatePlayer()
    {   // if it grater than zero that mean that palyer going to right side
        // Quaternion.Euler for rotate object around x y and z
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0) {
            transform.rotation = Quaternion.Euler(0f,rotation_Y,0f);
                
        }else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0) {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);

        }
    }
    // for Walking
    void AnimatePlayeralk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 ||
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0 )
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);

        }
    }

}
