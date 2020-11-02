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
 
namespace WoodWorking {
    public partial class Form1 : Form {
        private Dictionary<string, List<string>> damegeDic = new Dictionary<string, List<string>>();

        string dir = "./files/";
        public Form1() {
            InitializeComponent();

            dataGridView1.Columns.Add("column1", "強さ");
            dataGridView1.Columns.Add("column2", "ダメージ値");
            dataGridView1.Columns.Add("column3", "会心確定範囲");
            dataGridView1.Columns.Add("column4", "会心最大値");
            dataGridView1.Columns.Add("column5", "概要");
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 500;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";

            List<string> damege1 = new List<string>();
            damege1.Add("昇竜(上),10,11,12,13,13,14,15");
            damege1.Add("通常,12,13,14,15,16,17,18");
            damege1.Add("昇竜(中),14,15,16,17,18,19,20");
            damege1.Add("昇竜(下),17,19,20,21,23,24,26");
            damege1.Add("2倍,24,26,28,30,32,34,36");
            damege1.Add("3倍,36,39,42,45,48,51,54");
            damege1.Add("カンナ,5,6,7,8");
            damegeDic.Add("順目,通常", damege1);

            damege1 = new List<string>();
            damege1.Add("昇竜(上),17,18,20,21,21,23,25");
            damege1.Add("通常,20,21,23,25,26,28,29");
            damege1.Add("昇竜(中),23,25,26,28,29,31,33");
            damege1.Add("昇竜(下),28,31,33,34,37,39,42");
            damege1.Add("2倍,39,42,45,49,52,55,58");
            damege1.Add("3倍,58,63,68,73,77,82,87");
            damege1.Add("カンナ,9,10,12,13");
            damegeDic.Add("順目,くさび", damege1);

            damege1 = new List<string>();
            damege1.Add("昇竜(上),5,6,6,7,7,7,8");
            damege1.Add("通常,6,7,7,8,8,9,9");
            damege1.Add("昇竜(中),7,8,8,9,9,10,10");
            damege1.Add("昇竜(下),9,10,10,11,12,12,13");
            damege1.Add("2倍,12,13,14,15,16,17,18");
            damege1.Add("3倍,18,20,21,23,24,26,27");
            damege1.Add("カンナ,3,3,4,4");
            damegeDic.Add("逆目,通常", damege1);

            damege1 = new List<string>();
            damege1.Add("昇竜(上),9,9,10,11,11,12,13");
            damege1.Add("通常,10,11,12,13,13,14,15");
            damege1.Add("昇竜(中),12,13,13,14,15,16,17");
            damege1.Add("昇竜(下),14,16,17,17,19,20,21");
            damege1.Add("2倍,20,21,23,25,26,28,29");
            damege1.Add("3倍,29,32,34,37,39,41,44");
            damege1.Add("カンナ,5,5,6,7");
            damegeDic.Add("逆目,くさび", damege1);

            reloadFiles();
            setDataGrid();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1_2.Checked) {
                checkBox1_2.Text = "くさび";
            }
            else {
                checkBox1_2.Text = "通常";
            }
            setDataGrid();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if(checkBox1_1.Checked) {
                checkBox1_1.Text = "逆目";
            }
            else {
                checkBox1_1.Text = "順目";
            }
            setDataGrid();
        }

        private void setDataGrid() {
            List<string> list = null;
            if (checkBox1_1.Checked && checkBox1_2.Checked) {
                list = damegeDic["逆目,くさび"];
            }
            else if (!checkBox1_1.Checked && checkBox1_2.Checked) {
                list = damegeDic["順目,くさび"];
            }
            else if (checkBox1_1.Checked && !checkBox1_2.Checked) {
                list = damegeDic["逆目,通常"];
            }
            else {
                list = damegeDic["順目,通常"];
            }

            try {
                dataGridView1.Rows.Clear();

                var list2 = GetLines(list);
                for (int i = 0; i < list2.Count; i++) {
                    dataGridView1.Rows.Add(list2[i]);
                }
                dataGridView1.CurrentCell = null;
            }
            catch (Exception ex) {

            }
        }

