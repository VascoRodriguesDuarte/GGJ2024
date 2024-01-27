using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    public void PublicDeathMoment()
    {
        DeathMoment();
    }

    private void DeathMoment()
    {
        playerManager.PublicDeathPing();
    }
}
