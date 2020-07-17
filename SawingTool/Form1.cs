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

namespace SawingTool {
    public partial class Form1 : Form {
        private List<List<string>> damegeDic = new List<List<string>>();
        private List<List<string>> damegeDic2 = new List<List<string>>();
        string dir = "./files/";

        public Form1() {
            InitializeComponent();

            dataGridView1.Columns.Add("column1", "ダメージ表");
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns.Add("column2", "概要");
            dataGridView1.Columns[1].Width = 430;


            List<string> damege1 = new List<string>();
            damege1.Add("通常,6,7,7,8,8,9,9");
            damege1.Add("かげん,3,4,4,4,4,5,5");
            damege1.Add("ほぐし,-3,-3,-3,-3,-4,-4,-4");
            damege1.Add("2倍,12,13,14,15,16,17,18");
            damege1.Add("3倍,18,20,21,23,24,26,27");
            damegeDic.Add(damege1);

            damege1 = new List<string>();
            damege1.Add("通常,12,13,14,15,16,17,18");
            damege1.Add("かげん,6,7,7,8,8,9,9");
            damege1.Add("ほぐし,-6,-6,-7,-7,-8,-8,-9");
            damege1.Add("2倍,24,26,28,30,32,34,36");
            damege1.Add("3倍,36,39,42,45,48,51,54");
            damegeDic.Add(damege1);

            damege1 = new List<string>();
            damege1.Add("通常,18,20,21,23,24,26,27");
            damege1.Add("かげん,9,11,11,12,12,14,14");
            damege1.Add("ほぐし,-9,-9,-10,-10,-12,-12,-13");
            damege1.Add("2倍,36,39,42,45,48,51,54");
            damege1.Add("3倍,54,59,63,68,72,77,81");
            damegeDic.Add(damege1);

            damege1 = new List<string>();
            damege1.Add("通常,24,26,28,30,32,34,36");
            damege1.Add("かげん,12,14,14,16,16,18,18");
            damege1.Add("ほぐし,-12,-12,-14,-14,-16,-16,-18");
            damege1.Add("2倍,48,52,56,60,64,68,72");
            damege1.Add("3倍,72,78,84,90,96,102,108");
            damegeDic.Add(damege1);

            for(int i = 0; i < damegeDic.Count; i++) {
                damege1 = damegeDic[i];
                List<string> damege2 = new List<string>();
                for (int j = 0; j < damege1.Count; j++) {
                    string[] values = damege1[j].Split(new char[] { ',' });
                    StringBuilder sb = new StringBuilder();
                    sb.Append(values[0]);
                    for(int k = 1; k < values.Length; k++) {
                        sb.Append("," + int.Parse(values[k]) * 2);
                    }
                    damege2.Add(sb.ToString());
                }
                damegeDic2.Add(damege2);
            }

            reloadFiles();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox18.Text.Length == 0) {
                MessageBox.Show("ファイル名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(dir + textBox18.Text + ".txt")) {
                if (MessageBox.Show("同名のファイルがあります。上書きしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }
            }

            List<string> paramList = new List<string>();
            try {
                paramList.Add(buildParam(checkBox1, textBox1));
                paramList.Add(buildParam(checkBox2, textBox2));
                paramList.Add(buildParam(checkBox3, textBox3));
                paramList.Add(buildParam(checkBox4, textBox4));
                paramList.Add(buildParam(checkBox5, textBox5));
                paramList.Add(buildParam(checkBox6, textBox6));
                paramList.Add(buildParam(checkBox7, textBox7));
                paramList.Add(buildParam(checkBox8, textBox8));
                paramList.Add(buildParam(checkBox9, textBox9));
                paramList.Add(textBox10.Text);

                File.WriteAllLines(dir + textBox18.Text + ".txt", paramList.ToArray());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reloadFiles();
        }

        private string buildParam(CheckBox checkbox, TextBox value) {
            string param = "";
            if (checkbox.Checked && (value.Text.Length == 0)) {
                throw new Exception("基準値を入力してください");
            }
            if (checkbox.Checked) {
                param += "1," + value.Text + ",";
            }
            else {
                param += "0,0,";
            }
            return param;
        }

        private void setParam(CheckBox checkbox, TextBox value, string param) {
            string[] parts = param.Split(new char[] { ',' });
            if (parts[0] == "1") {
                checkbox.Checked = true;
                value.Text = parts[1];
            }
            else {
                checkbox.Checked = false;
                value.Text = "";

            }
        }
        private void reloadFiles() {
            comboBox1.Items.Clear();
            string[] files = System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly);
            foreach (string key in files) {
                comboBox1.Items.Add(key.Replace(dir, "").Replace(".txt", ""));
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (!File.Exists(dir + comboBox1.SelectedItem + ".txt")) {
                MessageBox.Show("ファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] param = File.ReadAllLines(dir + comboBox1.SelectedItem + ".txt");
            setParam(checkBox1, textBox1, param[0]);
            setParam(checkBox2, textBox2, param[1]);
            setParam(checkBox3, textBox3, param[2]);
            setParam(checkBox4, textBox4, param[3]);
            setParam(checkBox5, textBox5, param[4]);
            setParam(checkBox6, textBox6, param[5]);
            setParam(checkBox7, textBox7, param[6]);
            setParam(checkBox8, textBox8, param[7]);
            setParam(checkBox9, textBox9, param[8]);

            if(param.Length > 9) {
                for(int i = 9; i < param.Length; i++ ) {
                    textBox10.Text += param[i] + "\r\n";
                }
            }

            textBox1_1.Text = "0";
            textBox2_1.Text = "0";
            textBox3_1.Text = "0";
            textBox4_1.Text = "0";
            textBox5_1.Text = "0";
            textBox6_1.Text = "0";
            textBox7_1.Text = "0";
            textBox8_1.Text = "0";
            textBox9_1.Text = "0";
        }

        private void textBox1_1_TextChanged(object sender, EventArgs e) {
            TextBox valueText = textBox1;
            Label remain = label1;
            if ((TextBox)sender == textBox1_1) {
                valueText = textBox1;
                remain = label1;
            }
            else if ((TextBox)sender == textBox2_1) {
                valueText = textBox2;
                remain = label2;
            }
            else if ((TextBox)sender == textBox3_1) {
                valueText = textBox3;
                remain = label3;
            }
            else if ((TextBox)sender == textBox4_1) {
                valueText = textBox4;
                remain = label4;
            }
            else if ((TextBox)sender == textBox5_1) {
                valueText = textBox5;
                remain = label5;
            }
            else if ((TextBox)sender == textBox6_1) {
                valueText = textBox6;
                remain = label6;
            }
            else if ((TextBox)sender == textBox7_1) {
                valueText = textBox7;
                remain = label7;
            }
            else if ((TextBox)sender == textBox8_1) {
                valueText = textBox8;
                remain = label8;
            }
            else if ((TextBox)sender == textBox9_1) {
                valueText = textBox9;
                remain = label9;
            }

            try {
                int value = int.Parse(((TextBox)sender).Text);
                int remainValue = int.Parse(valueText.Text) - value;
                remain.Text = (int.Parse(valueText.Text) - value).ToString();

                for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                    string[] parts = dataGridView1.Rows[i].Cells[0].Value.ToString().Split(new char[] { ',' });
                    int max = int.Parse(parts[parts.Length - 1]);
                    int min = int.Parse(parts[1]);

                    int zeroCount = 0;
                    int oneCount = 0;
                    for(int j = 1; j < parts.Length; j++) {
                        if(remainValue - int.Parse(parts[j]) == 0) {
                            zeroCount++;
                        }
                        if (remainValue - int.Parse(parts[j]) == 1) {
                            oneCount++;
                        }
                    }

                    if(max > 0) {
                        if (max <= remainValue && min * 2 >= remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                            dataGridView1.Rows[i].Cells[1].Value = " (会心で基準値確定)";
                        }
                        else if (max * 2 < remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Aqua;
                            dataGridView1.Rows[i].Cells[1].Value = " (会心でも届かず)";
                        }
                        else if (min > remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            dataGridView1.Rows[i].Cells[1].Value = " (会心以外は必ず突き抜ける)";
                        }
                        else if (max > remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Pink;
                            dataGridView1.Rows[i].Cells[1].Value = " (会心以外は突き抜ける可能性がある 誤差0の確率" + zeroCount + "/7 誤差1の確率" + +oneCount + "/7)";
                        }
                        else if (min * 2 < remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Pink;
                            dataGridView1.Rows[i].Cells[1].Value = " (偽会心、届かない可能性がある 誤差0の確率" + zeroCount + "/7 誤差1の確率" + +oneCount + "/7)";
                        }
                        else {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Purple;
                            dataGridView1.Rows[i].Cells[1].Value = " (誤差0の確率" + zeroCount + "/7 誤差1の確率" + +oneCount + "/7)";
                        }
                    }
                    else {
                        if (remainValue < 0 && max > remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Pink;
                            dataGridView1.Rows[i].Cells[1].Value = " (戻しすぎることはない 誤差0の確率" + zeroCount + "/7 誤差1の確率" + +oneCount + "/7)";
                        }
                        else if (remainValue < 0 && min < remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Pink;
                            dataGridView1.Rows[i].Cells[1].Value = " (必ず戻しすぎてしまう 誤差0の確率" + zeroCount + "/7 誤差1の確率" + +oneCount + "/7)";
                        }
                        else {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Purple;
                            dataGridView1.Rows[i].Cells[1].Value = " (誤差0の確率" + zeroCount + "/7 誤差1の確率" + +oneCount + "/7)";
                        }
                    }
                }
            }
            catch (Exception ex) {

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                dataGridView1.Rows.Clear();
                int temp = listBox1.SelectedIndex;
                List<string> list = null;
                if (checkBox10.Checked) {
                    list = damegeDic2[temp];
                }
                else {
                    list = damegeDic[temp];
                }

                for (int i = 0; i < list.Count; i++) {
                    dataGridView1.Rows.Add(list[i]);
                }
                dataGridView1.CurrentCell = null;
            }
            catch (Exception ex) {

            }
        }

        private void button3_Click(object sender, EventArgs e) {
            textBox1_1.Text = "0";
            textBox2_1.Text = "0";
            textBox3_1.Text = "0";
            textBox4_1.Text = "0";
            textBox5_1.Text = "0";
            textBox6_1.Text = "0";
            textBox7_1.Text = "0";
            textBox8_1.Text = "0";
            textBox9_1.Text = "0";
        }

        private void textBox1_1_Click(object sender, EventArgs e) {
            ((TextBox)sender).SelectAll();
        }
    }
}
