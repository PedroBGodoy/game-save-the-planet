using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private PlanetHealth planetHealth = null;

    public PlanetHealth PlanetHealth => planetHealth;
}
