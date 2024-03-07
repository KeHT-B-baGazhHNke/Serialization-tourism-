using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Serialization_tourism_
{
    public partial class Form1 : Form
    {
        Tour Bezenchuk = new Tour();
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            toolStripTextBox1.Text = String.Empty;
            toolStripTextBox2.Text = String.Empty;
            toolStripTextBox3.Text = String.Empty;
            toolStripTextBox4.Text = String.Empty;
            toolStripTextBox5.Text = String.Empty;

            toolStripTextBox1.Enabled = false;
            toolStripTextBox2.Enabled = false;
            toolStripTextBox3.Enabled = false;
            toolStripTextBox4.Enabled = false;
            toolStripTextBox5.Enabled = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.Text)
            {
                case "Безенчук":
                    toolStripTextBox1.Enabled = true;
                    toolStripTextBox2.Enabled = true;
                    toolStripTextBox3.Enabled = true;
                    toolStripTextBox4.Enabled = true;
                    toolStripTextBox5.Enabled = true;
                    break;
                default:
                    ClearAll();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (treeView1.SelectedNode.Text)
            {
                case "Безенчук":
                    Tours tours = DeserializeXML();
                    toolStripTextBox1.Text = tours.TourList[0].Name;
                    toolStripTextBox2.Text = tours.TourList[0].Cost;
                    toolStripTextBox3.Text = tours.TourList[0].Time;
                    toolStripTextBox4.Text = tours.TourList[0].Guide;
                    toolStripTextBox5.Text = tours.TourList[0].Transport;
                    break;
                default:
                    break;
            }
        }

        private void EditClass()
        {
            switch (treeView1.SelectedNode.Text)
            {
                case "Безенчук":
                    Bezenchuk.Name = toolStripTextBox1.Text;
                    Bezenchuk.Cost = toolStripTextBox2.Text;
                    Bezenchuk.Time = toolStripTextBox3.Text;
                    Bezenchuk.Guide = toolStripTextBox4.Text;
                    Bezenchuk.Transport = toolStripTextBox5.Text;
                    break;
                default:
                    break;
            }
        }

        private Tours DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Tours));

            using (FileStream fs = new FileStream("Tours.xml", FileMode.OpenOrCreate))
            {
                return (Tours)xml.Deserialize(fs);
            }
        }

        private void SerializeXML(Tours tours)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Tours));
            using (FileStream fs = new FileStream("Tours.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, tours);
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            EditClass();
            Tours tours = new Tours();
            tours.TourList.Add(Bezenchuk);
            SerializeXML(tours);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
