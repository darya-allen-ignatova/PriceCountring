//using System.Collections.Generic;
//using System.IO;
//using MetroFramework.Forms;

//namespace PriceCounting
//{
//    public partial class Base : MetroForm
//    {
//        private readonly string appDir = Directory.GetCurrentDirectory();
//        private readonly StreamWriter sw;
//        private readonly StreamReader sr;
//        public Base()
//        {
//            InitializeComponent();
//            FileStream fs = new FileStream(appDir + @"\Names.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
//            sw = new StreamWriter(fs);
//            sr = new StreamReader(fs);
//            var names = GetNames();
//            foreach (var s in names)
//            {
//                comboBox1.Items.Add(s);
//            }
//        }
//        private string[] GetNames()
//        {
//            List<string> names = new List<string>();
//            string line = sr.ReadLine();
//            if (line == null)
//            {
//                sw.WriteLine(@"D:\price.docx");
//                sw.WriteLine("А.Л.Игнатова");
//                textBox4.Text = @"D:\price.docx";
//                names.Add("А.Л.Игнатова");
//            }

//            else
//            {
//                textBox4.Text = line;
//                line = sr.ReadLine();
//                while (line != null)
//                {
//                    names.Add(line);
//                    line = sr.ReadLine();
//                }
//            }
//            names.Add("Другое");
//            return names.ToArray();
//        }

//        private void button1_Click(object sender, System.EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(textBox2.Text))
//            {
//                MsgBox msgBox = new MsgBox();
//                msgBox.label1.Text = "Ошибка. Введите другого исполнителя в поле ввода";
//                msgBox.Show();
//            }
//            else
//            {
//                sw.WriteLine(textBox2.Text);
//                comboBox1.Items.Add(textBox2.Text);
//                comboBox1.SelectedItem = textBox2.Text;
//            }
//        }


//        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            if(comboBox1.SelectedItem.ToString()=="Другое")
//            {
//                button1.Visible = true;
//                textBox2.Visible = true;
//                label3.Visible = true;
//            }
//            else
//            {
//                button1.Visible = false;
//                textBox2.Visible = false;
//                label3.Visible = false;
//            }
//        }

//        private void button2_Click(object sender, System.EventArgs e)
//        {
//            ProtocolModel pm = new ProtocolModel()
//            {
//                ProtocolNumber = textBox1.Text,
//                ProtocolDate = dateTimePicker1.Value,
//                Owner = comboBox1.SelectedItem.ToString(),
//                Rate = int.Parse(textBox3.Text),
//                FilePath = textBox4.Text
//            };
//            sw.Close();
//            sr.Close();
//            this.Hide();
//            new Current(pm, this).Show();
//        }
//    }
//}