        private List<string[]> GetLines(List<string> list) {
            List<string[]> returnList = new List<string[]>();
            for (int i = 0; i < list.Count; i++) {
                string[] lineParts = list[i].Split(new char[] { ',' });
                string name = lineParts[0];
                string range = "";
                string safeRange = lineParts[lineParts.Length - 1] + "-" + (int.Parse(lineParts[1]) * 2).ToString();
                string maxNum = (int.Parse(lineParts[lineParts.Length - 1]) * 2).ToString();
                for (int j = 1; j < lineParts.Length; j++) {
                    if (range.Length != 0) {
                        range += ",";
                    }
                    range += lineParts[j];
                }
                if(checkBox1_3.Checked) {
                    range += "(+4～6)";
                }
                returnList.Add(new string[] { name, range, safeRange, maxNum, "" });
            }
            return returnList;
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
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            string[] files = System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly);
            int index = comboBox1.SelectedIndex;
            foreach (string key in files) {
                comboBox1.Items.Add(key.Replace(dir, "").Replace(".txt", ""));
            }
            if (index > 0) {
                comboBox1.SelectedIndex = index;
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

            if (param.Length > 9) {
                for (int i = 9; i < param.Length; i++) {
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
                    if(dataGridView1.Rows[i].Cells[1].Value != null) {
                        dataGridView1.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value.ToString().Replace("(+4～6)", "");
                        string[] parts = dataGridView1.Rows[i].Cells[1].Value.ToString().Split(new char[] { ',' });
                        int max = int.Parse(parts[parts.Length - 1]);
                        int min = int.Parse(parts[0]);

                        int zeroCount = 0;
                        int oneCount = 0;
                        List<int> appendList = new List<int>();
                        if(checkBox1_3.Checked) {
                            appendList.Add(4);
                            appendList.Add(5);
                            appendList.Add(6);
                            dataGridView1.Rows[i].Cells[1].Value += "(+4～6)";
                        }
                        else {
                            appendList.Add(0);
                        }
                        for (int j = 0; j < parts.Length; j++) {
                            for(int k = 0; k < appendList.Count; k++) {
                                if (remainValue - int.Parse(parts[j]) - appendList[k] == 0) {
                                    zeroCount++;
                                }
                                if (Math.Abs(remainValue - int.Parse(parts[j]) - appendList[k]) == 1) {
                                    oneCount++;
                                }
                            }
                        }

                        int totalCount = parts.Length * appendList.Count;

                        if (max > 0) {
                            if (max <= remainValue && min * 2 >= remainValue) {
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                                dataGridView1.Rows[i].Cells[4].Value = " 会心で基準値確定 誤差0の確率" + zeroCount + "/" + totalCount + " 誤差1の確率" + oneCount + "/" + totalCount;
                            }
                            else if (max * 2 < remainValue) {
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Aqua;
                                dataGridView1.Rows[i].Cells[4].Value = " 会心でも届かず";
                            }
                            else if (remainValue <= 0) {
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                dataGridView1.Rows[i].Cells[4].Value = " 必ず突き抜ける";
                            }
                            else if (min > remainValue) {
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                dataGridView1.Rows[i].Cells[4].Value = " 会心以外は必ず突き抜ける";
                            }
                            else if (max > remainValue) {
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Pink;
                                dataGridView1.Rows[i].Cells[4].Value = " 会心以外は突き抜ける可能性がある 誤差0の確率" + zeroCount + "/" + totalCount + " 誤差1の確率" + oneCount + "/" + totalCount;
                            }
                            else if (min * 2 < remainValue) {
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Pink;
                                dataGridView1.Rows[i].Cells[4].Value = " 偽会心、届かない可能性がある 誤差0の確率" + zeroCount + "/" + totalCount + " 誤差1の確率" + oneCount + "/" + totalCount;
                            }
                            else {
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.MediumPurple;
                                dataGridView1.Rows[i].Cells[4].Value = " 誤差0の確率" + zeroCount + "/" + totalCount + " 誤差1の確率" + oneCount + "/" + totalCount;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                int a = 0;
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

        private void checkBox10_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1_3.Checked) {
                checkBox1_3.Text = "燃え木";
            }
            else {
                checkBox1_3.Text = "通常木";
            }
            setDataGrid();

        }
    }
}
