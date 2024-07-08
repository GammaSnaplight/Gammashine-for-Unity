using UnityEngine;

public static class FXRainbowlight
{
     // R > +B > -R > +G > -B > +R > -G > *loop*
    public static Color32 FXUpdate(Color32 color, byte velocity, byte saturation)
    {
        byte limit = (byte)(0 + saturation);

        if (color.r <= limit)
        {
            color.b += velocity;
        }
        else
        {
            color.r -= velocity;

            if (color.r >= limit)
            {
                color.g += velocity;
            }
            else
            {
                color.b -= velocity;

                if (color.g < limit)
                {
                    color.r += velocity;
                }
                else
                {
                    color.g -= velocity;
                }
            }
        }

        return color;
    }
}
