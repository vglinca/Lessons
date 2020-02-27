using System;

namespace SimpleFactory
{
    public class RubicsCubePuzzleFactory
    {
        public static RubicsCubePuzzle CreatePuzzle(string puzzleName, int layers = 3, PlasticColor color = PlasticColor.BLACK, 
            bool hasMagnets = false, double height = 55.7, bool customStickers = false)
        {
            //we can't create puzzle with less than 2 layers because it has no sense
            if(layers < 2)
            {
                throw new ArgumentOutOfRangeException($"Layers must be equal or greater than 2.\n");
            }
            var layersNumber = layers;
            var stickers = customStickers;

            //if puzzle is stickerless, than it should not have stickers thus customsStickers variable should be false
            //if PlasticColor is not stickerless than it sopposes that puzzle has stickers
            if(color == PlasticColor.STICKERLESS)
            {
                stickers = false;
            }
            return new RubicsCubePuzzle(puzzleName, layersNumber, color, hasMagnets, height, stickers);
        }
    }
}
