using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuadCubeAnimationBehaviour : MonoBehaviour
{
    public bool AnimTrigger;
    public Vector3 MovementDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!AnimTrigger)
	    {
	        return;
	    }

        Animate();
	}

    public virtual void Animate()
    {
        var position = gameObject.transform.position;
        position += MovementDirection * Time.deltaTime;
        gameObject.transform.position = position;
    }
}
