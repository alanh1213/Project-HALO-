﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Jugador_Cabeza : MonoBehaviour
{
    
    public void ApuntarAlMouse()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        Quaternion rotacion = Quaternion.Euler(aimDirection);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if(angle < 30 && angle > -30)
        {
            transform.eulerAngles = new Vector3 (0, 0, angle);
        }
        
    }

    public void ResetearPosicion()
    {
        transform.eulerAngles = new Vector3(0,0,0);
    }
}
