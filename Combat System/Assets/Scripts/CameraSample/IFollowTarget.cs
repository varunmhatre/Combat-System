using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public interface IFollowTarget
{
    void Follow(Transform target);
}

