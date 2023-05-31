using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerNeve : MonoBehaviour
{
   [SerializeField] Animator animator;
    // Start is called before the first frame update
   public void OnPointerClickXR()
    {
        animator.Play("Nevecon|Action_Open_NeveconDoor_RconDoor_R");
        
    }
     public void OnPointerExitXR()
    {
    
        animator.Play("Armature_Nevecon|Action_Close_NeveconDoor_R");
    }
}

