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
        Filmes filme;

        Filmes editafilme = new Filmes();

        Dictionary<string, List<Filmes>> dic = new Dictionary<string, List<Filmes>>();
        ListViewItem nome = new ListViewItem();

        string pega;
        string peganome;

        
        public Form1()
        {
            InitializeComponent();
        }

        //rotina de cadastro de filmes
        public void cadastrafilme(string nome, string genero, string data, string local)
        {
            filme = new Filmes();
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

       
       private void lv1cad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tx1cad.Text = lv1cad.SelectedItems[0].Text;
            dt1cad.Value.ToShortDateString().ToString();
            rt1cad.Text = lv1cad.SelectedItems[0].SubItems[2].Text;
            cb1cad.Text = lv1cad.SelectedItems[0].Group.Header;
            pega = cb1cad.SelectedItem.ToString();
            peganome = tx1cad.Text;
                        
        }

        private void btCad_Click_1(object sender, EventArgs e)
        {
            string nome = tx1cad.Text;
            string genero = cb1cad.SelectedItem.ToString();
            string data = dt1cad.Value.ToShortDateString().ToString();
            string local = rt1cad.Text;

            cadastrafilme(nome, genero, data, local);
            cadastralistview();
            cadastranodic(genero);
        }

        private void bteditcadastro_Click(object sender, EventArgs e)
        {
                       
            cadastralistview();
            
            lv1cad.SelectedItems[0].Remove();

            if(dic.ContainsKey(pega))
            {
                foreach (List<Filmes> i in dic.Values)
                {
                    foreach(Filmes editafilme in i)
                    {
                        if (editafilme.nome == tx1cad.Text && editafilme.local == rt1cad.Text)
                        {
                            editafilme.nome = tx1cad.Text;
                            editafilme.genero = cb1cad.SelectedItem.ToString();
                            editafilme.data = dt1cad.Value.ToString();
                            editafilme.local = rt1cad.Text;
                        }
                    }
                }
            }                 

        }

        private void btexcluircadastro_Click(object sender, EventArgs e)
        {
            lv1cad.SelectedItems[0].Remove();
        }

        private void btpesquisa_Click(object sender, EventArgs e)
        {

            foreach (List<Filmes> i in dic.Values)
            {
                foreach (Filmes j in i)
                {
                    lbpesq.Items.Add(j.nome);
                    lbpesq.Items.Add(j.genero);
                    lbpesq.Items.Add(j.data);
                    lbpesq.Items.Add(j.local);
                    
                }
            }
        }

        private void btexcluipesquisa_Click(object sender, EventArgs e)
        {
            lbpesq.Items.Clear();
        }

       

        
    }
}
