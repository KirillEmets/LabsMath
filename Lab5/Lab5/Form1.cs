using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        static Random rand = new Random(n1 * 1000 + n2 * 100 + n3 * 10 + n4);

        const int n1 = 9;
        const int n2 = 5;
        const int n3 = 0;
        const int n4 = 7;
        public Node centerNode;

        Graph mainGraph;
        Graph spanningGraph;

        bool withArrows = false;

        float drawScale = 1.1f;
        Vector2 transformOffset = new Vector2(0, 0);
        Vector2 scaleOffset = new Vector2(-30, 0);

        int nodeRadius = 30;
        int bigRadius = 150;

        bool primaFinished = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // початок програми
        {
            List<Node> nodes = createNodes(10 + n3, new Vector2(400, 200), bigRadius); // створення вершин
            Matrix matrix = generateMatrix(10 + n3); // створення матриці
            writeMatrix(matrix, tbMatrix); // вивід матриць

            matrix = matrix.Or(matrix.Transposed);
            writeMatrix(matrix, tb_nondir);

            Matrix weights = generateWeights(matrix);
            weights = weights.CombinedWith(weights.Transposed);

            List<Node> spanningNodes = createNodes(10 + n3, new Vector2(800, 200), bigRadius); // створення вершин


            mainGraph = new Graph(nodes, matrix, weights);
            spanningGraph = new Graph(spanningNodes, new Matrix(matrix.n), weights);

            centerNode = nodes[0];


            PrimaStart();

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

            drawGraph(mainGraph, penLines, penNode, g, withArrows); // відрисовка ліній і стрілок
            drawGraph(spanningGraph, penLines, penNode, g, withArrows); // відрисовка ліній і стрілок
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
            Matrix m1 = randomMatrix(n);
            Matrix m2 = randomMatrix(n);

            double k = 0.8;

            Matrix T = new Matrix(n);
            T = m1.CombinedWith(m2);
            T = T.ElementMultiply((1.0 - n3 * 0.01 - n4 * 0.005 - 0.05) * k);
            T = T.Floor;

            return T;
        }

        Matrix generateWeights(Matrix A)
        {
            int n = A.n;
            Matrix Wt = randomMatrix(n).ElementMultiply(100).ElementMultiply(A).Round;
            Matrix B = Wt.ToOnes();

            Wt = B.And(B.Transposed.Not).Or(B.And(B.Transposed))
                .ElementMultiply(Matrix.Tril(n)).ElementMultiply(Wt);

            return Wt;
        }

        Matrix randomMatrix(int n)
        {
            Matrix matrix = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix.values[i, j] = rand.NextDouble();
                }
            }
            return matrix;
        }

        

        void writeMatrix(Matrix mx, TextBox tb)
        {
            double[,] m = mx.values;
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

            double[,] matrix = mx.values;
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

                            Brush wBrush = Brushes.DarkRed;
                            if ((i == lastN && j == last2N) || (i == last2N && j == lastN))
                            {
                                penLines = Pens.Red;
                                wBrush = Brushes.Red;
                            }
                            else
                            {
                                penLines = Pens.Black;
                            }

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

                                Point c = (op + (op - cp).normalized * 13 + new Vector2(-8, -4)).point;
                                g.DrawString(graph.weights.values[i, j] + "", new Font("Arial", 12), wBrush, c);

                            }

                            else
                            {
                                if (isSecond)
                                {
                                    Vector2 op = findFreePointBetween(nodes[i].center, nodes[j].center);
                                    nodes[i].DrawArcTo(nodes[j], op, penLines, g, withArrows);
                                }
                                else
                                {
                                    nodes[i].DrawLineTo(nodes[j], penLines, g, withArrows);

                                    Point c = (((nodes[i].center + nodes[j].center) / 2) - new Vector2(1, 0) * 10 * "22".Length - new Vector2(0, 1) * 20).point;

                                    g.DrawString(graph.weights.values[i, j] + "", new Font("Arial", 12), wBrush, c);
                                
                                }
                            }

                            
                        }
                    }
                }
            }
        }

        void calculatePowerOfMatrix(Matrix mx, List<Node> nodes)
        {
            double[,] matrix = mx.values;
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

        List<int> closed;
        List<int[]> edges;

        public static int lastN = 0;
        public static int last2N = 0;

        void PrimaStart()
        {
            foreach(var n in mainGraph.nodes)
            {
                n.visited = false;
            }
            foreach (var n in spanningGraph.nodes)
            {
                n.visible = false;
            }
            spanningGraph.nodes[0].visible = true;
            spanningGraph.matrix = new Matrix(mainGraph.matrix.n);

            closed = new List<int>();
            edges = new List<int[]>();
            primaFinished = false;

            closeNode(0);
            for (int i = 0; i < mainGraph.matrix.n; i++)
            {
                if(mainGraph.matrix.values[0, i] == 1)
                {
                    edges.Add(new int[] { 0, i });
                }
            }
            

            Invalidate();
        }

        public void PrimaNext()
        {
            if (!primaFinished)
            {
                int[,] matrix = mainGraph.matrix.IntValues;
                int n = mainGraph.matrix.n;

                int[] e = FindMinWeight(edges);
                spanningGraph.matrix.values[e[0], e[1]] = 1;
                spanningGraph.matrix.values[e[1], e[0]] = 1;

                spanningGraph.nodes[e[1]].visible = true;
                closeNode(e[1]);

                last2N = e[0];
                lastN = e[1];

                for (int i = 0; i < n; i++)
                {
                    if (matrix[e[1], i] == 1 && !closed.Contains(i))
                    {
                        edges.Add(new int[] { e[1], i });
                    }
                }

                edges.Remove(e);

                if (closed.Count == n)
                {
                    primaFinished = true;
                    writeMatrix(spanningGraph.matrix, tb_spanning);
                    lastN = 0;
                    last2N = 0;
                }

                Invalidate();
            }
        }

        int[] FindMinWeight(List<int[]> edges)
        {
            int n = mainGraph.matrix.n;
            int mi = 0;
            for (int i = 0; i < edges.Count; i++)
            {
                if (mainGraph.weights.values[edges[i][0], edges[i][1]] < mainGraph.weights.values[edges[mi][0], edges[mi][1]])
                {
                    mi = i;
                }
            }
            return edges[mi];
        }


        void closeNode(int index)
        {
            closed.Add(index);
            mainGraph.nodes[index].visited = true;
        }   

        private void btn_bfsNext_Click(object sender, EventArgs e)
        {
            PrimaNext();
        }

        private void btn_Again_Click(object sender, EventArgs e)
        {
            PrimaStart();
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

        public bool visible = true;

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
        }

        public void Draw(Pen pen, Graphics g)
        {
            if (visible)
            {
                Brush brush = Brushes.Pink;

                if (visited) brush = Brushes.LimeGreen;

                g.FillEllipse(brush, rect);
                g.DrawEllipse(pen, rect);
                g.DrawString(text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, (center - new Vector2(1, 0) * 4 * text.Length - new Vector2(0, 1) * 7).point);
            }
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
        public Matrix weights;

        public Graph(List<Node> nodes, Matrix matrix, Matrix weights)
        {
            this.nodes = nodes;
            this.matrix = matrix;
            this.weights = weights;
        }
    }
}