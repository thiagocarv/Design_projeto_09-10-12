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
     //   string peganome;

        
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

                      
        //rotina de preenchimento do list view
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

        public void editadic()
        {
            //rotina de edição do dicionário
            if (dic.ContainsKey(pega))
            {
                foreach (List<Filmes> i in dic.Values)
                {
                    foreach (Filmes k in i)
                    {
                        if (k.nome == editafilme.nome && k.local == editafilme.local)
                        {
                            k.nome = tx1cad.Text;
                            k.genero = cb1cad.SelectedItem.ToString();
                            k.data = dt1cad.Value.ToString();
                            k.local = rt1cad.Text;
                        }
                    }
                }
            }                 

        }

       
       private void lv1cad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tx1cad.Text = lv1cad.SelectedItems[0].Text;
            dt1cad.Value.ToShortDateString().ToString();
            rt1cad.Text = lv1cad.SelectedItems[0].SubItems[2].Text;
            cb1cad.Text = lv1cad.SelectedItems[0].Group.Header;
            
            editafilme.nome = tx1cad.Text;
            editafilme.genero = cb1cad.SelectedItem.ToString();
            editafilme.data = dt1cad.Value.ToString();
            editafilme.local = rt1cad.Text;
            
            pega = cb1cad.SelectedItem.ToString();
            //peganome = tx1cad.Text;
                        
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
            
            editadic();
            
        }

        private void btexcluircadastro_Click(object sender, EventArgs e)
        {
            lv1cad.SelectedItems[0].Remove();
        }

        private void btpesquisa_Click(object sender, EventArgs e)
        {
            lvpesq.Items.Clear();

            List<Filmes> listapesq = new List<Filmes>();
            

            foreach (List<Filmes> l in dic.Values)
                listapesq.AddRange(l);

            for (int k = 0; k < listapesq.Count; k++)
            {
                if (cb2pesq.SelectedIndex == 10)
                    break;
                else
                {
                    if (listapesq[k].genero == cb2pesq.SelectedItem.ToString())
                    {
                        listapesq.Remove(listapesq[k]);
                    }
                }

            }

            for (int k = 0; k < listapesq.Count; k++)
            {
                if (tb1pesq.Text != "")
                {
                    if (!listapesq[k].nome.Contains(tb1pesq.Text))
                    {
                        listapesq.Remove(listapesq[k]);
                    }
                }
            }

            for (int k = 0; k < listapesq.Count; k++)
            {
                if (rt1pesq.Text != "")
                {
                    if (listapesq[k].local != rt1pesq.Text)
                    {
                        listapesq.Remove(listapesq[k]);
                    }
                }
            }


            for (int k = 0; k < listapesq.Count; k++)
            {
                nome = new ListViewItem();
                nome.Text = listapesq[k].nome;
                nome.Group = lvpesq.Groups[listapesq[k].genero];

                nome.SubItems.Add(listapesq[k].data);
                nome.SubItems.Add(listapesq[k].local);

                lvpesq.Items.Add(nome);
            }

            listapesq.Clear();

        }
        

        private void btexcluipesquisa_Click(object sender, EventArgs e)
        {
            lvpesq.Items.Clear();
        }

       

        
    }
}
