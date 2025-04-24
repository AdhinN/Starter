using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;

public class MindControlReceiver : MonoBehaviour
{
    private CharacterMindControl _mindControl;

    void Awake()
    {
        _mindControl = GetComponent<CharacterMindControl>();
    }

    public void TriggerMindControl(GameObject player)
    {
        if (player.CompareTag("Player") && _mindControl != null)
        {
            _mindControl.ApplyMindControl();
        }
    }
}