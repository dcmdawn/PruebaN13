using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Ejercicio604
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string InputBox(string texto)
        {
            InputBoxDialog ib = new InputBoxDialog(); ib.FormPrompt = texto; ib.DefaultValue = "";
            ib.ShowDialog(); string s = ib.InputResponse; ib.Close(); return s;
        }

        ArrayList Base = new ArrayList();
        ArrayList Prim = new ArrayList();
        ArrayList Qprim = new ArrayList();

        void introducir(ArrayList lista)
        {
            int num;
            DialogResult massnum;
            do
            {
                num = int.Parse(InputBox("Escribe número de las lista"));
                lista.Add(num);
                massnum = MessageBox.Show("Quieres introducir otro valor?", "Número", MessageBoxButtons.YesNo);
                //Primero mensaje, luego titulo , y luego tipo de boton
            } while (massnum == DialogResult.Yes);
        }

        bool comprobarprimo(int num)
        {
            bool primo = true;
            int i = 2;
            if (num == 1)
            {
                primo = false;
            }
            else
            {
                while (i < num)
                {
                    if (num % i == 0)
                    {
                        primo = false;
                    }
                    i++;
                }
            }
            return primo;
        }

        void quitarprimos(ArrayList Base, ArrayList Qprim)
        {
            int i = 0;
            bool primo = true;
            while (i < Base.Count)
            {
                primo = false;
                primo = comprobarprimo((int)Base[i]);
                if (primo)
                {
                    Qprim.Add(Base[i]);
                    Base[i] = 0;
                }
                else
                {
                    Qprim.Add(0);
                }
                i++;
            }
        }

        void pillarprimos(ArrayList Base, ArrayList Prim)
        {
            int i = 0;
            bool primo;
            while (i < Base.Count)
            {
                primo = false;
                primo = comprobarprimo((int)Base[i]);
                if (primo == true)
                {
                    Prim.Add(Base[i]);
                }
                else
                {
                    Prim.Add(0);
                }
                i++;
            }
        }

        string mostrar(ArrayList lista)
        {
            string text = "Los valores son : ";
            for (int i = 0; i < lista.Count; i++)
                text = text + lista[i] + ", ";
            return text;
        }


        void limpiar(ArrayList lista)
        {
            lista.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar(Base);
            introducir(Base);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar(Prim);
            pillarprimos(Base, Prim);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar(Prim);
            quitarprimos(Base, Qprim);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ListaBase = mostrar(Base);
            string ListaPar = mostrar(Prim);
            string ListaImpar = mostrar(Qprim);

            MessageBox.Show("Las listas. " + "\n " + ListaBase + "\n " + ListaPar + "\n " + ListaImpar);
        }
    }
}
