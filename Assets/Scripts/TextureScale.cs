using UnityEngine;

public static class TextureScale
{
    public static void Bilinear(Texture2D tex, int newWidth, int newHeight)
    {
        Texture2D newTex = new Texture2D(newWidth, newHeight, tex.format, tex.mipmapCount > 1);
        float ratioX = 1.0f / ((float)newWidth / (tex.width - 1));
        float ratioY = 1.0f / ((float)newHeight / (tex.height - 1));
        for (int y = 0; y < newHeight; y++)
        {
            for (int x = 0; x < newWidth; x++)
            {
                float gx = x * ratioX;
                float gy = y * ratioY;
                int gxi = (int)gx;
                int gyi = (int)gy;
                newTex.SetPixel(x, y, Color.Lerp(
                    Color.Lerp(tex.GetPixel(gxi, gyi), tex.GetPixel(gxi + 1, gyi), gx - gxi),
                    Color.Lerp(tex.GetPixel(gxi, gyi + 1), tex.GetPixel(gxi + 1, gyi + 1), gx - gxi),
                    gy - gyi));
            }
        }
        newTex.Apply();
        tex.Reinitialize(newWidth, newHeight);
        tex.SetPixels(newTex.GetPixels());
        tex.Apply();
    }
}


