using Programing_Language.factories;
using Programing_Language.model;
using Programing_Language.products.commands;
using Programing_Language.products.shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programing_Language
{
    public partial class Form1 : Form
    {
        private AseParser parser = new AseParser();
        private readonly object syncLock = new object();
        Bitmap outputBitmap = new Bitmap(700, 700);
        public static Creator factoryCreator = new ConcreteCreator();
        public static ArrayList shapes = new ArrayList();
        public static Point currentPoint = new Point(0, 0);
        public static Graphics graphics;
        public static Pen currentPen = new Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
            graphics = Graphics.FromImage(outputBitmap);
            Thread workerThread = new Thread(new ThreadStart(flashing));
            workerThread.Start();
        }

        private void runCommand(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                parser.clear();
                parser.parse(textBox1.Text);
                display();
            }
            else
            {
                MessageBox.Show("Please provide the command");
            }
        }

        private void clear(object sender, EventArgs e)
        {
            parser.clear();
            shapes.Clear();
            graphics.Clear(Color.LightGray);
            pictureBox1.Invalidate();
        }

        private void load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName); 
            }
        }

        private void save(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveFile(saveFileDialog1.FileName, richTextBox1.Text);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void saveFile(string filename, string Msg)
        {
            FileStream fParameter = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(Msg);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
        }

        private void syntax(object sender, EventArgs e)
        {
            parser.clear();
            parser.parse(richTextBox1.Text);
            ArrayList errors = parser.getErrors();
            String message = "There is no syntax error";
            if (errors.Count > 0)
            {
                message = "";
                foreach (Error error in errors)
                {
                    message += "Line No. " + error.getLine() + ": " + error.getMessage() + Environment.NewLine;
                }
            }
            MessageBox.Show(message);
        }

        private void display()
        {
            ArrayList errors = parser.getErrors();
            if (errors.Count > 0)
            {
                String message = "";
                foreach (Error error in errors)
                {
                    message += "Line No. " + error.getLine() + ": " + error.getMessage() + Environment.NewLine;
                }
                MessageBox.Show(message);
            }
            else
            {
                ArrayList commands = parser.getCommands();
                if (null == commands || commands.Count <= 0)
                {
                    MessageBox.Show("There is no command found");
                }
                else
                {
                    shapes.Clear();
                    foreach (Command command in commands)
                    {
                        command.execute();
                    }
                    RepaintShapes();
                }
            }
        }

        private void runProgram(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                parser.clear();
                parser.parse(richTextBox1.Text);
                display();
            }
            else
            {
                MessageBox.Show("Please provide the program");
            }
        }

        private void RepaintShapes()
        {
            lock (syncLock) {
                if (shapes.Count > 0)
                {
                    graphics.Clear(Color.LightGray);
                    pictureBox1.Invalidate();
                    foreach (AseShape shape in shapes)
                    {
                        shape.draw(graphics);
                    }
                    pictureBox1.Invalidate();
                }
            }
        }

        private void flashing()
        {
            while(true)
            {
                RepaintShapes();
                Thread.Sleep(500);
            }
        }

        private void paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(outputBitmap, 0, 0);
        }
    }
}
