using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EDamageType
{
    player,
    enemy
}

// Parent class for hitbox & hurtbox
public class CombatVolume : MonoBehaviour
{
    public enum EColliderShape
    {
        cube,
        sphere,
        capsule
    }

    public enum EColliderState
    {
        closed,     // Can't collide (disabled)
        open,       // Can collide (enabled)
        colliding   // Currently colliding
    }

    public EDamageType m_damageType;
}
