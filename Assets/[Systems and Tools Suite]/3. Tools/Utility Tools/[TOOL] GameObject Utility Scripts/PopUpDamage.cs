using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDamage : MonoBehaviour
{
    private float timer = 0;


    private void Update()
    {
        //timer += Time.deltaTime;
        //if (timer >= 1)
        //    Destroy(this.gameObject);

      Destroy(this.gameObject, 1f);
    }
}
