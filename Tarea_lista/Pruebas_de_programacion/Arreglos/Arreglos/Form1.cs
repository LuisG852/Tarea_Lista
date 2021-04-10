using Arreglos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arreglos
{
    public partial class Form1 : Form
    {
        private string[] ArregloNotas;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonArreglo_Click(object sender, EventArgs e)
        {
            int[] arreglo = new int[5];
            arreglo[0] = 10;
            arreglo[1] = 8;
            arreglo[2] = 16;
            arreglo[3] = 33; 
            arreglo[4] = 1;

            ClsArreglos ObjetoArreglo = new ClsArreglos(arreglo);
            int[] resultado = ObjetoArreglo.metodoB();   

            foreach (int r in resultado)
            {
                listBoxResultado.Items.Add(r);
            }



        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            ClsArchivo ar = new ClsArchivo();
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Selecciona tu archivo plano";
            ofd.InitialDirectory = @"C:\Users\Wicho\Downloads";
            ofd.Filter = "Archivo plano (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var archivo = ofd.FileName;
                string resultado = ar.LeerTodoArhivo(archivo);
                ArregloNotas = ar.LeerArchivo(archivo);
                textBoxResultado.Text = resultado;
            }
        }

        private void buttonNames_Click(object sender, EventArgs e)
        {
            string[] stu = ArregloNotas;
            string f;
            for (int ll = 1; ll <= stu.Length; ll++)
            {
                for (int rr = 0; rr < stu.Length - 1; rr++)
                {
                    if (stu[rr].CompareTo(stu[rr + 1]) > 0)
                    {
                        f = stu[rr];
                        stu[rr] = stu[rr + 1];
                        stu[rr + 1] = f;
                    }
                }
            }
            foreach (string po in ArregloNotas)
            {
                string[] datosUnitarios = po.Split(',');
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                listBoxResultado.Items.Add(po);
            }
           
                
            }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string so in ArregloNotas)
            {
                string[] datosUnitarios = so.Split(',');
                listBoxResultado.Items.Add($"{datosUnitarios[0]} nota: {datosUnitarios[4]}");
            }
        }
    }
    }

