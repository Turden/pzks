using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic;

namespace SystAnalys_lr1
{
    public partial class Form1 : Form
    {
        
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;
        List<Nkrn> N;
        List<alg2> A;
        int[,] AMatrix; //матрица смежности
        int[,] IMatrix; //матрица инцидентности
        int[] nkrn; // масив nkritn
        int[] tkritn; // масив tkritn
        int[] tkritk; // масив tkritk


        public int selected1; //выбранные вершины, для соединения линиями
        public int selected2;
        int hefte;
        int heftv;
        int P = 0, Q = 0;

        public Form1()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            N = new List<Nkrn>();
            A = new List<alg2>();
            sheet.Image = G.GetBitmap();
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }



        //кнопка - матрица смежности
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        //кнопка - матрица инцидентности 
        private void buttonInc_Click(object sender, EventArgs e)
        {
            createIncAndOut();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "выбрать вершину", ищем степень вершины
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            G.clearSheet();
                            G.drawALLGraph(V, E);
                            sheet.Image = G.GetBitmap();
                        }
                        if (selected1 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            selected1 = i;
                            sheet.Image = G.GetBitmap();
                            createAdjAndOut();
                            listBoxMatrix.Items.Clear();
                            int degree = 0;
                            for (int j = 0; j < V.Count; j++)
                                degree += AMatrix[selected1, j];
                            listBoxMatrix.Items.Add("Вес вершины №" + (selected1 + 1) + " равна " + V[i].heftv);                            
                            break;
                        }
                    }
                }
            }
            //изменить вес вершиты
            if (selectButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Right)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 != -1)
                            {
                                selected1 = -1;
                                G.clearSheet();
                                G.drawALLGraph(V, E);
                                sheet.Image = G.GetBitmap();
                            }
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                createAdjAndOut();
                                listBoxMatrix.Items.Clear();
                                int degree = 0;
                                for (int j = 0; j < V.Count; j++)
                                    degree += AMatrix[selected1, j];
                                V[i].heftv = int.Parse(Interaction.InputBox("Вес вершины:"));                                
                                break;
                            }
                        }
                    }

                }
            }
            
            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                heftv = int.Parse(Interaction.InputBox("Вес вершины:"));
                V.Add(new Vertex(e.X, e.Y, heftv,V.Count));
                G.drawVertex(e.X, e.Y, V.Count.ToString());
                sheet.Image = G.GetBitmap();
            }
            //нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {

                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                hefte = int.Parse(Interaction.InputBox("Вес ребра:"));
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2, hefte,selected1,selected2));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1, hefte);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }

            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearSheet();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        //создание матрицы смежности и вывод в листбокс
        private void createAdjAndOut()
        {
            AMatrix = new int[V.Count, V.Count];
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);
            listBoxMatrix.Items.Clear();
            string sOut = "    ";
            for (int i = 0; i < V.Count; i++)
                sOut += (i + 1) + " ";
            listBoxMatrix.Items.Add(sOut);
            for (int i = 0; i < V.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < V.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                listBoxMatrix.Items.Add(sOut);
            }
        }

        //создание матрицы инцидентности и вывод в листбокс
        private void createIncAndOut()
        {
            if (E.Count > 0)
            {
                IMatrix = new int[V.Count, E.Count];
                G.fillIncidenceMatrix(V.Count, E, IMatrix);
                listBoxMatrix.Items.Clear();
                string sOut = "    ";
                for (int i = 0; i < E.Count; i++)
                    sOut += (char)('a' + i) + " ";
                listBoxMatrix.Items.Add(sOut);
                for (int i = 0; i < V.Count; i++)
                {
                    sOut = (i + 1) + " | ";
                    for (int j = 0; j < E.Count; j++)
                        sOut += IMatrix[i, j] + " ";
                    listBoxMatrix.Items.Add(sOut);
                }
            }
            else
                listBoxMatrix.Items.Clear();
        }

        //поиск элементарных цепей
        private void chainButton_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            //1-white 2-black
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count - 1; i++)
                for (int j = i + 1; j < V.Count; j++)
                {
                    for (int k = 0; k < V.Count; k++)
                        color[k] = 1;
                   // DFSchain(i, j, E, color, (i + 1).ToString());
                }
        }

        //обход в глубину. поиск элементарных цепей. (1-white 2-black)
        int a;        
        private void DFSchain(int u, int endV, List<Edge> E, int[] color, string s,int [] nkrn,int a)
        {
            
            //вершину не следует перекрашивать, если u == endV (возможно в нее есть несколько путей)
            if (u != endV)
            {
                color[u] = 2;
                a++;
            }
            else
            {
                if (nkrn[endV] == 0)
                {
                    nkrn[endV] = a;
                }                               
                a = 0;
                listBoxMatrix.Items.Add(s);                                    
                return;
            }
            for (int w = 0; w < E.Count; w++)
            {
               
                if (color[E[w].v2] == 1 && E[w].v1 == u)
                {
                    
                    DFSchain(E[w].v2, endV, E, color, s + "-" + (E[w].v2 + 1).ToString(), nkrn,a);                    
                    color[E[w].v2] = 1;     
                    
                }
                
            }
        }

        //поиск элементарных циклов
        private void cycleButton_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            //1-white 2-black
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count; i++)
            {
                for (int k = 0; k < V.Count; k++)
                    color[k] = 1;
                List<int> cycle = new List<int>();
                cycle.Add(i + 1);
                DFScycle(i, i, E, color, -1, cycle);
            }
        }

        //обход в глубину. поиск элементарных циклов. (1-white 2-black)
        //Вершину, для которой ищем цикл, перекрашивать в черный не будем. Поэтому, для избежания неправильной
        //работы программы, введем переменную unavailableEdge, в которой будет хранится номер ребра, исключаемый
        //из рассмотрения при обходе графа. В действительности это необходимо только на первом уровне рекурсии,
        //чтобы избежать вывода некорректных циклов вида: 1-2-1, при наличии, например, всего двух вершин.

        private void DFScycle(int u, int endV, List<Edge> E, int[] color, int unavailableEdge, List<int> cycle)
        {
            //если u == endV, то эту вершину перекрашивать не нужно, иначе мы в нее не вернемся, а вернуться необходимо
            if (u != endV)
            {                
                color[u] = 2;
            }
            else
            {
                if (cycle.Count >= 2)
                {
                    cycle.Reverse();
                    string s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    bool flag = false; //есть ли палиндром для этого цикла графа в листбоксе?
                    for (int i = 0; i < listBoxMatrix.Items.Count; i++)
                        if (listBoxMatrix.Items[i].ToString() == s)
                        {
                            flag = true;
                            break;
                        }
                    if (!flag)
                    {
                        cycle.Reverse();
                        s = cycle[0].ToString();
                        for (int i = 1; i < cycle.Count; i++)
                            s += "-" + cycle[i].ToString();
                        listBoxMatrix.Items.Add(s);
                    }
                    return;
                }
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (w == unavailableEdge)
                    continue;
                if (color[E[w].v2] == 1 && E[w].v1 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v2 + 1);
                    DFScycle(E[w].v2, endV, E, color, w, cycleNEW);
                    color[E[w].v2] = 1;
                }
                else if (color[E[w].v1] == 1 && E[w].v2 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v1 + 1);
                    DFScycle(E[w].v1, endV, E, color, w, cycleNEW);
                    color[E[w].v1] = 1;
                }
            }
        }


        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                N.Clear();
                G.clearSheet();

                sheet.Image = G.GetBitmap();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /*if (sheet.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sheet.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            */
            BinaryFormatter ser = new BinaryFormatter();
            using (FileStream file = new FileStream("Граф_V.dat", FileMode.OpenOrCreate))
            {
                ser.Serialize(file, V);
                file.Close();
            }

            BinaryFormatter ser2 = new BinaryFormatter();
            using (FileStream file_2 = new FileStream("Граф_E.dat", FileMode.OpenOrCreate))
            {
                ser2.Serialize(file_2, E);
                file_2.Close();
            }

            BinaryFormatter ser3 = new BinaryFormatter();
            using (FileStream file_3 = new FileStream("Вершины.dat", FileMode.OpenOrCreate))
            {
                ser.Serialize(file_3, P);
                file_3.Close();
            }

            BinaryFormatter ser4 = new BinaryFormatter();
            using (FileStream file_4 = new FileStream("Ребра.dat", FileMode.OpenOrCreate))
            {
                ser2.Serialize(file_4, Q);
                file_4.Close();
            }
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm FormAbout = new aboutForm();
            FormAbout.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        //Алгоритм 14
        private void algo14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            listBoxMatrix.Items.Clear();
            List<Vertex> V2 = V;
            V2.Sort(delegate (Vertex v1, Vertex v2) { return v2.heftv.CompareTo(v1.heftv);});
            foreach(Vertex v in V2)
            {
                listBoxMatrix.Items.Add("Вершина №" + (v.id + 1) + " = " + v.heftv);
            }  
                 
        }
        public double  correlation(out double correlation)
        {
            double sumheftv = 0; // сумма веса всех вершин
            double sumhefte = 0; // сумма веса всех ребер                 
            for (int i=0; i<V.Count; i++)
            {
                sumheftv += V[i].heftv;
                              
            }
            for (int i=0; i<E.Count;i++)
            {
                sumhefte += E[i].hefte;
            }            
            return correlation = sumheftv / (sumheftv + sumhefte);            
        }
        private void generalgorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            V.Clear();
            E.Clear();
            G.clearSheet();
            Generalgor gna = new Generalgor();
            gna.ShowDialog();
            Random rnd = new Random();
            double corr = 0;
            //---------------------------------- Вершина            
            sheet.Image = G.GetBitmap();
            for (int i = 0; i < gna.amountv; i++)
            {
                int bufx = rnd.Next(30, 300);
                int bufy = rnd.Next(30, 400);
                heftv = rnd.Next(gna.minheftv, gna.maxheftv);
                V.Add(new Vertex(bufx, bufy, heftv, V.Count));
                G.drawVertex(bufx, bufy, V.Count.ToString());
            }
            correlation(out corr);
            //---------------------------------- Ребро
            if (gna.ze<1)
            {
                while (corr > gna.ze)
                {
                    lable1: int bufsel1 = rnd.Next(0, gna.amountv);
                    int bufsel2 = rnd.Next(0, gna.amountv);
                    if (bufsel1 == bufsel2)
                    {
                        goto lable1;
                    }
                    hefte = rnd.Next(gna.minhefte, gna.maxhefte);
                    E.Add(new Edge(bufsel1, bufsel2, hefte, bufsel1, bufsel2));
                    G.drawEdge(V[bufsel1], V[bufsel2], E[E.Count - 1], E.Count - 1, hefte);
                    correlation(out corr);
                }                
            }           
            sheet.Image = G.GetBitmap();         
            listBoxMatrix.Items.Add("Correlation = " + corr);
        }
       
        private void checkgrafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            listBoxMatrix.Items.Clear();
            if (flag == false)
            {
                for (int i = 0; i < E.Count; i++)
                {
                    for (int j = 0; i < E.Count; j++)
                    {
                        if (E[i].idEndOfEdge == E[j].idFromEdge)
                        {
                            MessageBox.Show("Цикл !!");
                            flag = true;
                            break;
                        }
                        break;
                    }

                }
            }
            if (flag == false)
            {
                MessageBox.Show("Цикла нет!!");
            }

            //listBoxMatrix.Items.Add("С какой вершины: " + E[i].idFromEdge);
            //listBoxMatrix.Items.Add("В какую вершину: " + E[i].idEndOfEdge);
            //listBoxMatrix.Items.Add("-----------------");
            //MessageBox.Show("Цикл !!");

        }
        int bufTkritn;
        int bufTkritk;
        int tkritgr;
        private void DFS(int u, int endV, List<Edge> E, int[] color, string s, int[] tkritn, int bufTkritn,int[] tkritk,int bufTkritk,int tkritgr)
        {

            //вершину не следует перекрашивать, если u == endV (возможно в нее есть несколько путей)
            if (u != endV)
            {
                color[u] = 2;
                bufTkritn += V[u].heftv;
                bufTkritk += V[u].heftv;
                
                tkritk[endV - 1] = bufTkritk;
                
                
            }
            else
            {
                if (tkritn[endV] < bufTkritn)
                {
                    tkritn[endV] = bufTkritn;                    
                }
                
                bufTkritn = 0;
                
                listBoxMatrix.Items.Add(s);
                return;
            }
            for (int w = 0; w < E.Count; w++)
            {

                if (color[E[w].v2] == 1 && E[w].v1 == u)
                {
                    
                    DFS(E[w].v2, endV, E, color, s + "-" + (E[w].v2 + 1).ToString(), tkritn, bufTkritn,tkritk,bufTkritk,tkritgr);
                    color[E[w].v2] = 1;
                    
                }

            }
        }
        //алгоритм 2
        private void algo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            nkrn = new int[V.Count];
            tkritn = new int[V.Count];
            tkritk = new int[V.Count];
            bufTkritn = 0;
            bufTkritk = 0;
            tkritgr = 0;
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count - 1; i++)
                for (int j = i + 1; j < V.Count; j++)
                {
                    for (int k = 0; k < V.Count; k++)
                        color[k] = 1;
                    DFS(i, j, E, color, (i + 1).ToString(), tkritn, bufTkritn,tkritk,bufTkritk,tkritgr);
                }
            listBoxMatrix.Items.Clear();
            for(int i=V.Count-1;i<V.Count;i++)
            {
                tkritk[i] = V[i].heftv;
            }
            tkritgr = tkritk.Max();
            int[] bufp = new int[V.Count];
            for(int i=0;i<V.Count;i++)
            {
                bufp[i] = (tkritgr - tkritk[i]) - tkritn[i];
            }
            for(int i=0;i<V.Count;i++)
            {
                A.Add(new alg2(V[i].id, bufp[i]));
            }
            List<alg2> A2 = A;
            A2.Sort(delegate (alg2 a1, alg2 a2) { return a1.p.CompareTo(a2.p); });
            foreach (alg2 ab in A)
            {
                listBoxMatrix.Items.Add("№ " + (ab.id+1));
            }
        }
        // алгоритм 7
        private void algo7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            AMatrix = new int[V.Count, V.Count];
            nkrn = new int[V.Count];
            N.Clear();
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);
            //------------------------------- Звязь            
            int[] ks = new int[V.Count];
            nkrn = new int[V.Count];
            a = 0;
            for (int i = 0; i < V.Count; i++)
            {
                for (int j = 0; j < V.Count; j++)
                {
                    ks[i] += AMatrix[i, j];                                                
                }
            }
            //-------------------------------- Nkrn
            
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count - 1; i++)
                for (int j = i + 1; j < V.Count; j++)
                {
                    for (int k = 0; k < V.Count; k++)
                        color[k] = 1;
                    DFSchain(i, j, E, color, (i + 1).ToString(), nkrn,a);
                }
            //--------------------------------
            for (int i=0;i<V.Count;i++)
            {
                N.Add(new Nkrn(V[i].id, nkrn[i], ks[i]));
            }
            //--------------------------------
             List<Nkrn> N2 = N;
             N2.Sort(delegate (Nkrn n1, Nkrn n2) { return n1.nkrn.CompareTo(n2.nkrn); });
            int[,] asf = new int[V.Count, 3];
            for(int i=0;i<V.Count;i++)
            {
                for(int j=0;j<1;j++)
                {
                    asf[i, j] = N2[i].id; 
                }
            }
            for (int i = 0; i < V.Count; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    asf[i, j] = N2[i].nkrn;
                }
            }
            for (int i = 0; i < V.Count; i++)
            {
                for (int j = 2; j < 3; j++)
                {
                    asf[i, j] = N2[i].kolsv;
                }
            }
            //--------------------------------
            for (int i=0;i<V.Count;i++)
            {
                for(int j=1;j<3;j++)
                {
                    
                }
            }
            //--------------------------------
            listBoxMatrix.Items.Clear();
            
            foreach (Nkrn n in N2)
            {
                listBoxMatrix.Items.Add((n.id + 1) + " ( " + n.nkrn + " , " + n.kolsv + " ) ");
            }
            string s;
            for (int i = 0; i < V.Count; i++)
            {
                s = " ";
                for (int j = 0; j < 3; j++)
                {
                    s += (asf[i, j]).ToString() + " ";
                }
                listBoxMatrix.Items.Add(s);
            }
        }
               

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter ser = new BinaryFormatter();
            using (FileStream file = new FileStream("Граф_V.dat", FileMode.OpenOrCreate))
            {
                V = (List<Vertex>)ser.Deserialize(file);
                file.Close();
            }

            BinaryFormatter ser2 = new BinaryFormatter();
            using (FileStream file_2 = new FileStream("Граф_E.dat", FileMode.OpenOrCreate))
            {
                E = (List<Edge>)ser2.Deserialize(file_2);
                file_2.Close();
            }

            BinaryFormatter ser3 = new BinaryFormatter();
            using (FileStream file_3 = new FileStream("Вершины.dat", FileMode.OpenOrCreate))
            {
                P = (int)ser.Deserialize(file_3);
                file_3.Close();
            }

            BinaryFormatter ser4 = new BinaryFormatter();
            using (FileStream file_4 = new FileStream("Ребра.dat", FileMode.OpenOrCreate))
            {
                Q = (int)ser2.Deserialize(file_4);
                file_4.Close();
            }

            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }
    }
}
