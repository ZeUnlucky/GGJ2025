
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public float GameSeconds = 60.0f;
    [SerializeField] public GameObject particleSystemObject;
}
