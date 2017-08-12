﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HeroMovementController : MovementController
{
    public bool seekLocation;
    public Vector2 locationTarget;

    /// <summary>
    /// Gets or sets the location target of the hero.
    /// </summary>
    public Vector2 location
    {
        get
        {
            if (!seekLocation) return Vector2.zero;
            return locationTarget;
        }

        set
        {
            seekLocation = true;
            locationTarget = value;
        }
    }

    protected override void Start()
    {
        locationTarget = transform.position;
        character = GetComponent<GameCharacterController>();
    }

    /// <summary>
    /// Generates movement behaviour to seek a location, or to seek a target if not seeking
    /// a location, or does nothing if the hero has neither a location target not a character
    /// target.
    /// </summary>
    protected override void GenerateSeekBehaviour()
    {
        // Location targets have a higher move priority than character targets.
        if (seekLocation)
        {
            // Check if hero has reached location.
            if (transform.position.SqrDistance(locationTarget) < GameManager.GameSettings.Constants.Range.SeekLocationSqr)
            {
                seekLocation = false;
                character.state = CharacterState.Idle;
                // Fall through to check for character target.
            }
            else // Otherwise attempt to walk to location.
            {
                movementBehaviour = new WalkMovementBehaviour(
                    movementBehaviour, gameObject, locationTarget, GameManager.GameSettings.Constants.Range.SeekLocation);
                character.state = CharacterState.Walk;
            }
        }

        // Check for character target
        base.GenerateSeekBehaviour();
    }
}

