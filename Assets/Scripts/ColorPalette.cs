using UnityEngine;
using System;

[System.Serializable]
public class ColorPaletteClass
{
    public string upRight;
    public string upLeft;
    public string downRight;
    public string downLeft;

    public ColorPaletteClass(
        string upRight,
        string upLeft,
        string downRight,
        string downLeft
    )
    {
        this.upRight = upRight;
        this.upLeft = upLeft;
        this.downRight = downRight;
        this.downLeft = downLeft;
    }

    public ColorPaletteClass()
    {
        this.upRight = "Green";
        this.upLeft = "Red";
        this.downRight = "Blue";
        this.downLeft = "Purple";
    }

    public ColorPaletteClass splitUp()
    {
        ColorPaletteClass ret = new ColorPaletteClass("", "", this.downRight, this.downLeft);

        this.downRight = "";
        this.downLeft = "";
        return ret;
    }

    public ColorPaletteClass splitDown()
    {
        ColorPaletteClass ret = new ColorPaletteClass(this.upRight, this.upLeft, "", "");

        this.upRight = "";
        this.upLeft = "";
        return ret;
    }

    public ColorPaletteClass splitRight()
    {
        ColorPaletteClass ret = new ColorPaletteClass("", this.upLeft, "", this.downLeft);

        this.upLeft = "";
        this.downLeft = "";
        return ret;
    }

    public ColorPaletteClass splitLeft()
    {
        ColorPaletteClass ret = new ColorPaletteClass(this.upRight, "", this.downRight, "");

        this.upRight = "";
        this.downRight = "";
        return ret;
    }

    public void fusePalette(ColorPaletteClass other)
    {
        if (this.upRight != "") this.upRight = other.upRight;
        if (this.upLeft != "") this.upLeft = other.upLeft;
        if (this.downRight != "") this.downRight = other.downRight;
        if (this.downLeft != "") this.downLeft = other.downLeft;
    }
}

public class ColorPalette : MonoBehaviour
{
    public ColorPaletteClass p;

    public string[] getColors()
    {
        string[] allColors = {
            this.p.upRight,
            this.p.upLeft,
            this.p.downRight,
            this.p.downLeft,
        };

        return Array.FindAll(allColors, str => str != "");
    }
}
