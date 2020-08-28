using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo.Audio_sistem;
using Prototipo.Draw_sistem;
using Prototipo.Fisic_sistem;
using Prototipo.Object_sistem;

namespace Prototipo.Scene
{
    public class Menu_Scene : Escena
    {
        Camara camara_Menu;
             
        public Menu_Scene()
        {
            camara_Menu = new Camara(new Vector2(200, 200), 1, 0);


          

        }

    }
}
