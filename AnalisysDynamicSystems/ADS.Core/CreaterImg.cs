using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace ADS.Core;

public class CreaterImg
{
    public string Create(Color[,] colorsPixels, string NameImage = null)
    {
        if (colorsPixels == null) throw new Exception("Not matrix");

        NameImage = NameImage ?? $"img_{DateTime.Now.ToString("dd_MM_yyyy_mm_ss")}.png";

        using Image<Rgba32> image = new(colorsPixels.GetLength(0), colorsPixels.GetLength(1));
        image.ProcessPixelRows(accessor =>
        {
            for (int y = 0; y < accessor.Height; y++)
            {
                Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                for (int x = 0; x < pixelRow.Length; x++)
                {
                    ref Rgba32 pixel = ref pixelRow[x];
                    if (pixel.A == 0)
                        pixel = colorsPixels[x, y];
                }
            }
        });

        image.Save(NameImage);

        return NameImage;
    }

    public string GetBase64(Color[,] colorsPixels, string NameImage = null)
        => Convert.ToBase64String(File.ReadAllBytes(Create(colorsPixels, NameImage)));
}
