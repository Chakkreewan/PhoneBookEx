using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        DataSet1 data = new DataSet1(); 
        DataTable table;
        public Form1()
        {
            InitializeComponent(); 
            table = data.Tables[ "รายชื่อ"];   
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            StreamReader reading = File.OpenText(@"D:\Project\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\Contact.txt"); 
            
                MessageBox.Show(reading.ReadToEnd());   //อ่านค่าไฟล์ทั้งหมด
            
        }

        public void button2_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;     //ตัวแปร String ให้แสดงเป็นตัวอักษรที่ textBox1
            String telephone = textBox2.Text;   //ตัวแปร String ให้แสดงเป็นตัวเลขที่ textBox2 
            DataRow row = table.NewRow();  //DataRow รับค่าจาก row
            row["User"] = user;   //row เก็บข้อมูลของ User
            row["Telephone"] = telephone;  //row เก็บข้อมูลของ Telephone
            table.Rows.Add(row);  //รับ row เข้ามาแสดงผล 

            using (StreamWriter writer = new StreamWriter(@"D:\Project\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\Contact.txt", true)) //รับไฟล์ค่าเข้ามา ถ้ามันเป็นจริงให้มาแสดงที่ texeBox1
            {
                writer.WriteLine(textBox1.Text); 
            }
            using (StreamWriter writer = new StreamWriter(@"D:\Project\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\Contact.txt", true)) //รับไฟล์ค่าเข้ามา ถ้ามันเป็นจริงให้มาแสดงที่ texeBox2
            {
                writer.WriteLine(textBox2.Text);
            }
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย"); 
            textBox1.Text = "";  
            textBox2.Text = ""; 

        }

      public void button4_Click(object sender, EventArgs e)
        {
           
            StreamReader reading = File.OpenText(@"D:\Project\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\Contact.txt");
            string str;  //กำหนอข้อความหรือตัวเลข
            while ((str = reading.ReadLine()) != null)  
            {
                if (str.Contains(textBox3.Text))
                {
                    label3.Text = reading.ReadLine();  //ค้นหาข้อมูลที่เราบันทึกไว้ให้ไฟล์ 
                }
            }
            textBox3.Text = "";  //อ่านค่าไฟล์ ให้ค้นหาตาม textbox3
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();  //ปุ่มกด Close
        }
    }
}
