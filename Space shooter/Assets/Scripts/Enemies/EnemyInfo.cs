using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class EnemyInfo 
{
 public Transform enemyPrefab;
 public int numberOfEnemy;
 public Vector3 formationOffset;
 public WayPath flyPath;
 public float speed;
 public float nextWaveDelay;
}
