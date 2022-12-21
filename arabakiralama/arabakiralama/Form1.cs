using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arabakiralama
{
    public partial class Form1 : Form
    {

        static Arabalar arabalar;
        static KiralikBilgiler kiralikBilgiler;

        static int kiralikAracSayisi = 0;

        public Form1()
        {
            InitializeComponent();

            arabalar = new Arabalar();
            kiralikBilgiler = new KiralikBilgiler();

            dataGridView1.DataSource = kiralikBilgiler.gridGetir();

            foreach (KiralikBilgi bilgi in kiralikBilgiler.bilgiler) {
                kiralikAracSayisi++;

                comboBox3.Items.Add(bilgi.getAraba().getModel());
            }

            label19.Text = kiralikAracSayisi + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tcNo = textBox3.Text;

            if (!tcNo.Equals(""))
            {
                string ad = textBox1.Text;

                if (!ad.Equals(""))
                {
                    string soyad = textBox2.Text;

                    if (!soyad.Equals(""))
                    {
                        if (radioButton1.Checked || radioButton2.Checked)
                        {
                            string cinsiyet = radioButton1.Checked ? "Erkek" : "Kadın";

                            string telNo = textBox4.Text;

                            if (!telNo.Equals(""))
                            {
                                if (comboBox1.SelectedItem != null)
                                {
                                    string sehir = comboBox1.GetItemText(comboBox1.SelectedItem);

                                    if (comboBox2.SelectedItem != null)
                                    {
                                        string arabaModel = comboBox2.GetItemText(comboBox2.SelectedItem);

                                        DateTime baslangicTarih = dateTimePicker2.Value;
                                        DateTime bitisTarih = dateTimePicker3.Value;

                                        Araba araba = arabalar.getAraba(arabaModel);

                                        if (araba != null)
                                        {
                                            KiralikBilgi kiralikBilgi = new KiralikBilgi(kiralikBilgiler.bilgiler.Count, tcNo, ad, soyad, cinsiyet, telNo, sehir, araba, baslangicTarih, bitisTarih);

                                            kiralikBilgiler.ekle(kiralikBilgi);

                                            dataGridView1.DataSource = kiralikBilgiler.gridGetir();

                                            kiralikAracSayisi++;

                                            label19.Text = kiralikAracSayisi + "";

                                            comboBox3.Items.Add(araba.getModel());

                                            listBox1.Items.Add("Araç Kiralama, " + araba.getModel() + ", " + baslangicTarih.ToString() + "-" + bitisTarih);

                                            MessageBox.Show("Araç başarıyla kiralandı!", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Araba bulunamadı.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Araba seçmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Şehir seçmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Telefon numarası girmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cinsiyet seçmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Soyad girmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ad girmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("TC. Kimlik numarası girmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Araba araba = arabalar.getAraba(comboBox2.GetItemText(comboBox2.SelectedItem));

            if (araba != null)
            {
                label16.Text = araba.isManuel() ? "Manuel" : "Otomatik";
                label14.Text = araba.getUcret();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null) {
                string model = comboBox3.GetItemText(comboBox3.SelectedItem);

                Araba araba = arabalar.getAraba(model);

                if (araba != null) {
                    kiralikBilgiler.sil(araba);

                    dataGridView1.DataSource = kiralikBilgiler.gridGetir();

                    kiralikAracSayisi--;

                    label19.Text = kiralikAracSayisi + "";

                    comboBox3.Items.Remove(model);

                    listBox1.Items.Add("Araç Kira Iptali, " + araba.getModel());

                    MessageBox.Show("Araç kiralaması iptal edildi!", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Araba bulunamadı.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else {
                MessageBox.Show("Araba seçmelisiniz.", "Araba Kiralama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
