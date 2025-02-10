using System.Text.RegularExpressions;

namespace ColorPicker;

public partial class MainContentPage : ContentPage
{
    private static MainContentPage? instance;
    private static ColorManager colorManager = new ColorManager();
    private static Random random = new Random();

    public static MainContentPage GetInstance()
    {
        return instance!;
    }

    public static Label GetHexLabel()
    {
        return GetInstance().HexLabel;
    }

    public static Slider GetRedSlider()
    {
        return GetInstance().RedValue;
    }
    public static Slider GetBlueSlider()
    {
        return GetInstance().BlueValue;
    }

    public static Slider GetGreenSlider()
    {
        return GetInstance().GreenValue;
    }

    public static void SetBackgroundColor(Color newColor)
    {
        GetInstance().BackgroundColor = newColor;
    }

    public MainContentPage()
    {
        InitializeComponent();
        instance = this;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        Color newColor = colorManager.GetDefaultColor();

        colorManager.SetAllColors(newColor);
        colorManager.SetSliderValues(newColor);
    }

    private void ColorSlider_Changed(object sender, ValueChangedEventArgs e)
    {
        Color newColor = colorManager.GetSliderValues();

        colorManager.SetThumbColors(newColor);
        colorManager.SetHexLabel(newColor);
        colorManager.SetBackgroundColor(newColor);
    }

    private void RandomizeButton_Clicked(object sender, EventArgs e)
    {
        colorManager.Randomize(random);
    }

    private void ResetButton_Clicked(object sender, EventArgs e)
    {
        colorManager.SetAllColors(colorManager.GetDefaultColor());
        colorManager.SetSliderValues(colorManager.GetDefaultColor());
    }

    private void AnyButton_Pressed(object sender, EventArgs e)
    {
        ((Button)sender).BackgroundColor = new Color(50, 50, 50);
    }

    private void AnyButton_Released(object sender, EventArgs e)
    {
        ((Button)sender).BackgroundColor = new Color(0, 0, 0);
    }

    private void HexLabel_Clicked(object sender, TappedEventArgs e)
    {
        Clipboard.Default.SetTextAsync(colorManager.GetSliderValues().ToHex());
        DisplayAlert("Skopiowane!", "Pomyœlne skopiowane!", "OK");
    }

    private void HexInput_TextChanged(object sender, TextChangedEventArgs e)
    {
        string value = e.NewTextValue;

        if(Regex.Matches(value, "\\#([A-F]|[a-f]|[0-9]){6}").Count > 0 && value.Length == 7)
        {
            Color newColor = Color.FromArgb(value);

            colorManager.SetAllColors(newColor);
            colorManager.SetSliderValues(newColor);
        }
    }
}