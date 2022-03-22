using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cpfValidator
{
    public partial class cpfValidator : Form
    {
        public cpfValidator()
        {
            InitializeComponent();
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void cpfTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcularDigitos();
        }

        private void cpfTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            calcularDigitos();
        }

        private void calcularDigitos()
        {
            int[] listaDosNumeros = new int[9];
            int digit;
            int[] resultadosDaMultiplicacao = new int[9];
            int somaDosResultados = 0;
            int primeiroDigitoCasoRestoDaDivisaoSejaMenorQueDois = 0;
            int primeiroDigitoCasoContrario = 0;
            int segundoDigitoCasoRestoDaDivisaoSejaMenorQueDois;
            int segundoDigitoCasoContrario;
            if (cpfTextBox.Text.Length == 9)
            {
                for (int i = 0; i < cpfTextBox.TextLength; i++)
                {
                    digit = Convert.ToInt32(cpfTextBox.Text[i].ToString());
                    listaDosNumeros[i] = digit;
                }

                int cont = 10;
                for (int i = 0; i < 9; i++)
                {
                    resultadosDaMultiplicacao[i] = listaDosNumeros[i] * cont;
                    cont--;
                }

                for (int i = 0; i < 9; i++)
                {
                    somaDosResultados += resultadosDaMultiplicacao[i];
                }

                int[] listaDosNumerosComUmDigito = new int[10];
                int restoDaDivisao = somaDosResultados % 11;
                if (restoDaDivisao < 2)
                {
                    primeiroDigitoCasoRestoDaDivisaoSejaMenorQueDois = 0;
                    listaDosNumerosComUmDigito[9] = primeiroDigitoCasoRestoDaDivisaoSejaMenorQueDois;
                }
                else
                {
                    primeiroDigitoCasoContrario = 11 - restoDaDivisao;
                    listaDosNumerosComUmDigito[9] = primeiroDigitoCasoContrario;
                }

                digit = 0;
                for (int i = 0; i < cpfTextBox.TextLength; i++)
                {
                    digit = Convert.ToInt32(cpfTextBox.Text[i].ToString());
                    listaDosNumerosComUmDigito[i] = digit;
                }

                int[] resultadosDaMultiplicacaoUmDigito = new int[10];
                cont = 11;
                for (int i = 0; i < 10; i++)
                {
                    resultadosDaMultiplicacaoUmDigito[i] = listaDosNumerosComUmDigito[i] * cont;
                    cont--;
                }

                somaDosResultados = 0;
                for (int i = 0; i < 10; i++)
                {
                    somaDosResultados += resultadosDaMultiplicacaoUmDigito[i];
                }

                int[] listaDosNumerosComDoisDigitos = new int[11];
                restoDaDivisao = 0;
                restoDaDivisao = somaDosResultados % 11;
                if (restoDaDivisao < 2)
                {
                    segundoDigitoCasoRestoDaDivisaoSejaMenorQueDois = 0;
                    listaDosNumerosComDoisDigitos[10] = segundoDigitoCasoRestoDaDivisaoSejaMenorQueDois;
                    listaDosNumerosComDoisDigitos[9] = primeiroDigitoCasoRestoDaDivisaoSejaMenorQueDois;

                    int a = 0;
                    foreach (int i in listaDosNumerosComUmDigito)
                    {
                        listaDosNumerosComDoisDigitos[a] = i;
                        a++;
                    }
                    listaDosNumerosComDoisDigitos[10] = segundoDigitoCasoRestoDaDivisaoSejaMenorQueDois;

                    string cpfCompleto = "";
                    foreach (int i in listaDosNumerosComDoisDigitos)
                    {
                        cpfCompleto += i.ToString();
                    }

                    label1.Text = cpfCompleto;
                    label1.Enabled = true;
                }
                else
                {
                    segundoDigitoCasoContrario = 11 - restoDaDivisao;
                    listaDosNumerosComDoisDigitos[10] = segundoDigitoCasoContrario;
                    listaDosNumerosComDoisDigitos[9] = primeiroDigitoCasoContrario;

                    int a = 0;
                    foreach (int i in listaDosNumerosComUmDigito)
                    {
                        listaDosNumerosComDoisDigitos[a] = i;
                        a++;
                    }
                    listaDosNumerosComDoisDigitos[10] = segundoDigitoCasoContrario;

                    string cpfCompleto = "";
                    foreach (int i in listaDosNumerosComDoisDigitos)
                    {
                        cpfCompleto += i.ToString();
                    }

                    label1.Text = cpfCompleto;
                    label1.Enabled = true;
                }
            }
        }
    }
 }
