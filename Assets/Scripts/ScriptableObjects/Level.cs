using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "SaveThePlanet/Level", order = 0)]
public class Level : ScriptableObject
{
    public int index;
    public string Name;
    public GameObject PlanetPrefab;
    public GameObject MeteorPrefab;
}
