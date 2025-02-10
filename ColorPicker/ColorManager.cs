using System;

namespace ColorPicker
{
    internal class ColorManager
    {
        private Color defaultColor = new Color(
            (byte) 255,
            (byte) 255,
            (byte) 255
        );

        public Color GetSliderValues()
        {
            Color currentColor = Color.FromRgb(
                 MainContentPage.GetRedSlider().Value,
                 MainContentPage.GetGreenSlider().Value,
                 MainContentPage.GetBlueSlider().Value
            );

            return currentColor;
        }

        public Color GetDefaultColor()
        {
            return this.defaultColor;
        }

        public void SetSliderValues(Color newColor)
        {
            MainContentPage.GetRedSlider().Value = (double) newColor.Red;
            MainContentPage.GetGreenSlider().Value = (double) newColor.Green;
            MainContentPage.GetBlueSlider().Value = (double) newColor.Blue;
        }

        public void SetHexLabel(Color newColor)
        {
            MainContentPage.GetHexLabel().Text = newColor.ToHex();
            MainContentPage.GetHexLabel().TextColor = newColor;
        }

        public void SetThumbColors(Color newColor)
        {
            MainContentPage.GetRedSlider().ThumbColor = new Color(newColor.Red, 0, 0);
            MainContentPage.GetGreenSlider().ThumbColor = new Color(0, newColor.Green, 0);
            MainContentPage.GetBlueSlider().ThumbColor = new Color(0, 0, newColor.Blue);
        }

        public void SetBackgroundColor(Color newColor)
        {
            MainContentPage.SetBackgroundColor(newColor);
        }

        public void SetAllColors(Color newColor)
        {
            SetThumbColors(newColor);
            SetBackgroundColor(newColor);
            SetHexLabel(newColor);
        }

        public void Randomize(Random random)
        {
            Color newColor = new Color(
                random.Next(50, 255),
                random.Next(50, 255),
                random.Next(50, 255)
            );

            SetAllColors(newColor);
            SetSliderValues(newColor);
        }
    }
}
