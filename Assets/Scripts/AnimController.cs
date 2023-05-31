using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
   public void OnPointerClickXR()
    {
        animator.Play("Armature_Armario|Action_Open_ClosetDoor_R");
    }
     public void OnPointerExitXR()
    {
        animator.Play("Armature_Armario|Action_Close_ClosetDoor_R");
    }

}
