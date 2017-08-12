﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
[System.Serializable]
public class AbilityManager : WorldEntityManager
{
    public override int MaxUnlocked { get { return GameManager.GameSettings.Max.Abilities.Unlocked; } }
    public override int MaxAssigned { get { return GameManager.GameSettings.Max.Abilities.Assigned + 1; } }
    public override string ResourcePath { get { return GameManager.GameSettings.Path.Abilities; } }

    public AbilityManager(SaveGame save = null) : base(save) { }

    public override void Load(SaveGame save)
    {
        AddAssigned("Defend");
        if (save != null)
        {
            foreach (var ability in save.unlockedAbilities) AddUnlocked(ability);
            foreach (var ability in save.assignedAbilities) AddAssigned(ability);
        }

        foreach (var ability in GameManager.GameSettings.CharacterStart.Abilities)
        {
            if (!unlocked.Contains(ability)) AddUnlocked(ability);
        }
    }

    public override void Save(ref SaveGame save)
    {
        save.unlockedAbilities = Unlocked;
        var assignedWithoutDefend = new List<string>(Assigned);
        assignedWithoutDefend.Remove("Defend");
        save.assignedAbilities = assignedWithoutDefend;
    }
}
