﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Animaciones : MonoBehaviour
{
    private bool personajeInvertido = false;
    private string estadoActual;
    Animator torsoAnimator, cabezaAnimator;
    Jugador_Visor jugador_Visor;
    Move_RB2D move_RB2D;
    
    void Awake()
    {
        move_RB2D = GetComponent<Move_RB2D>();
        torsoAnimator = gameObject.transform.Find("TorsoGFX").GetComponent<Animator>();
        cabezaAnimator = gameObject.transform.Find("Cabeza").transform.Find("CabezaGFX").GetComponent<Animator>();
        estadoActual = IDLE;
        jugador_Visor = gameObject.transform.Find("Cabeza").transform.Find("CabezaGFX").transform.Find("Visor").GetComponent<Jugador_Visor>();
    }

    public void Update()
    {
        ControlDeAnimaciones(move_RB2D.velocityVector);
    }

    

    private void ControlDeAnimaciones(Vector3 vectorDeMovimiento)
    {
        if(transform.localScale.x == -1)personajeInvertido = true;
        else personajeInvertido = false;

        
        if(vectorDeMovimiento != new Vector3(0, 0, transform.position.z) && !personajeInvertido)
        {
           if(vectorDeMovimiento.x >= 0) CambiarEstadoAnimacion(MOVING);
           else CambiarEstadoAnimacion(MOVING_ATRAS);
        }
        else if(vectorDeMovimiento != new Vector3(0, 0, transform.position.z) && personajeInvertido)
        {
            if(vectorDeMovimiento.x < 0) CambiarEstadoAnimacion(MOVING);
            else CambiarEstadoAnimacion(MOVING_ATRAS);
        }
        else
        {
            CambiarEstadoAnimacion(IDLE);
        }
    }

    public void ActivarDesactivarVisor()
    {
        if(jugador_Visor.estadoActual == "ON")jugador_Visor.ActivarDesactivarVisor("OFF");
        else if(jugador_Visor.estadoActual == "OFF") jugador_Visor.ActivarDesactivarVisor("ON");
    }

    private void CambiarEstadoAnimacion(string nuevoEstado)
    {
        if(estadoActual == nuevoEstado) return;

        torsoAnimator.Play(nuevoEstado);
        cabezaAnimator.Play(nuevoEstado);
        
        estadoActual = nuevoEstado;
    }

    

    private const string IDLE = "IDLE";
    private const string MOVING = "MOVING";
    private const string MOVING_ATRAS = "MOVING_ATRAS";
}
