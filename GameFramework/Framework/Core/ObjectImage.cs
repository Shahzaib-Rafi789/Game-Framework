using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Framework.Movement;
using Framework.FireFolder;
using Framework.CollisionFolder;

namespace Framework.Core
{
    public class ObjectImage
    {
        string imageName;
        Image img;

        public ObjectImage(string imageName, Image img)
        {
            this.ImageName = imageName;
            this.Img = img;
        }

        public string ImageName { get => imageName; set => imageName = value; }
        public Image Img { get => img; set => img = value; }
    }
}
