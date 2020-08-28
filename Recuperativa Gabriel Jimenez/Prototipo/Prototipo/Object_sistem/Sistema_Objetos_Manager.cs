using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Object_sistem
{
    class Sistema_Objetos_Manager
    {
        static List<Sistema_Objetos> AllUTGameObjects = new List<Sistema_Objetos>();
        static List<Sistema_Objetos> DestroyedUTGameObjects = new List<Sistema_Objetos>();
        public static void Init()
        {
            foreach (Sistema_Objetos utg in AllUTGameObjects)
            {
                utg.Destroy();
            }
            AllUTGameObjects = new List<Sistema_Objetos>();
        }
        public static void DestruirObjeto(Sistema_Objetos utg)
        {
            utg.OnDestroy();
            DestroyedUTGameObjects.Add(utg);
        }
        public static void suscribirObjeto(Sistema_Objetos utg)
        {
            AllUTGameObjects.Add(utg);
        }
        public static void Update(GameTime gameTime)
        {
            //foreach (Sistema_Objetos utg in AllUTGameObjects)   //For each revisa por cada objeto, cada objeto por separado. For revisa todo.
            //{
            //    utg.Update(gameTime);
            //}
            for (int i = 0; i < AllUTGameObjects.Count; i++)
            {
                AllUTGameObjects[i].Update(gameTime);
            }

            //for (int i = 0; i < AllUTGameObjects.Count; i++)
            //{
            //    AllUTGameObjects.Remove(AllUTGameObjects[i]);
            //}

            foreach (Sistema_Objetos utg in DestroyedUTGameObjects)
            {
                AllUTGameObjects.Remove(utg);
            }



            DestroyedUTGameObjects = new List<Sistema_Objetos>();
        }

    }
}
