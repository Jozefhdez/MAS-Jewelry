using System;
using System.Collections.Generic;

#pragma warning disable CS0649 // Field is never assigned to

class Robot
{
    public int X, Y;
    public char Color;
    public bool Carrying;
    public Jewel? CarryingJewel;

    public void Sense()
    {
        // TODO: check adjacent cells
    }

    public void Move()
    {
        // TODO: move logic
    }

    public void PickUp()
    {
        // TODO: pick jewel of own color
    }

    public void Drop()
    {
        // TODO: drop in target area
    }
}