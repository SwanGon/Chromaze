using UnityEngine;
using System;

public class ColorPalette : MonoBehaviour
{
    string upRight;
    string upLeft;
    string downRight;
    string downLeft;

    public ColorPalette(
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

    public ColorPalette()
    {
        this.upRight = "Green";
        this.upLeft = "Red";
        this.downRight = "Blue";
        this.downLeft = "Purple";
    }

    public ColorPalette splitUp()
    {
        ColorPalette ret = new ColorPalette("", "", this.downRight, this.downLeft);

        this.downRight = "";
        this.downLeft = "";
        return ret;
    }

    public ColorPalette splitDown()
    {
        ColorPalette ret = new ColorPalette(this.upRight, this.upLeft, "", "");

        this.upRight = "";
        this.upLeft = "";
        return ret;
    }

    public ColorPalette splitRight()
    {
        ColorPalette ret = new ColorPalette("", this.upLeft, "", this.downLeft);

        this.upLeft = "";
        this.downLeft = "";
        return ret;
    }

    public ColorPalette splitLeft()
    {
        ColorPalette ret = new ColorPalette(this.upRight, "", this.downRight, "");

        this.upRight = "";
        this.downRight = "";
        return ret;
    }

    public void fusePalette(ColorPalette other)
    {
        if (this.upRight != "") this.upRight = other.upRight;
        if (this.upLeft != "") this.upLeft = other.upLeft;
        if (this.downRight != "") this.downRight = other.downRight;
        if (this.downLeft != "") this.downLeft = other.downLeft;
    }

    public string[] getColors()
    {
        string[] allColors = {this.upRight, this.upLeft, this.downRight, this.downRight};

        return Array.FindAll(allColors, str => str != "");
    }
}
