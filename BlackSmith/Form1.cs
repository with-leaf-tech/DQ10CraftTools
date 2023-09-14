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

namespace BlackSmith {
    public partial class Form1 : Form {

        private Dictionary<int, List<string>> damegeDic = new Dictionary<int, List<string>>();
        private Dictionary<int, List<string>> damegeDic2 = new Dictionary<int, List<string>>();
        private Dictionary<int, List<string>> damegeDichalf = new Dictionary<int, List<string>>();
        string dir = "./files/";
        TextBox lastEntry = null;

        public Form1() {
            InitializeComponent();

            dataGridView1.Columns.Add("column1", "強さ");
            dataGridView1.Columns.Add("column2", "ダメージ値");
            dataGridView1.Columns.Add("column3", "会心時安全領域");
            dataGridView1.Columns.Add("column4", "会心最大値");
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Font = new Font("MS UI Gothic", 14);
            for (int i = 2000; i > 0; i-= 50) {
                listBox1.Items.Add(i);
            }

            List<string> tempList = new List<string>();
            tempList.Add("通常,18,20,21,23,24,26,27");
            tempList.Add("強め(1.2倍),23,24,26,29,30,32,33");
            tempList.Add("2倍,36,39,42,45,48,51,54");
            tempList.Add("2.5倍,45,50,53,57,60,65,68");
            tempList.Add("3倍,54,59,63,68,72,77,81");
            tempList.Add("0.5倍,9,11,11,12,12,14,14");
            tempList.Add("0.8倍,15,17,18,20,20,21,23");
            damegeDic.Add(2000, tempList);

            tempList = new List<string>();
            tempList.Add("通常,18,20,21,23,24,26,27");
            tempList.Add("強め(1.2倍),23,24,26,29,30,31,33");
            tempList.Add("2倍,36,39,42,45,48,51,54");
            tempList.Add("2.5倍,45,49,52,57,59,64,67");
            tempList.Add("3倍,54,58,62,67,71,76,80");
            tempList.Add("0.5倍,9,11,11,12,12,14,14");
            tempList.Add("0.8倍,15,17,18,20,20,21,23");
            damegeDic.Add(1950, tempList);

            tempList = new List<string>();
            tempList.Add("通常,18,19,21,22,24,25,27");
            tempList.Add("強め(1.2倍),22,24,25,28,29,31,32");
            tempList.Add("2倍,35,38,41,44,47,50,53");
            tempList.Add("2.5倍,44,48,51,56,58,63,66");
            tempList.Add("3倍,53,57,61,66,70,74,79");
            tempList.Add("0.5倍,9,11,11,12,12,14,14");
            tempList.Add("0.8倍,15,16,18,19,19,21,22");
            damegeDic.Add(1900, tempList);

            tempList = new List<string>();
            tempList.Add("通常,18,19,20,22,23,25,26");
            tempList.Add("強め(1.2倍),22,23,25,28,29,30,32");
            tempList.Add("2倍,35,38,40,43,46,49,52");
            tempList.Add("2.5倍,43,48,50,55,57,62,65");
            tempList.Add("3倍,52,56,60,65,69,73,77");
            tempList.Add("0.5倍,9,10,10,12,12,13,13");
            tempList.Add("0.8倍,15,16,18,19,19,20,22");
            damegeDic.Add(1850, tempList);

            tempList = new List<string>();
            tempList.Add("通常,17,19,20,21,23,24,26");
            tempList.Add("強め(1.2倍),21,23,24,27,28,30,31");
            tempList.Add("2倍,34,37,40,42,45,48,51");
            tempList.Add("2.5倍,42,47,49,54,56,61,63");
            tempList.Add("3倍,51,55,59,63,68,72,76");
            tempList.Add("0.5倍,9,10,10,12,12,13,13");
            tempList.Add("0.8倍,14,16,17,19,19,20,21");
            damegeDic.Add(1800, tempList);

            tempList = new List<string>();
            tempList.Add("通常,17,18,20,21,22,24,25");
            tempList.Add("強め(1.2倍),21,22,24,27,28,29,31");
            tempList.Add("2倍,33,36,39,42,44,47,50");
            tempList.Add("2.5倍,42,46,49,53,55,60,62");
            tempList.Add("3倍,50,54,58,62,66,71,75");
            tempList.Add("0.5倍,9,10,10,11,11,13,13");
            tempList.Add("0.8倍,14,16,17,18,18,20,21");
            damegeDic.Add(1750, tempList);

            tempList = new List<string>();
            tempList.Add("通常,17,18,19,21,22,23,25");
            tempList.Add("強め(1.2倍),21,22,23,26,27,29,30");
            tempList.Add("2倍,33,36,38,41,44,46,49");
            tempList.Add("2.5倍,41,45,48,52,54,59,61");
            tempList.Add("3倍,49,53,57,61,65,69,73");
            tempList.Add("0.5倍,9,10,10,11,11,13,13");
            tempList.Add("0.8倍,14,15,17,18,18,19,21");
            damegeDic.Add(1700, tempList);

            tempList = new List<string>();
            tempList.Add("通常,16,18,19,20,22,23,24");
            tempList.Add("強め(1.2倍),20,22,23,26,27,28,30");
            tempList.Add("2倍,32,35,38,40,43,46,48");
            tempList.Add("2.5倍,40,44,47,51,53,57,60");
            tempList.Add("3倍,48,52,56,60,64,68,72");
            tempList.Add("0.5倍,8,10,10,11,11,12,12");
            tempList.Add("0.8倍,14,15,16,18,18,19,20");
            damegeDic.Add(1650, tempList);

            tempList = new List<string>();
            tempList.Add("通常,16,17,19,20,21,23,24");
            tempList.Add("強め(1.2倍),20,21,23,25,26,28,29");
            tempList.Add("2倍,32,34,37,39,42,45,47");
            tempList.Add("2.5倍,39,43,46,50,52,56,59");
            tempList.Add("3倍,47,51,55,59,63,67,71");
            tempList.Add("0.5倍,8,10,10,11,11,12,12");
            tempList.Add("0.8倍,13,15,16,17,17,19,20");
            damegeDic.Add(1600, tempList);

            tempList = new List<string>();
            tempList.Add("通常,16,17,18,20,21,22,23");
            tempList.Add("強め(1.2倍),20,21,22,25,26,27,29");
            tempList.Add("2倍,31,34,36,39,41,44,46");
            tempList.Add("2.5倍,39,43,45,49,51,55,58");
            tempList.Add("3倍,46,50,54,58,62,66,69");
            tempList.Add("0.5倍,8,9,9,11,11,12,12");
            tempList.Add("0.8倍,13,15,16,17,17,18,20");
            damegeDic.Add(1550, tempList);

            tempList = new List<string>();
            tempList.Add("通常,15,17,18,19,20,22,23");
            tempList.Add("強め(1.2倍),19,20,22,24,25,27,28");
            tempList.Add("2倍,30,33,35,38,40,43,45");
            tempList.Add("2.5倍,38,42,44,48,50,54,57");
            tempList.Add("3倍,45,49,53,57,60,64,68");
            tempList.Add("0.5倍,8,9,9,10,10,12,12");
            tempList.Add("0.8倍,13,14,15,17,17,18,19");
            damegeDic.Add(1500, tempList);

            tempList = new List<string>();
            tempList.Add("通常,15,16,18,19,20,21,23");
            tempList.Add("強め(1.2倍),19,20,21,24,25,26,27");
            tempList.Add("2倍,30,32,35,37,40,42,45");
            tempList.Add("2.5倍,37,41,43,47,49,53,56");
            tempList.Add("3倍,45,48,52,56,59,63,67");
            tempList.Add("0.5倍,8,9,9,10,10,12,12");
            tempList.Add("0.8倍,13,14,15,16,16,18,19");
            damegeDic.Add(1450, tempList);

            tempList = new List<string>();
            tempList.Add("通常,15,16,17,18,20,21,22");
            tempList.Add("強め(1.2倍),18,20,21,23,24,26,27");
            tempList.Add("2倍,29,32,34,36,39,41,44");
            tempList.Add("2.5倍,36,40,42,46,48,52,54");
            tempList.Add("3倍,44,47,51,54,58,62,65");
            tempList.Add("0.5倍,8,9,9,10,10,11,11");
            tempList.Add("0.8倍,12,14,15,16,16,17,18");
            damegeDic.Add(1400, tempList);

            tempList = new List<string>();
            tempList.Add("通常,15,16,17,18,19,20,22");
            tempList.Add("強め(1.2倍),18,19,20,23,24,25,26");
            tempList.Add("2倍,29,31,33,36,38,40,43");
            tempList.Add("2.5倍,36,39,42,45,47,51,53");
            tempList.Add("3倍,43,46,50,53,57,60,64");
            tempList.Add("0.5倍,8,9,9,10,10,11,11");
            tempList.Add("0.8倍,12,13,15,16,16,17,18");
            damegeDic.Add(1350, tempList);

            tempList = new List<string>();
            tempList.Add("通常,14,15,17,18,19,20,21");
            tempList.Add("強め(1.2倍),18,19,20,22,23,25,26");
            tempList.Add("2倍,28,30,33,35,37,40,42");
            tempList.Add("2.5倍,35,38,41,44,46,50,52");
            tempList.Add("3倍,42,45,49,52,56,59,63");
            tempList.Add("0.5倍,7,9,9,10,10,11,11");
            tempList.Add("0.8倍,12,13,14,15,15,17,18");
            damegeDic.Add(1300, tempList);

            tempList = new List<string>();
            tempList.Add("通常,14,15,16,17,18,20,21");
            tempList.Add("強め(1.2倍),17,18,20,22,23,24,25");
            tempList.Add("2倍,27,30,32,34,36,39,41");
            tempList.Add("2.5倍,34,38,40,43,45,49,51");
            tempList.Add("3倍,41,44,48,51,54,58,61");
            tempList.Add("0.5倍,7,8,8,9,9,11,11");
            tempList.Add("0.8倍,12,13,14,15,15,16,17");
            damegeDic.Add(1250, tempList);

            tempList = new List<string>();
            tempList.Add("通常,14,15,16,17,18,19,20");
            tempList.Add("強め(1.2倍),17,18,19,21,22,24,25");
            tempList.Add("2倍,27,29,31,33,36,38,40");
            tempList.Add("2.5倍,33,37,39,42,44,48,50");
            tempList.Add("3倍,40,43,47,50,53,57,60");
            tempList.Add("0.5倍,7,8,8,9,9,10,10");
            tempList.Add("0.8倍,11,13,14,15,15,16,17");
            damegeDic.Add(1200, tempList);

            tempList = new List<string>();
            tempList.Add("通常,13,14,16,17,18,19,20");
            tempList.Add("強め(1.2倍),17,18,19,21,22,23,24");
            tempList.Add("2倍,26,28,31,33,35,37,39");
            tempList.Add("2.5倍,33,36,38,41,43,47,49");
            tempList.Add("3倍,39,42,46,49,52,55,59");
            tempList.Add("0.5倍,7,8,8,9,9,10,10");
            tempList.Add("0.8倍,11,12,13,14,14,16,17");
            damegeDic.Add(1150, tempList);

            tempList = new List<string>();
            tempList.Add("通常,13,14,15,16,17,18,19");
            tempList.Add("強め(1.2倍),16,17,18,20,21,23,24");
            tempList.Add("2倍,26,28,30,32,34,36,38");
            tempList.Add("2.5倍,32,35,37,40,42,46,48");
            tempList.Add("3倍,38,41,45,48,51,54,57");
            tempList.Add("0.5倍,7,8,8,9,9,10,10");
            tempList.Add("0.8倍,11,12,13,14,14,15,16");
            damegeDic.Add(1100, tempList);

            tempList = new List<string>();
            tempList.Add("通常,13,14,15,16,17,18,19");
            tempList.Add("強め(1.2倍),16,17,18,20,21,22,23");
            tempList.Add("2倍,25,27,29,31,33,35,37");
            tempList.Add("2.5倍,31,34,36,39,41,45,47");
            tempList.Add("3倍,37,40,44,47,50,53,56");
            tempList.Add("0.5倍,7,8,8,9,9,10,10");
            tempList.Add("0.8倍,11,12,13,14,14,15,16");
            damegeDic.Add(1050, tempList);

            tempList = new List<string>();
            tempList.Add("通常,12,13,14,15,16,17,18");
            tempList.Add("強め(1.2倍),15,16,17,19,20,21,22");
            tempList.Add("2倍,24,26,28,30,32,34,36");
            tempList.Add("2.5倍,30,33,35,38,40,43,45");
            tempList.Add("3倍,36,39,42,45,48,51,54");
            tempList.Add("0.5倍,6,7,7,8,8,9,9");
            tempList.Add("0.8倍,10,11,12,13,13,14,15");
            damegeDic.Add(1000, tempList);

            tempList = new List<string>();
            tempList.Add("通常,12,13,14,15,16,17,18");
            tempList.Add("強め(1.2倍),15,16,17,19,20,21,22");
            tempList.Add("2倍,24,26,28,30,32,34,36");
            tempList.Add("2.5倍,30,33,35,38,39,42,44");
            tempList.Add("3倍,36,39,41,44,47,50,53");
            tempList.Add("0.5倍,6,7,7,8,8,9,9");
            tempList.Add("0.8倍,10,11,12,13,13,14,15");
            damegeDic.Add(950, tempList);

            tempList = new List<string>();
            tempList.Add("通常,12,13,14,15,16,17,18");
            tempList.Add("強め(1.2倍),15,16,17,19,19,20,21");
            tempList.Add("2倍,23,25,27,29,31,33,35");
            tempList.Add("2.5倍,29,32,34,37,38,41,43");
            tempList.Add("3倍,35,38,40,43,46,49,52");
            tempList.Add("0.5倍,6,7,7,8,8,9,9");
            tempList.Add("0.8倍,10,11,12,13,13,14,15");
            damegeDic.Add(900, tempList);

            tempList = new List<string>();
            tempList.Add("通常,12,13,13,14,15,16,17");
            tempList.Add("強め(1.2倍),14,15,16,18,19,20,21");
            tempList.Add("2倍,23,25,26,28,30,32,34");
            tempList.Add("2.5倍,28,31,33,36,37,40,42");
            tempList.Add("3倍,34,37,39,42,45,48,50");
            tempList.Add("0.5倍,6,7,7,8,8,9,9");
            tempList.Add("0.8倍,10,11,12,13,13,13,14");
            damegeDic.Add(850, tempList);

            tempList = new List<string>();
            tempList.Add("通常,11,12,13,14,15,16,17");
            tempList.Add("強め(1.2倍),14,15,16,18,18,19,20");
            tempList.Add("2倍,22,24,26,27,29,31,33");
            tempList.Add("2.5倍,27,30,32,35,36,39,41");
            tempList.Add("3倍,33,36,38,41,44,46,49");
            tempList.Add("0.5倍,6,7,7,8,8,9,9");
            tempList.Add("0.8倍,9,10,11,12,12,13,14");
            damegeDic.Add(800, tempList);

            tempList = new List<string>();
            tempList.Add("通常,11,12,13,14,14,15,16");
            tempList.Add("強め(1.2倍),14,14,15,17,18,19,20");
            tempList.Add("2倍,21,23,25,27,28,30,32");
            tempList.Add("2.5倍,27,29,31,34,35,38,40");
            tempList.Add("3倍,32,35,37,40,42,45,48");
            tempList.Add("0.5倍,6,7,7,7,7,8,8");
            tempList.Add("0.8倍,9,10,11,12,12,13,14");
            damegeDic.Add(750, tempList);

            tempList = new List<string>();
            tempList.Add("通常,11,12,12,13,14,15,16");
            tempList.Add("強め(1.2倍),13,14,15,17,17,18,19");
            tempList.Add("2倍,21,23,24,26,28,29,31");
            tempList.Add("2.5倍,26,29,30,33,34,37,39");
            tempList.Add("3倍,31,34,36,39,41,44,46");
            tempList.Add("0.5倍,6,6,6,7,7,8,8");
            tempList.Add("0.8倍,9,10,11,12,12,12,13");
            damegeDic.Add(700, tempList);

            tempList = new List<string>();
            tempList.Add("通常,10,11,12,13,14,15,15");
            tempList.Add("強め(1.2倍),13,14,15,16,17,18,19");
            tempList.Add("2倍,20,22,24,25,27,29,30");
            tempList.Add("2.5倍,25,28,29,32,33,36,38");
            tempList.Add("3倍,30,33,35,38,40,43,45");
            tempList.Add("0.5倍,5,6,6,7,7,8,8");
            tempList.Add("0.8倍,9,10,10,11,11,12,13");
            damegeDic.Add(650, tempList);

            tempList = new List<string>();
            tempList.Add("通常,10,11,12,12,13,14,15");
            tempList.Add("強め(1.2倍),12,13,14,16,16,17,18");
            tempList.Add("2倍,20,21,23,24,26,28,29");
            tempList.Add("2.5倍,24,27,28,31,32,35,36");
            tempList.Add("3倍,29,32,34,36,39,41,44");
            tempList.Add("0.5倍,5,6,6,7,7,8,8");
            tempList.Add("0.8倍,8,9,10,11,11,12,12");
            damegeDic.Add(600, tempList);

            tempList = new List<string>();
            tempList.Add("通常,10,11,11,12,13,14,14");
            tempList.Add("強め(1.2倍),12,13,14,15,16,17,18");
            tempList.Add("2倍,19,21,22,24,25,27,28");
            tempList.Add("2.5倍,24,26,28,30,31,34,35");
            tempList.Add("3倍,28,31,33,35,38,40,42");
            tempList.Add("0.5倍,5,6,6,7,7,7,7");
            tempList.Add("0.8倍,8,9,10,11,11,11,12");
            damegeDic.Add(550, tempList);

            tempList = new List<string>();
            tempList.Add("通常,9,10,11,12,12,13,14");
            tempList.Add("強め(1.2倍),12,12,13,15,15,16,17");
            tempList.Add("2倍,18,20,21,23,24,26,27");
            tempList.Add("2.5倍,23,25,27,29,30,33,34");
            tempList.Add("3倍,27,30,32,34,36,39,41");
            tempList.Add("0.5倍,5,6,6,6,6,7,7");
            tempList.Add("0.8倍,8,9,9,10,10,11,12");
            damegeDic.Add(500, tempList);

            tempList = new List<string>();
            tempList.Add("通常,9,10,11,11,12,13,14");
            tempList.Add("強め(1.2倍),11,12,13,14,15,16,16");
            tempList.Add("2倍,18,19,21,22,24,25,27");
            tempList.Add("2.5倍,22,24,26,28,29,32,33");
            tempList.Add("3倍,27,29,31,33,35,37,40");
            tempList.Add("0.5倍,5,6,6,6,6,7,7");
            tempList.Add("0.8倍,8,8,9,10,10,11,11");
            damegeDic.Add(450, tempList);

            tempList = new List<string>();
            tempList.Add("通常,9,10,10,11,12,12,13");
            tempList.Add("強め(1.2倍),11,12,12,14,14,15,16");
            tempList.Add("2倍,17,19,20,21,23,24,26");
            tempList.Add("2.5倍,21,24,25,27,28,31,32");
            tempList.Add("3倍,26,28,30,32,34,36,38");
            tempList.Add("0.5倍,5,5,5,6,6,7,7");
            tempList.Add("0.8倍,7,8,9,10,10,10,11");
            damegeDic.Add(400, tempList);

            tempList = new List<string>();
            tempList.Add("通常,9,9,10,11,11,12,13");
            tempList.Add("強め(1.2倍),11,11,12,13,14,15,15");
            tempList.Add("2倍,17,18,19,21,22,23,25");
            tempList.Add("2.5倍,21,23,24,26,27,30,31");
            tempList.Add("3倍,25,27,29,31,33,35,37");
            tempList.Add("0.5倍,5,5,5,6,6,7,7");
            tempList.Add("0.8倍,7,8,9,9,9,10,11");
            damegeDic.Add(350, tempList);

            tempList = new List<string>();
            tempList.Add("通常,8,9,10,10,11,12,12");
            tempList.Add("強め(1.2倍),10,11,12,13,13,14,15");
            tempList.Add("2倍,16,17,19,20,21,23,24");
            tempList.Add("2.5倍,20,22,23,25,26,28,30");
            tempList.Add("3倍,24,26,28,30,32,34,36");
            tempList.Add("0.5倍,4,5,5,6,6,6,6");
            tempList.Add("0.8倍,7,8,8,9,9,10,10");
            damegeDic.Add(300, tempList);

            tempList = new List<string>();
            tempList.Add("通常,8,9,9,10,10,11,12");
            tempList.Add("強め(1.2倍),10,10,11,12,13,14,14");
            tempList.Add("2倍,15,17,18,19,20,22,23");
            tempList.Add("2.5倍,19,21,22,24,25,27,29");
            tempList.Add("3倍,23,25,27,29,30,32,34");
            tempList.Add("0.5倍,4,5,5,5,5,6,6");
            tempList.Add("0.8倍,7,7,8,9,9,9,10");
            damegeDic.Add(250, tempList);

            tempList = new List<string>();
            tempList.Add("通常,8,8,9,9,10,11,11");
            tempList.Add("強め(1.2倍),9,10,11,12,12,13,14");
            tempList.Add("2倍,15,16,17,18,20,21,22");
            tempList.Add("2.5倍,18,20,21,23,24,26,27");
            tempList.Add("3倍,22,24,26,27,29,31,33");
            tempList.Add("0.5倍,4,5,5,5,5,6,6");
            tempList.Add("0.8倍,6,7,8,8,8,9,9");
            damegeDic.Add(200, tempList);

            tempList = new List<string>();
            tempList.Add("通常,7,8,9,9,10,10,11");
            tempList.Add("強め(1.2倍),9,10,10,11,12,13,13");
            tempList.Add("2倍,14,15,17,18,19,20,21");
            tempList.Add("2.5倍,18,19,21,22,23,25,26");
            tempList.Add("3倍,21,23,25,26,28,30,32");
            tempList.Add("0.5倍,4,5,5,5,5,6,6");
            tempList.Add("0.8倍,6,7,7,8,8,9,9");
            damegeDic.Add(150, tempList);

            tempList = new List<string>();
            tempList.Add("通常,7,8,8,9,9,10,10");
            tempList.Add("強め(1.2倍),9,9,10,11,11,12,13");
            tempList.Add("2倍,14,15,16,17,18,19,20");
            tempList.Add("2.5倍,17,19,20,21,22,24,25");
            tempList.Add("3倍,20,22,24,25,27,29,30");
            tempList.Add("0.5倍,4,4,4,5,5,5,5");
            tempList.Add("0.8倍,6,7,7,8,8,8,9");
            damegeDic.Add(100, tempList);

            tempList = new List<string>();
            tempList.Add("通常,7,7,8,8,9,9,10");
            tempList.Add("強め(1.2倍),8,9,9,10,11,12,12");
            tempList.Add("2倍,13,14,15,16,17,18,19");
            tempList.Add("2.5倍,16,18,19,20,21,23,24");
            tempList.Add("3倍,19,21,23,24,26,27,29");
            tempList.Add("0.5倍,4,4,4,5,5,5,5");
            tempList.Add("0.8倍,6,6,7,7,7,8,8");
            damegeDic.Add(50, tempList);

            foreach(int key in damegeDic.Keys) {
                damegeDic2.Add(key, new List<string>(damegeDic[key]));
                damegeDichalf.Add(key, new List<string>(damegeDic[key]));
            }

            foreach(int key in damegeDic2.Keys) {
                if( key % 200 == 0) {
                    List<string> list = damegeDic2[key];
                    for(int i = 0; i < list.Count; i++) {
                        string[] parts = list[i].Split(new char[] { ',' });
                        string newValue = parts[0];
                        for(int j = 1; j < parts.Length; j++) {
                            newValue += "," + int.Parse(parts[j]) * 2;
                        }
                        list[i] = newValue;
                    }
                }
            }

            foreach (int key in damegeDichalf.Keys) {
                if (key % 400 == 0) {
                    List<string> list = damegeDichalf[key];
                    for (int i = 0; i < list.Count; i++) {
                        string[] parts = list[i].Split(new char[] { ',' });
                        string newValue = parts[0];
                        for (int j = 1; j < parts.Length; j++) {
                            newValue += "," + int.Parse(parts[j]) * 2;
                        }
                        list[i] = newValue;
                    }
                }
                if (key % 400 == 200) {
                    List<string> list = damegeDichalf[key];
                    for (int i = 0; i < list.Count; i++) {
                        string[] parts = list[i].Split(new char[] { ',' });
                        string newValue = parts[0];
                        for (int j = 1; j < parts.Length; j++) {
                            if(int.Parse(parts[j]) % 2 == 0) {
                                newValue += "," + int.Parse(parts[j]) / 2;
                            }
                            else {
                                newValue += "," + Math.Ceiling(int.Parse(parts[j]) / 2.0);
                            }
                        }
                        list[i] = newValue;
                    }
                }
            }

            foreach (List<string> list in damegeDic.Values) {
                for (int i = 0; i < list.Count; i++) {
                    string[] items = list[i].Split(new char[] { ',' });
                    string best = "," + items[items.Length - 1] + "-" + int.Parse(items[1]) * 2 + "," + int.Parse(items[items.Length - 1]) * 2;
                    list[i] += best;
                }
            }

            foreach (List<string> list in damegeDic2.Values) {
                for (int i = 0; i < list.Count; i++) {
                    string[] items = list[i].Split(new char[] { ',' });
                    string best = "," + items[items.Length - 1] + "-" + int.Parse(items[1]) * 2 + "," + int.Parse(items[items.Length - 1]) * 2;
                    list[i] += best;
                }
            }

            foreach (List<string> list in damegeDichalf.Values) {
                for (int i = 0; i < list.Count; i++) {
                    string[] items = list[i].Split(new char[] { ',' });
                    string best = "," + items[items.Length - 1] + "-" + int.Parse(items[1]) * 2 + "," + int.Parse(items[items.Length - 1]) * 2;
                    list[i] += best;
                }
            }
            reloadFiles();

            listBox1.SelectedIndex = 20;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (!File.Exists(dir + comboBox1.SelectedItem + ".txt")) {
                MessageBox.Show("ファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] param = File.ReadAllLines(dir + comboBox1.SelectedItem + ".txt");
            setParam(checkBox1, textBox1_1, textBox1_2, param[0]);
            setParam(checkBox2, textBox2_1, textBox2_2, param[1]);
            setParam(checkBox3, textBox3_1, textBox3_2, param[2]);
            setParam(checkBox4, textBox4_1, textBox4_2, param[3]);
            setParam(checkBox5, textBox5_1, textBox5_2, param[4]);
            setParam(checkBox6, textBox6_1, textBox6_2, param[5]);
            setParam(checkBox7, textBox7_1, textBox7_2, param[6]);
            setParam(checkBox8, textBox8_1, textBox8_2, param[7]);
            setParam(checkBox9, textBox9_1, textBox9_2, param[8]);
            comboBox2.SelectedItem = param[9];

            if (param.Length > 10) {
                for (int i = 10; i < param.Length; i++) {
                    textBox11.Text += param[i] + "\r\n";
                }
            }

            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";

        }

        private void button2_Click(object sender, EventArgs e) {
            if(textBox10.Text.Length == 0) {
                MessageBox.Show("ファイル名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(File.Exists(dir + textBox10.Text + ".txt")) {
                if(MessageBox.Show("同名のファイルがあります。上書きしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }
            }
            if(comboBox2.SelectedIndex < 0) {
                MessageBox.Show("地金を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> paramList = new List<string>();
            try {
                paramList.Add(buildParam(checkBox1, textBox1_1, textBox1_2));
                paramList.Add(buildParam(checkBox2, textBox2_1, textBox2_2));
                paramList.Add(buildParam(checkBox3, textBox3_1, textBox3_2));
                paramList.Add(buildParam(checkBox4, textBox4_1, textBox4_2));
                paramList.Add(buildParam(checkBox5, textBox5_1, textBox5_2));
                paramList.Add(buildParam(checkBox6, textBox6_1, textBox6_2));
                paramList.Add(buildParam(checkBox7, textBox7_1, textBox7_2));
                paramList.Add(buildParam(checkBox8, textBox8_1, textBox8_2));
                paramList.Add(buildParam(checkBox9, textBox9_1, textBox9_2));
                paramList.Add(comboBox2.SelectedItem.ToString());
                paramList.Add(textBox11.Text);

                File.WriteAllLines(dir + textBox10.Text + ".txt", paramList.ToArray());
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reloadFiles();
        }

        private string buildParam(CheckBox checkbox, TextBox low, TextBox high) {
            string param = "";
            if (checkbox.Checked && (low.Text.Length == 0 || high.Text.Length == 0)) {
                throw new Exception("レンジを入力してください");
            }
            if (checkbox.Checked) {
                param += "1," + low.Text + "," + high.Text + ",";
            }
            else {
                param += "0,0,0,";
            }
            return param;
        }

        private void setParam(CheckBox checkbox, TextBox low, TextBox high, string param) {
            string[] parts = param.Split(new char[] { ',' });
            if(parts[0] == "1") {
                checkbox.Checked = true;
                low.Text = parts[1];
                high.Text = parts[2];
            }
            else {
                checkbox.Checked = false;
                low.Text = "";
                high.Text = "";
            }
        }


        private void reloadFiles() {
            comboBox1.Items.Clear();
            if(!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            string[] files = System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly);
            int index = comboBox1.SelectedIndex;
            foreach (string key in files) {
                comboBox1.Items.Add(key.Replace(dir, "").Replace(".txt", ""));
            }
            if(index > 0) {
                comboBox1.SelectedIndex = index;
            }
        }


        private void listBox1_Click(object sender, EventArgs e) {
            try {
                listBox2.Items.Clear();
                dataGridView1.Rows.Clear();
                if(listBox1.SelectedIndex >= 0) {
                    int temp = int.Parse(listBox1.SelectedItem.ToString());
                    List<string> list = null;
                    if (comboBox2.SelectedItem.ToString() == "威力会心アップ") {
                        list = damegeDic2[temp];
                    }
                    else if (comboBox2.SelectedItem.ToString() == "たたき変化") {
                        list = damegeDichalf[temp];
                    }
                    else {
                        list = damegeDic[temp];
                    }
                    var list2 = GetLines(list);
                    for (int i = 0; i < list2.Count; i++) {
                        //listBox2.Items.Add(list[i]);
                        dataGridView1.Rows.Add(list2[i]);
                    }
                    dataGridView1.CurrentCell = null;
                }
            }
            catch(Exception ex) {
                string error = ex.Message;
            }
            if (lastEntry != null) {
                lastEntry.Focus();
            }
        }

        private List<string[]> GetLines(List<string> list) {
            List<string[]> returnList = new List<string[]>();
            for (int i = 0; i < list.Count; i++) {
                string[] lineParts = list[i].Split(new char[] { ',' });
                string name = lineParts[0];
                string safeRange = lineParts[lineParts.Length - 2];
                string maxNum = lineParts[lineParts.Length - 1];
                string range = "";
                for(int j = 1; j < lineParts.Length -2; j++) {
                    if(range.Length != 0) {
                        range += ",";
                    }
                    range += lineParts[j];
                }
                returnList.Add(new string[] { name, range, safeRange, maxNum });
            }
            return returnList;
        }


        private void textBox1_TextChanged(object sender, EventArgs e) {
            TextBox low = textBox1_1;
            TextBox high = textBox1_2;
            Label remain = label1;
            if ((TextBox)sender == textBox1) {
                low = textBox1_1;
                high = textBox1_2;
                remain = label1;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox2) {
                low = textBox2_1;
                high = textBox2_2;
                remain = label2;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox3) {
                low = textBox3_1;
                high = textBox3_2;
                remain = label3;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox4) {
                low = textBox4_1;
                high = textBox4_2;
                remain = label4;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox5) {
                low = textBox5_1;
                high = textBox5_2;
                remain = label5;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox6) {
                low = textBox6_1;
                high = textBox6_2;
                remain = label6;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox7) {
                low = textBox7_1;
                high = textBox7_2;
                remain = label7;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox8) {
                low = textBox8_1;
                high = textBox8_2;
                remain = label8;
                lastEntry = textBox1;
            }
            else if ((TextBox)sender == textBox9) {
                low = textBox9_1;
                high = textBox9_2;
                remain = label9;
                lastEntry = textBox1;
            }
            else {
                lastEntry = null;
            }

            try {
                int value = int.Parse(((TextBox)sender).Text);
                int remainValue = int.Parse(high.Text) - value;
                remain.Text = (int.Parse(high.Text) - value).ToString();

                for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                    if(dataGridView1.Rows[i].Cells[0].Value != null) {
                        /*
                        string[] parts = dataGridView1.Rows[i].Cells[0].Value.ToString().Split(new char[] { ',' });
                        string[] range = parts[parts.Length - 2].Split(new char[] { '-' });
                        string max = parts[parts.Length - 3];
                        string max2 = parts[parts.Length - 1];
                        */
                        string[] parts = dataGridView1.Rows[i].Cells[1].Value.ToString().Split(new char[] { ',' });
                        string[] range = dataGridView1.Rows[i].Cells[2].Value.ToString().Split(new char[] { '-' });
                        string max = parts[parts.Length - 1];
                        string max2 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        if (int.Parse(range[0]) <= remainValue && int.Parse(range[1]) >= remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                        }
                        else if (int.Parse(max2) < remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Aqua;
                        }
                        else if (int.Parse(max) > remainValue) {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        }
                        else {
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.MediumPurple;
                        }
                    }
                }
        }
            catch (Exception ex) {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            listBox1_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e) {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";

        }

        private void textBox1_Click(object sender, EventArgs e) {
            ((TextBox)sender).SelectAll();

        }

        private void button5_Click(object sender, EventArgs e) {
            string msg = @"";
            new Form2(msg).Show();
        }
    }
}
