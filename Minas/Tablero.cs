using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minas
{
    class Tablero
    {
        private Casilla[,] casillas;

        private int fils;
        private int cols;

        public Tablero(int f, int c)
        {
            this.fils = f+2;
            this.cols = c+2;
            casillas = new Casilla[fils, cols];
            for (int i=0; i<fils; i++)
                for(int j=0; j<cols; j++)
                    this.casillas[i,j] = new Casilla();

            initTablero();
         }

        private void initTablero()
        {
            Random rnd = new Random();
            for (int f = 1; f < this.fils - 1; f++){
                for (int c = 1; c < this.cols - 1; c++){                    
                    int valor = rnd.Next(100);
                    if (valor < 15)
                    { /// BOMBA
                        this.casillas[f, c].ponBomba();
                        sumaUnoAlrededor(f, c);
                    }
                }
            }
        }
            
       public void updateTablero(System.Windows.Forms.Button[] buttons)
        {
       	int index = 0;
           for (int f = 1; f < this.fils - 1; f++){
                for(int c =1; c<this.cols-1; c++) {
	       			if(!this.casillas[f, c].estaTapada()){
	       				buttons[index].Text = this.casillas[f, c].ToString();
	       				buttons[index].Enabled = false;
	       			}else{
	       				buttons[index].Text = " ";
	       			}
       			index++;
                }
            }
        }

        private void sumaUnoAlrededor(int f, int c)
        {
            for (int i = (f - 1); i <= (f + 1); i++)
                for (int j = (c - 1); j <= (c + 1); j++)
                    this.casillas[i, j].sumaUno();
        }


        public void visualiza()
        {
            for (int f = 1; f < this.fils - 1; f++)
            {
                for(int c =1; c<this.cols-1; c++) 
                {
                    Console.Write(this.casillas[f, c]);
                }
                Console.WriteLine();
            }
        }

        public bool levanta(int f, int c)
        {
        	try{
        	
            this.casillas[f, c].levanta();
            if (this.casillas[f, c].hayBomba())
                return true;

            if (this.casillas[f,c].getValor() == 0)
            { /// levanta rodean // marcar border con 2
                for (int i = (f - 1); i <= (f + 1); i++)
                    for (int j = (c - 1); j <= (c + 1); j++)
                        if (this.casillas[i, j].estaTapada())
                            this.levanta(i, j);
            }

            return false;
        	}catch(IndexOutOfRangeException e){
        		return false;
        	}
        }
    }
}
