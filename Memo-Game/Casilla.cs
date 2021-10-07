using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Game
{
    class Casilla
    {
        private char letra;
       
        //1 para sin seleccionar, 2 para seleccionado y 3 para encontrado
        private int estado;

        public Casilla()
        {
            letra = '\0';
            estado = 1;
        }

        public Casilla(char letra, int estado)
        {
            this.letra = letra;
            this.estado = estado;
        }

        public char Letra
        {
            get { return letra; }
            set { letra = value; }
        }
        
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
