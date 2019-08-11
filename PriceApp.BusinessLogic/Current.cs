//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using Microsoft.Office.Interop;
//using System.IO;
//using System.Text;
//using System.Linq;

//namespace PriceCounting
//{
//    public partial class Current : MetroFramework.Forms.MetroForm
//    {
//        private readonly ProtocolModel protocolModel;
//        private Base baseC;
//        private int current = -1;
//        private List<Participant> participants;
//        private Microsoft.Office.Interop.Word.Application app = null;
//        private Microsoft.Office.Interop.Word.Document doc = null;

//        public Current()
//        {
//            participants = new List<Participant>();
//            InitializeComponent();
//        }
//        public Current(ProtocolModel protocolModel, Base baseC)
//        {
//            this.protocolModel = protocolModel;
//            this.baseC = baseC;
//            participants = new List<Participant>();
//            InitializeComponent();
//        }

//        private void textBox2_TextChanged(object sender, System.EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(textBox2.Text) || int.Parse(textBox2.Text) == 0)
//            {
//                label3.Visible = false;
//                textBox3.Visible = false;
//            }
//            else
//            {
//                label3.Visible = true;
//                textBox3.Visible = true;
//            }
//        }

//        private void textBox4_TextChanged(object sender, System.EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(textBox4.Text) || int.Parse(textBox4.Text) == 0)
//            {
//                label5.Visible = false;
//                textBox5.Visible = false;
//            }
//            else
//            {
//                label5.Visible = true;
//                textBox5.Visible = true;
//            }
//        }

//        private void button1_Click(object sender, System.EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
//            {
//                MsgBox msgBox = new MsgBox();
//                msgBox.label1.Text = "Ошибка. Все поля должны быть заполнены";
//                msgBox.Show();
//                return;
//            }

//            if ((string.IsNullOrWhiteSpace(textBox8.Text) && int.Parse(string.IsNullOrWhiteSpace(textBox2.Text) ? "0" : textBox2.Text) + int.Parse(string.IsNullOrWhiteSpace(textBox4.Text) ? "0" : textBox4.Text) != 100)
//                || (string.IsNullOrWhiteSpace(textBox4.Text) && int.Parse(string.IsNullOrWhiteSpace(textBox2.Text) ? "0" : textBox2.Text) + int.Parse(string.IsNullOrWhiteSpace(textBox8.Text) ? "0" : textBox8.Text) != 100))
//            {
//                MsgBox msgBox = new MsgBox();
//                msgBox.label1.Text = "Ошибка. Предоплата и отсрочка должны составлять 100% в сумме.";
//                msgBox.Show();
//                return;
//            }
//            current++;
//            try
//            {
//                participants.Add(new Participant()
//                {
//                    Name = textBox1.Text,
//                    Price = decimal.Parse(textBox6.Text),
//                    Prepayment = int.Parse(string.IsNullOrWhiteSpace(textBox2.Text) ? "0" : textBox2.Text),
//                    PrepaymentDays = string.IsNullOrWhiteSpace(textBox3.Text) ? (int?)null : int.Parse(textBox3.Text),
//                    Postponement = int.Parse(string.IsNullOrWhiteSpace(textBox4.Text) ? "0" : textBox4.Text),
//                    PostponementDays = string.IsNullOrWhiteSpace(textBox5.Text) ? (int?)null : int.Parse(textBox5.Text),
//                    IsChecked = checkBox1.Checked,
//                    Prepayment_2 = int.Parse(string.IsNullOrWhiteSpace(textBox8.Text) ? "0" : textBox8.Text),
//                    PrepaymentDays_2 = string.IsNullOrWhiteSpace(textBox7.Text) ? (int?)null : int.Parse(textBox7.Text),
//                });
//                listBox1.Items.Add(participants[current].Name);
//            }
//            catch
//            {
//                MsgBox msgBox = new MsgBox();
//                msgBox.label1.Text = "Ошибка. Все поля должны быть корректно заполнены.";
//                msgBox.Show();
//            }
//            textBox1.Text = null;
//            textBox2.Text = null;
//            textBox3.Text = null;
//            textBox4.Text = null;
//            textBox5.Text = null;
//            textBox6.Text = null;
//            textBox7.Text = null;
//            textBox8.Text = null;

//        }

