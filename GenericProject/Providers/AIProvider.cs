using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace GenericProject.Providers
{
    public class AIProvider
    {
        private readonly TesseractEngine _tesseractEngine;
        private bool _disposed = false;

        public AIProvider()
        {
            _tesseractEngine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
        }

        public string GetTextFromImage(string imagePath)
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
