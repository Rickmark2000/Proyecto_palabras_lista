using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_palabras_lista
{
    public class Palabra
    {
        private string palabra;
        private int id;
        private int nivel;

        public Palabra(string palabra, int id, int nivel)
        {
            this.palabra = palabra;
            this.id = id;
            this.nivel = nivel;
        }

        public string PalabrA { get => palabra; set => palabra = value; }
        public int Id { get => id; set => id = value; }
        public int Nivel { get => nivel; set => nivel = value; }
    }
}