//        protected override void OnClosed(EventArgs e)
//        {
//            //if (doc != null)
//            //{
//            //    doc.Close();
//            //}
//            baseC.Close();
//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                int index = listBox1.SelectedIndex;
//                participants.RemoveAt(index);
//                listBox1.Items.Clear();
//                foreach (var part in participants)
//                {
//                    listBox1.Items.Add(part.Name);
//                }
//                current--;
//            }
//            catch
//            {
//                MsgBox msgBox = new MsgBox();
//                msgBox.label1.Text = "Ошибка. Нет элементов для удаления";
//                msgBox.Show();
//            }
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {

//            try
//            {
//                app = new Microsoft.Office.Interop.Word.Application();
//                object fileName = protocolModel.FilePath;
//                var file = File.Create(fileName.ToString());
//                file.Close();
//                doc = app.Documents.Open(ref fileName);
//                var range = doc.Range();
//                range.Text += $"Приложение к протоколу {protocolModel.ProtocolNumber} от {protocolModel.ProtocolDate.ToString("dd.MM.yyyy")}\n";
//                string staticInfo = $@"Цр = Цз±(Цз*Q*K)/(365*100),													
//Цз - цена предложения;
//Q - ставка рефинансирования НБ РБ, действующая на момент оценки предложений;
//К - количество дней отсрочки (либо дней поставки после проведения предоплаты);
//± -   + (плюс) - предоплата, – (минус) - отсрочка платежа.
//Ставка рефинансирования - {protocolModel.Rate}%

//Pасчет ценовой оценки предложений участников.
//                                      ";
//                CalculatingPrice();
//                StringBuilder[] participantsInfo = new StringBuilder[participants.Count];
//                for (int i = 0; i < participants.Count; i++)
//                {
//                    participantsInfo[i] = new StringBuilder($@"Участник {participants[i].Name}
//Цр =");
//                    if ((participants[i].PostponementDays ?? 0) != 0)
//                    {
//                        participantsInfo[i].Append($"+{participants[i].Price}*{participants[i].Postponement*(decimal)0.01}-({ participants[i].Price}*{participants[i].Prepayment*(decimal)0.01}*{ protocolModel.Rate}*{participants[i].PostponementDays})/(365*100)");

//                    }

//                    if ((participants[i].PrepaymentDays_2 ?? 0) != 0)
//                    {
//                        participantsInfo[i].Append($" +{participants[i].Price}*{participants[i].Prepayment_2 * (decimal)0.01}+({participants[i].Price}*{participants[i].Prepayment_2 * (decimal)0.01}*{protocolModel.Rate}*{participants[i].PrepaymentDays_2})/(365*100)");
//                    }

//                    if ((participants[i].PrepaymentDays ?? 0) != 0)
//                    {
//                        participantsInfo[i].Append($" +{participants[i].Price}*{participants[i].Prepayment*(decimal)0.01}+({participants[i].Price}*{participants[i].Prepayment*(decimal)0.01}*{protocolModel.Rate}*{participants[i].PrepaymentDays})/(365*100)");
//                    }

//                    participantsInfo[i].Append(String.Format(" ={0:f2}", participants[i].ResultPrice));
//                }
//                AddPlace();
//                for (int i = 1; i <= participants.Count; i++)
//                {
//                    participantsInfo.Where(j => j.ToString().Contains(participants.Where(m => m.Place.Contains($"{i}")).FirstOrDefault().Name)).FirstOrDefault().Append(participants.Where(k => k.Place.Contains($"{i}")).FirstOrDefault().Place);
//                }
//                range.Text += staticInfo;
//                foreach(var part in participantsInfo)
//                {
//                    range.Text += part.ToString() + "\n";
//                }
//                range.Text += "\n\n";
//                range.Text += $"Ответственный исполнитель: {protocolModel.Owner}";
//                doc.TextEncoding = Microsoft.Office.Core.MsoEncoding.msoEncodingCyrillic;
//                range.Font.Name = "New Times Roman";
//                range.Font.Size = 14;
//                range.Select();
//                doc.Save();
//                MsgBox msgBox = new MsgBox();
//                msgBox.label1.Text = "Файл успешно создан";
//                msgBox.Show();
//            }
//            catch(Exception ex)
//            {
//                if (doc != null)
//                {
//                    Console.WriteLine(ex);
//                    doc.Close();
//                }
//                MsgBox msgBox = new MsgBox();
//                msgBox.label1.Text = "Произошла неизвестная ошибкаю Попробуйте еще раз";
//                msgBox.Show();
//            }
//        }

//        private void CalculatingPrice()
//        {
//            foreach (var part in participants)
//            {
//                part.ResultPrice = 0;
//                if (part.Prepayment != 0)
//                {
//                    part.ResultPrice += part.Price*part.Prepayment*(decimal)0.01;
//                    part.ResultPrice += ((part.Price * part.Prepayment * (decimal)0.01 * protocolModel.Rate * part.PrepaymentDays ?? 0) / (365 * 100));
//                }

//                if (part.IsChecked)
//                {
//                    part.ResultPrice += part.Price * part.Prepayment_2 * (decimal)0.01;
//                    part.ResultPrice += ((part.Price * part.Prepayment_2 * (decimal)0.01 * protocolModel.Rate * part.PrepaymentDays_2 ?? 0) / (365 * 100));
//                }

//                if (part.Postponement != 0)
//                {
//                    part.ResultPrice += part.Price * part.Postponement * (decimal)0.01;
//                    part.ResultPrice -= ((part.Price * part.Postponement * (decimal)0.01 * protocolModel.Rate * part.PostponementDays ?? 0) / (365 * 100));
//                }
//            }
//        }
//        private void AddPlace()
//        {
//            int i = 0;
//            participants.Sort();
//            foreach (var part in participants)
//            {
//                part.Place = $" ({++i} место)";
//            }
//        }

//        private void checkBox1_CheckedChanged(object sender, EventArgs e)
//        {
//            if (checkBox1.Checked)
//            {
//                label8.Visible  = true;
//                textBox8.Visible = true;

//                textBox4.Visible = false;
//                label4.Visible = false;

//                textBox4.Text = null;
//                textBox5.Text = null;
//            }
//            else
//            {

//                label8.Visible = false;
//                textBox8.Visible = false;

//                textBox4.Visible = true;
//                label4.Visible = true;

//                textBox7.Text = null;
//                textBox8.Text = null;
//            }
//        }

//        private void textBox8_TextChanged(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(textBox8.Text) || int.Parse(textBox8.Text) == 0)
//            {
//                label6.Visible = false;
//                textBox7.Visible = false;
//            }
//            else
//            {
//                label6.Visible = true;
//                textBox7.Visible = true;
//            }
//        }
//    }
//}
