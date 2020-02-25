
namespace SimpleFactory
{
    public class RubicsCubePuzzle
    {
        public string PuzzleName { get; private set; }
        public int Layers { get; private set; }
        public PlasticColor Color { get; private set; }
        public bool HasMagnets { get; private set; }
        public double CubeHeight { get; private set; }
        public bool CustomStickers { get; private set; }

        public RubicsCubePuzzle(string puzzleName, int layers, PlasticColor plasticColor, bool hasMagnets, double height, bool customStickers)
        {
            PuzzleName = puzzleName;
            Layers = layers;
            Color = plasticColor;
            HasMagnets = hasMagnets;
            CubeHeight = height;
            CustomStickers = customStickers;
        }

        public override string ToString()
        {
            return $"{PuzzleName}|Layers = {Layers}|Color = {Color.ToString()}" +
                $"|HasMagnets? {HasMagnets}|Height = {CubeHeight}|Stickers {CustomStickers}";
        }
    }
}
