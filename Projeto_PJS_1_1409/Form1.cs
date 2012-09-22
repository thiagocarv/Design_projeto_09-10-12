using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projeto_PJS_1_1409
{
    
    public partial class Form1 : Form
    {
        Filmes filme = new Filmes();
        Dictionary<string, List<Filmes>> dic = new Dictionary<string, List<Filmes>>();
        ListViewItem nome = new ListViewItem();

        public Form1()
        {
            InitializeComponent();
        }

        //rotina de cadastro de filmes
        public void cadastrafilme(string nome, string genero, string data, string local)
        {
            filme.nome = nome;
            filme.genero = genero;
            filme.data = data;
            filme.local = local;
        }

        //rotina no list view
        public void cadastralistview()
        {
            //ListViewItem nome = new ListViewItem();

            nome = new ListViewItem();
            nome.Text = tx1cad.Text;
            nome.Group = lv1cad.Groups[cb1cad.SelectedIndex];

            nome.SubItems.Add(dt1cad.Value.ToShortDateString().ToString());
            nome.SubItems.Add(rt1cad.Text);

            lv1cad.Items.Add(nome);
        }

        //rotina de cadastro no dicionario
        public void cadastranodic(string genero)
        {
            if (dic.ContainsKey(genero))
            {
               // dic[genero] = new List<Filmes>();
                dic[genero].Add(filme);
            }
            else
            {
                dic[genero] = new List<Filmes>();
                dic[genero].Add(filme);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string nome = tx1cad.Text;
            string genero = cb1cad.SelectedItem.ToString();
            string data = dt1cad.Value.ToShortDateString().ToString();
            string local = rt1cad.Text;

            cadastrafilme(nome, genero, data, local);
            cadastralistview();
            cadastranodic(genero);
            
                            
        }

        private void bt2cad_Click(object sender, EventArgs e)
        {
            string genero = cb1cad.SelectedItem.ToString();

            cadastralistview();
            cadastranodic(genero);
            lv1cad.SelectedItems[0].Remove();              
        }

        private void bt3pesq_Click(object sender, EventArgs e)
        {
            lb1pesq.Items.Clear();
        }

        private void bt3cad_Click(object sender, EventArgs e)
        {
            lv1cad.SelectedItems[0].Remove();
        }

        private void lv1cad_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lv1cad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tx1cad.Text = lv1cad.SelectedItems[0].Text;
            dt1cad.Value = DateTime.Now;
            rt1cad.Text = lv1cad.SelectedItems[0].SubItems[2].Text;
            cb1cad.Text = lv1cad.SelectedItems[0].Group.Header;
        }
    }
}
