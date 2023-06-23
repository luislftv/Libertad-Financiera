using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platsAnimatorScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update

    public void fase1()
    {
        animator.Play("Armature_Plantav2|Fase01");
    }
    public void fase1Dead()
    {
        animator.Play("Armature_Plantav2|Fase01_Dead");
    }
    public void fase2()
    {
        animator.Play("Armature_Plantav2|Fase02");
    }
    public void fase2dead()
    {
        animator.Play("Armature_Plantav2|Fase02_Dead");
    }
    public void fase3()
    {
        animator.Play("Armature_Plantav2|Fase03");
    }
    public void fase3dead()
    {
        animator.Play("Armature_Plantav2|Fase03_Dead");
    }
    public void fase4()
    {
        animator.Play("Armature_Plantav2|Fase04");
    }
}
