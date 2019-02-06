using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInteractable : MonoBehaviour
{
    protected Material previousMat = null;
    protected Vector3 interactorHitPosition = Vector3.zero;
    protected bool selected = false;
    public Animator anim;
    public float lookAtTime = 2.0f;
    private float lookAtCounter = 0.0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (selected) {
            print(lookAtCounter);
            lookAtCounter += Time.deltaTime;
            print(lookAtCounter);
            if (lookAtCounter > lookAtTime)
            {
                anim.SetBool("seen", true);
                lookAtCounter = 0.0f;
            }
        } else {
            lookAtCounter = 0.0f;
            anim.SetBool("seen", false);
        }
    }
    // Start is called before the first frame update
    public virtual void OnSelectEnter()
    {
        var meshRenderer = this.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            previousMat = meshRenderer.material;
            meshRenderer.material = selectedMat;
        }
        selected = true;
    }

    public virtual void OnSelectExit()
    {
        var meshRenderer = this.GetComponent<MeshRenderer>();
        if (meshRenderer != null && previousMat != null)
        {
            meshRenderer.material = previousMat;
        }
        selected = false;
    }


    public virtual void InteractorPosition(Vector3 position)
    {
        interactorHitPosition = position;
    }

    public virtual void OnInteract()
    {
        return;
    }

    public Material selectedMat = null;
}
