using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        const int n1 = 9;
        const int n2 = 5;
        const int n3 = 0;
        const int n4 = 7;
        public Node centerNode;

        Graph mainGraph;
        Graph treeGraph;

        Matrix ratioMatrix;

        bool withArrows = true;

        float drawScale = 1;
        Vector2 transformOffset = new Vector2(0, 0);
        Vector2 scaleOffset = new Vector2(0, 0);

        int nodeRadius = 30;
        int bigRadius = 150;

        bool bfsFinished = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // початок програми
        {
            List<Node> nodes = createNodes(10 + n3, new Vector2(400, 200), bigRadius); // створення вершин
            Matrix matrix = generateMatrix(10 + n3); // створення матриці
            mainGraph = new Graph(nodes, matrix);
            treeGraph = new Graph(nodes, new Matrix(matrix.n));

            centerNode = nodes[0];

            writeMatrix(matrix, tbMatrix); // вивід матриць

            bfsStart();

            Invalidate(); // відрисовка графу
        }

        protected override void OnPaint(PaintEventArgs e) // відрисовка графу
        {
            base.OnPaint(e);
            //Вариант 9507
            Graphics g = e.Graphics;

            g.TranslateTransform(transformOffset.x + scaleOffset.x, transformOffset.y + scaleOffset.y);
            g.ScaleTransform(drawScale, drawScale);
            Pen penNode = new Pen(Brushes.Black, 2);
            Pen penLines = new Pen(Brushes.Black, 1);

            Graph graphToDraw = bfsFinished ? treeGraph : mainGraph;
            drawGraph(graphToDraw, penLines, penNode, g, withArrows); // відрисовка ліній і стрілок
        }

        List<Node> createNodes(int count, Vector2 circleCenter, int circleRadius)
        {
            // коло з вершиною в центрі

            List<Node> nodes = new List<Node>();
            nodes.Add(new Node(circleCenter.x, circleCenter.y, nodeRadius, 0, "1"));

            for (int i = 1; i < count; i++)
            {
                float angle = (float)(2 * Math.PI * i / (count - 1));
                Vector2 pos = circleCenter + circleRadius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                nodes.Add(new Node(pos.x, pos.y, nodeRadius, i, (i + 1) + ""));
            }

            return nodes;
        }

        Matrix generateMatrix(int n)
        {
            Random rand = new Random(n1 * 1000 + n2 * 100 + n3 * 10 + n4);
            int[,] m1 = randomMatrix(rand, n);
            int[,] m2 = randomMatrix(rand, n);

            int[,] T = new int[n, n];
            float k = 1.5f;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    
                    T[i, j] = m1[i, j] + m2[i, j];
                    //T[i, j] = 1;    
                    T[i, j] = (int)Math.Floor(T[i,j]*(1.0 - n3*0.001 - n4*0.005 - 0.15));             
                    //T[i, j] = (int)Math.Floor(T[i, j] * (1.0 - n3 * 0.001 - n4 * 0.005 - 0.15) * rand.NextDouble() * k);

                    if (T[i, j] > 1) T[i, j] = 1;
                }
            }
            return new Matrix(T);
        }

        int[,] randomMatrix(Random rand, int n)
        {
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(2);
                }
            }
            return matrix;
        }

        Matrix undirectedMatrix(Matrix mx)
        {
            int[,] res = mx.values.Clone() as int[,];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    if (res[i, j] == 1)
                        res[j, i] = 1;
                }
            }

            return new Matrix(res);
        }

        void writeMatrix(Matrix mx, TextBox tb)
        {
            int[,] m = mx.values;
            tb.Text = "";
            string s = "";

            for (int i = 0; i < m.GetLength(0); i++)
            {
                s = "";
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    s += m[i, j] + " ";
                }
                tb.AppendText(s + "\r\n");
            }
            tb.Text = tb.Text.Remove(tb.Text.LastIndexOf("\r\n"));
        }

        void drawGraph(Graph graph, Pen penLines, Pen penNode, Graphics g, bool withArrows)
        {
            Matrix mx = graph.matrix;
            List<Node> nodes = graph.nodes;

            foreach (var n in nodes)
            {
                n.Draw(penNode, g); // відрисовка вершин
            }

            int[,] matrix = mx.values;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] == 1)
                    {
                     
                        if (i == j)
                        {
                            nodes[i].DrawCircle(centerNode.center, penLines, g, withArrows);
                        }
                        
                        else
                        {
                            bool isSecond = matrix[j, i] == 1 && i > j && withArrows;
                            Vector2 cp = null;
                            Node obstacle = null;


                            foreach (var n in nodes)
                            {
                                cp = n.isBetween(nodes[i], nodes[j]);
                                if (cp != null)
                                {
                                    obstacle = n;
                                    break;
                                }
                            }

                            

                            if (cp != null)
                            {
                                float scale = isSecond ? 1.7f : 1.4f;
                                Vector2 op = obstacle.GetOffsetPointOnCircle(cp, scale);
                                nodes[i].DrawArcTo(nodes[j], op, penLines, g, withArrows);
                            }

                            else
                            {
                                if (isSecond)
                                {
                                    Vector2 op = findFreePointBetween(nodes[i].center, nodes[j].center);
                                    nodes[i].DrawArcTo(nodes[j], op, penLines, g, withArrows);
                                }
                                else
                                    nodes[i].DrawLineTo(nodes[j], penLines, g, withArrows);
                            }
                        }
                    }
                }
            }
        }

        void calculatePowerOfMatrix(Matrix mx, List<Node> nodes)
        {
            int[,] matrix = mx.values;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        nodes[i].hpowOut += 1;
                        nodes[j].hpowIn += 1;

                        nodes[i].power += 1;
                        nodes[j].power += 1;
                        if (matrix[j, i] == 1 && i > j) nodes[i].power -= 1;
                        if (matrix[j, i] == 1 && i > j) nodes[j].power -= 1;
                    }
                }
            }
        } 

        Vector2 findFreePointBetween(Vector2 p1, Vector2 p2)
        {
            Vector2 dir = (p2 - p1).normalized;
            Vector2 cp = (p1 + p2) / 2;
            float h = 15;

            Vector2 t1 = (cp + dir.turnOn((float)(1.57f)) * h);
            bool isOk = true;

            foreach (var node in mainGraph.nodes)
            {
                if (node.ContainsPoint(t1))
                    isOk = false;
            }    
            
            if(!isOk)
                t1 = (cp - dir.turnOn((float)(1.57f)) * h);
            return t1;
        }

        List<int> opens;
        List<int> closed;

        int current = 0;
        int treeIndex = 0;

        void bfsStart()
        {
            foreach(var n in mainGraph.nodes)
            {
                n.current = false;
                n.visited = false;
                n.opened = false;
                n.SetTreeIndex(-1);
            }

            closed = new List<int>();
            opens = new List<int>();
            ratioMatrix = new Matrix(mainGraph.matrix.n);

            bfsFinished = false;
            opens.Add(0);

            current = 0;
            makeNodeCurrent(0);
            treeIndex = 0;
            mainGraph.nodes[current].SetTreeIndex(0);
            treeIndex++;

            Invalidate();
        }

        public void bfsNext()
        {
            int[,] matrix = mainGraph.matrix.values;
            for (int i = 0; i < mainGraph.matrix.n; i++)
            {
                if (matrix[current, i] == 1 && !closed.Contains(i) && !opens.Contains(i))
                {
                    openNode(i);
                    treeGraph.matrix.values[current, i] = 1;
                    mainGraph.nodes[i].SetTreeIndex(treeIndex);
                    treeIndex++;
                }
            }
            closeNode(current);
            if (opens.Count > 0)
            {
                current = opens[0];
                makeNodeCurrent(current);
            }
            else
            {
                bfsFinished = true;
                mainGraph.nodes[current].current = false;
                writeMatrix(treeGraph.matrix, tb_byPass);
                writeMatrix(getRatioMatrix(), tb_ratio);
            }

            Invalidate();
        }

        void openNode(int index)
        {
            opens.Add(index);
            mainGraph.nodes[index].opened = true;
        }

        void closeNode(int index)
        {
            closed.Add(index);
            opens.Remove(index);
        }

        void makeNodeCurrent(int index)
        {
            foreach (var n in mainGraph.nodes)
                n.current = false;

            mainGraph.nodes[index].current = true;
            mainGraph.nodes[index].visited = true;
        }

        Matrix getRatioMatrix()
        {
            Matrix res = new Matrix(mainGraph.matrix.n);
            foreach (var node in mainGraph.nodes)
            {
                res.values[node.treeIndex, node.index] = 1;
            }
            return res;
        }

        private void btn_bfsNext_Click(object sender, EventArgs e)
        {
            bfsNext();
        }

        private void btn_Again_Click(object sender, EventArgs e)
        {
            bfsStart();
        }
    }

    public class Node
    {
        float radius;

        public Vector2 position;
        public int index;
        public string text;
        public Rectangle rect;
        public Vector2 center
        {            
            get { return position + new Vector2(rect.Width, rect.Height) / 2; }
        }

        public int hpowIn = 0;
        public int hpowOut = 0;
        public int power = 0;

        public bool visited = false;
        public bool opened = false;
        public bool current = false;
        public int treeIndex = -1;

        public Node(float x, float y, int radius, int n, string text)
        {        
            index = n;
            this.text = text;
            rect = new Rectangle((int)x, (int)y, 2 * radius, 2 * radius);
            this.radius = radius;
            position = Vector2.FromPoint(rect.Location);
        }

        void UpdateText()
        {
            text = (index + 1).ToString();
            if (treeIndex != -1) text += " (" + (treeIndex + 1) + ")";
        }

        public void SetTreeIndex(int i)
        {
            treeIndex = i;
            UpdateText();
        }

        public void Draw(Pen pen, Graphics g)
        {
            Brush brush = Brushes.Pink;

            if (opened) brush = Brushes.LightGreen;
            if (visited) brush = Brushes.LimeGreen;
            if (current) brush = Brushes.Red;

            g.FillEllipse(brush, rect);
            g.DrawEllipse(pen, rect);
            g.DrawString(text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, (center - new Vector2(1, 0)*4*text.Length - new Vector2(0, 1) * 7).point);
        }

        public void DrawCircle(Vector2 centerPoint, Pen pen, Graphics g, bool withArrow)
        {
            Vector2 dir = (center - centerPoint).normalized;
            Vector2 p = center + dir * 2 * radius;

            Vector2 p2 = p + dir.turnOn((float)(1.57f)) * 30;
            Vector2 p3 = p - dir.turnOn((float)(1.57f)) * 30;

            Vector2 p1 = Vector2.FromPoint(GetEdgePoint(p2));
            Vector2 p4 = Vector2.FromPoint(GetEdgePoint(p3));

            g.DrawBezier(pen, p1.point, p2.point, p3.point, p4.point);

            if (withArrow)
            {
                dir = (p3 - p4).normalized;
                const int h = 10;
                Point t1 = p4.point;
                Point t2 = (Vector2.FromPoint(t1) + dir * h + dir.turnOn((1.57f)) * h / 3).point;
                Point t3 = (Vector2.FromPoint(t1) + dir * h - dir.turnOn((1.57f)) * h / 3).point;

                g.FillPolygon(Brushes.Black, new Point[] { t1, t2, t3 });
            }
        }

        public void DrawLineTo(Node node, Pen pen, Graphics g, bool withArrow)
        {
            Point p1 = GetEdgePoint(node.center);
            Point p2 = node.GetEdgePoint(this.center);
            g.DrawLine(pen, p1, p2);

            if (withArrow)
            {
                Vector2 dir = (center - node.center).normalized;
                const int h = 10;
                Point t1 = p2;
                Point t2 = (Vector2.FromPoint(t1) + dir * h + dir.turnOn((1.57f)) * h / 3).point;
                Point t3 = (Vector2.FromPoint(t1) + dir * h - dir.turnOn((1.57f)) * h / 3).point;

                g.FillPolygon(Brushes.Black, new Point[] {t1, t2, t3});
            }
        }

        public void DrawArcTo(Node node, Vector2 op, Pen pen, Graphics g, bool withArrow)
        {
            Point p1 = GetEdgePoint(op);
            Point p2 = node.GetEdgePoint(op);

            g.DrawBezier(pen, p1, op.point, op.point, p2);

            if (withArrow)
            {
                Vector2 dir = (op - node.center).normalized;
                const int h = 10;
                Point t1 = p2;
                Point t2 = (Vector2.FromPoint(t1) + dir * h + dir.turnOn((1.57f)) * h / 3).point;
                Point t3 = (Vector2.FromPoint(t1) + dir * h - dir.turnOn((1.57f)) * h / 3).point;

                g.FillPolygon(Brushes.Black, new Point[] { t1, t2, t3 });
            }
        }

        public Vector2 isBetween(Node n1, Node n2)
        {
            Vector2 cp = (n2.center + n1.center) / 2;
            if ((cp - center).length < radius)
            {
                if ((cp - center).length < 2)
                {
                    cp = center + (n2.center - n1.center).normalized.turnOn((1.57f)) * 2;
                }           

                return cp;
            }

            return null;
        }

        public Vector2 GetOffsetPointOnCircle(Vector2 point, float scale)
        {
            if (ContainsPoint(point))
            {             
                Vector2 dir = (point - center).normalized;
                Vector2 op = center + dir * (radius * scale);
                return op;
            }
            return null;
        }

        public bool ContainsPoint(Vector2 p)
        {
            if ((center - p).length <= radius)
                return true;

            return false;
        }

        public Point GetEdgePoint(Vector2 point)
        {
            return (center + (point - center).normalized * radius).point;
        }
    }

    public struct Graph
    {
        public List<Node> nodes;
        public Matrix matrix;

        public Graph(List<Node> nodes, Matrix matrix)
        {
            this.nodes = nodes;
            this.matrix = matrix;
        }
    }
}