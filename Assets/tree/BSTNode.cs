using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSTNode<T>
{
    internal BSTNode<T> parent = null;
    internal BSTNode<T> Rightleaf = null;
    internal BSTNode<T> Leftleaf = null;
    public T value { set; get; } = default;

    internal bool visitCheck = false;
}
