using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace GenericProject.Providers
{
    public static class AIProvider
    {
        private static readonly TesseractEngine _tesseractEngine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);

        public static string GetTextFromImage(string imagePath)
        {
            string text;

            using (var image = Pix.LoadFromFile(imagePath))
            {
                using (var page = _tesseractEngine.Process(image))
                {
                    text = page.GetText();
                }
            }
            return text;
        }
    }
}
