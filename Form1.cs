using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kantor
{
    public partial class Form1 : Form
    {
        List<money> valuta;
        public Form1()
        {
            InitializeComponent();
            valuta = new List<money>();
            valuta.Add(new money() { Name = "$", prodaj = 26.4, kypivla = 26.2 });
            valuta.Add(new money() { Name = "Є", prodaj = 32.2, kypivla = 31.9 });
            
            int startPoint = 20;
            int elemencount = 0;
            foreach (var item in valuta)
            {
                RadioButton m = new RadioButton();
                m.Text = item.Name;
                m.CheckedChanged += new EventHandler(m_CheckedChanged);
                m.Parent = panel1;
                m.Height = 20;
                int tmpoffser = startPoint + elemencount * (m.Height + 10);
                m.Location = new Point(20, tmpoffser);
                m.Name = "m" + item.Name;


                Label l = new Label();
                l.Text = item.prodaj.ToString();
                l.Location = new Point(120, tmpoffser);
                l.Parent = panel1;
                elemencount++;


                RadioButton a = new RadioButton();
                a.Text = item.Name;
                a.CheckedChanged += new EventHandler(a_CheckedChanged);
                a.Parent = panel1;
                a.Height = 20;
                int tmkoffser = startPoint + elemencount * (a.Height + 10);
                a.Location = new Point(20, tmkoffser);
                a.Name = "a" + item.Name;


                Label k = new Label();
                k.Text = item.kypivla.ToString();
                k.Location = new Point(120, tmkoffser);
                k.Parent = panel1;
                elemencount++;
            }
        }
            void m_CheckedChanged(object sender, EventArgs e)
            {
                RadioButton M = (RadioButton)sender;
                sumdouble l = double.Parse(dMoney.Text);
        
                Sum.Text = (l * valuta.Where(i => i.Name == M.Text).FirstOrDefault().prodaj).ToString();
            }
            void a_CheckedChanged(object sender, EventArgs e)
            {
                RadioButton A = (RadioButton)sender;
                double l = double.Parse(dMoney.Text);

                Sum.Text = (l * valuta.Where(i => i.Name == A.Text).FirstOrDefault().kypivla).ToString();
            }
        public class money
        {
            public string Name;
            public double prodaj;
            public double kypivla;

        }
    }
}

