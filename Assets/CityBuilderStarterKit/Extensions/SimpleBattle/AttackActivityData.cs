﻿using UnityEngine;
using System.Collections;

/**
 * An activity data which has an additional value for the strength of the city being attacked. 
 */ 
[System.Serializable]
public class AttackActivityData : ActivityData {
	public int strength;
}