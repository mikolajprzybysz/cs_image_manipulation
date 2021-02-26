using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageManipulation
{
    public partial class Custom : Form
    {
        private Hashtable controlsHashTable;
        private int[,] filter;
        private Form parent;
        private int factor;
        private int offset;
        public Custom(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            controlsHashTable = new Hashtable();
            foreach (Control c in this.Controls)
            {
                controlsHashTable.Add(c.Name, c);
            }
            filter = new int[5,5];
            String control = "textBox";
            for (int i = 1; i < 26; i++)
            {
                getTextBox(String.Concat(control, i)).Text = "0";
            }
            factorBox.Text = "1";
            offsetBox.Text = "0";
            
            
        }

        private TextBox getTextBox(String name)
        {
            return controlsHashTable[name] as TextBox;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void updateFactor(object sender, EventArgs e)
        {
            String control = "textBox";
            int number = 0;
            int factor = 0;
            for (int i = 1; i < 26; i++)
            {
                TextBox temp =getTextBox(String.Concat(control, i));
                if (int.TryParse(temp.Text,out number))
                    factor += number;
            }
            factorBox.Text = factor.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String control = "textBox";
            int l = -1;
            for (int i = 1; i < 26; i++)
            {
                if( 1==i%5) l++;
                filter[l,(i-1)%5] = int.Parse(getTextBox(String.Concat(control,i)).Text);                
            }
            factor = int.Parse(factorBox.Text);
            offset = int.Parse(offsetBox.Text);
            ((Form1)this.Owner).customFilter(filter, factor, offset);
            //parent.customFilter(filter, factor, offset);
            this.Close();
        }
    }
}
