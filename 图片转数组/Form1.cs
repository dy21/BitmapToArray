using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图片转数组
{
    public partial class Form1 : Form
    {
        private Bitmap pic;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];
                string tempfile = files[0];
                //Copy file from external application
                    //foreach (string srcfile in files)
                    //{
                    //textBox1.Text = textBox1.Text + srcfile;
                    
                   
                    //}

                pic = new Bitmap(tempfile);
                Image img = Image.FromHbitmap(pic.GetHbitmap());
                pictureBox1.Image = img;
                textBox1.Text = bitmapToArray(pic);

            }
            catch (Exception e1) 
            {

                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
        

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            pictureBox1_DragEnter(sender, e);
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox1_DragDrop(sender, e);
        }

        private string bitmapToArray(Bitmap bmp)
        {
            string outStr = "";
            int x, y,i;
            for (y = 0; y < bmp.Height; y++)
            {                
                for (x = 0; x < bmp.Width; )
                {
                    outStr += "B";

                    for (i = 0; i < 8; i++, x++)
                    {
                        outStr += bmp.GetPixel(x, y).R>0 ? "0":"1";
                    }
                    outStr += ",";
                }
                outStr += "\n";
            }
            return outStr;  
        }
    }
}