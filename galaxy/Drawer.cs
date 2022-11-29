using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy
{
    public class Drawer
    {
        private readonly PictureBox _picture;
        private readonly Form1 _form;
        private Bitmap _bitmap;
        public Drawer(PictureBox picture, Form1 form)
        {
            _picture = picture;
            _form = form;
            _bitmap = new Bitmap(_picture.Width, _picture.Height);
        }
    }
}
