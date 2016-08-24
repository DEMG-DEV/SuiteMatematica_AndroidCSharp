using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteMatematica_AndroidCSharp
{
    class Operaciones
    {
        private Random rnd = new Random();

        public int getRandom(int opc)
        {
            int num = 0;
            switch (opc)
            {
                case 1:
                    // numeros Max 10
                    //num = (int)(Math.random() * 9 + 2);
                    num = rnd.Next(0, 10);
                    break;
                case 2:
                    // numeros Max 100
                    //num = (int)(Math.random() * 100 + 2);
                    num = rnd.Next(0, 100);
                    break;
                case 3:
                    // numeros Max 1000
                    //num = (int)(Math.random() * 1000 + 2);
                    num = rnd.Next(0, 1000);
                    break;
            }
            return num;
        }

        public bool checar(int n1, int n2, int result, int opc)
        {
            bool resu = false;
            switch (opc)
            {
                case 1:
                    //chequeo para Suma
                    if ((n1 + n2) == result)
                    {
                        resu = true;
                    }
                    else
                    {
                        resu = false;
                    }
                    break;
                case 2:
                    //chequeo para Resta
                    if ((n1 - n2) == result)
                    {
                        resu = true;
                    }
                    else
                    {
                        resu = false;
                    }
                    break;
                case 3:
                    //chequeo para Multiplicacion
                    if ((n1 * n2) == result)
                    {
                        resu = true;
                    }
                    else
                    {
                        resu = false;
                    }
                    break;
                case 4:
                    //chequeo para Division
                    break;
            }
            return resu;
        }
    }
}
