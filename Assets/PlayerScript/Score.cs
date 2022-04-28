using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float ObjectBreakScore;
    float ObjectAllScore;
    float ObjectScore;
    float TimeScore;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjectBreakScore = Explosion.ObjectCount();
        ObjectAllScore = DestructableObjectController.ObjectAllCount();
        Debug.Log(ObjectBreakScore);
    }
}
