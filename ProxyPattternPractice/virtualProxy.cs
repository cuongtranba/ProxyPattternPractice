using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattternPractice
{
    public interface Image
    {
        void DisplayImage();
    }

    /// <summary>
    /// on system A
    /// </summary>
    public class RealImage : Image
    {
        private string FileName;

        public RealImage(string fileName)
        {
            FileName = fileName;
            LoadFileFromDisk();
        }

        /// <summary>
        /// Load image from disk
        /// </summary>
        private void LoadFileFromDisk()
        {
            Console.WriteLine($"Loading {FileName} ");
        }

        public void DisplayImage()
        {
            Console.WriteLine($"Displaing {FileName}");
        }
    }

    public class ProxyImage : Image
    {
        private RealImage image = null;
        private string fileName;
        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void DisplayImage()
        {
            if (image == null)
            {
                image=new RealImage(fileName);
            }
            image.DisplayImage();
        }
    }
}
