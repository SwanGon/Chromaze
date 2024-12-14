public class ColorPalette
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

    public static (ColorPalette, ColorPalette) splitUp(ColorPalette c)
    {
        ColorPalette up = new ColorPalette(c.upRight, c.upLeft, "", "");
        ColorPalette down = new ColorPalette("", "", c.downRight, c.downLeft);

        return (up, down);
    }

    public static (ColorPalette, ColorPalette) splitDown(ColorPalette c)
    {
        var (up, down) = splitUp(c);

        return (down, up);
    }

    public static (ColorPalette, ColorPalette) splitRight(ColorPalette c)
    {
        ColorPalette right = new ColorPalette(c.upRight, "", c.downRight, "");
        ColorPalette left = new ColorPalette("", c.downLeft, "", c.downLeft);

        return (right, left);
    }

    public static (ColorPalette, ColorPalette) splitLeft(ColorPalette c)
    {
        var (right, left) = splitRight(c);

        return (left, right);
    }

    public void fusePalette(ColorPalette other)
    {
        if (this.upRight != "") this.upRight = other.upRight;
        if (this.upLeft != "") this.upLeft = other.upLeft;
        if (this.downRight != "") this.downRight = other.downRight;
        if (this.downLeft != "") this.downLeft = other.downLeft;
    }
}
