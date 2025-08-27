using System;
using System.Collections.Generic;
public enum CellState { jewel, robot, free, obstacle }

class Cell
{
    public CellState state;
    public char color;
    public Jewel? LayingJewel;
    public int x, y;

    public Cell(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.state = CellState.free;
        this.color = ' ';
        this.LayingJewel = null;
    }

    public char ShowColor()
    {
        return color;
    }
    
    public CellState ShowState()
    {
        return state;
    }

}