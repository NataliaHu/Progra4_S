using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Objetos/Cartas")]
public class Cartas : ScriptableObject
{
    public string nombre;
    public Sprite imagen;
    public bool instancear;

    // Stats
    public int HP;
    public int STR;
    public int DEF;

    // Instancear
    public Transform creatura;

}
