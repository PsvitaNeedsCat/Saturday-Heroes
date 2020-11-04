using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for hitbox & hurtbox

public class CombatVolume : MonoBehaviour
{
    public enum EColliderShape
    {
        cube,
        sphere
    }

    public enum EColliderState
    {
        closed,     // Can't collide (disabled)
        open,       // Can collide (enabled)
        colliding   // Currently colliding
    }

    public enum EDamageType
    {
        player,
        enemy
    }

    public EDamageType m_damageType;
}
