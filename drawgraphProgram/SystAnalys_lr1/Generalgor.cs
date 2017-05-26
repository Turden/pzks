using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SystAnalys_lr1
{
    public partial class Generalgor : Form
    {
        
        public Generalgor()
        {            
            InitializeComponent();                    
        }

        public int minheftv; // мин вес вершины
        public int maxheftv; // макс вес вершины
        public int amountv; // кол. вершин 
        public double ze;      // связность графа
        public int minhefte; // мин вес дуги
        public int maxhefte; // макс вес дуги
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            minheftv = int.Parse(textBox1.Text);
            maxheftv = int.Parse(textBox2.Text);
            amountv = int.Parse(textBox3.Text);
            ze = double.Parse(textBox4.Text);
            minhefte = int.Parse(textBox5.Text);
            maxhefte = int.Parse(textBox6.Text);
            this.Close();  
        }
    }
}
