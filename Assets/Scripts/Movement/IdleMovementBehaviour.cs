﻿using System;
using UnityEngine;

/// <summary>
/// The root behaviour of all movement behaviours.
/// </summary>
public class IdleMovementBehaviour : AbstractMovementBehaviour
{
    /// <summary>
    /// The steering vector desired by this movement behaviour.
    /// </summary>
    /// <returns>The optimal steering vector to accomplish this movement behaviour.</returns>
    public override Vector2 Steering()
    {
        // When a character is idle they don't move.
        return Vector2.zero;
    }

    /// <summary>
    /// The velocity desired by this movement behaviour.
    /// </summary>
    /// <returns>The optimal velocity vector to accomplish this movement behaviour.</returns>
    public override Vector2 CalculateDesiredVelocity()
    {
        // When a character is idle they don't move.
        return Vector2.zero;
    }
}
