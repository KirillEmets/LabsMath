using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        const int n1 = 9;
        const int n2 = 5;
        const int n3 = 0;
        const int n4 = 7;
        public Node centerNode;

        List<Node> nodes;
        int[,] matrix;

        bool withArrows = false;
        float drawScale = 1;
        Vector2 transformOffset = new Vector2(0, 0);
        Vector2 scaleOffset = new Vector2(0, 0);

        int nodeRadius = 30;
        int bigRadius = 150;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // початок програми
        {
            nodes = CreateNodes(10, new Vector2(500, 200), bigRadius); // створення вершин
            centerNode = nodes[0];
            matrix = GenerateMatrix(10); // створення матриці

            WriteMatrix(matrix, tbMatrix); // вивід матриць
            WriteMatrix(undirectedMatrix(matrix), tbMatrixUnDir);

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

            foreach (var n in nodes)
            {
                n.Draw(penNode, g); // відрисовка вершин
            }

            DrawLinesFromMatrix(matrix, nodes, penLines, g, withArrows); // відрисовка ліній і стрілок
        }

        List<Node> CreateNodes(int count, Vector2 circleCenter, int circleRadius)
        {
            // коло з вершиною в центрі

            List<Node> nodes = new List<Node>();
            nodes.Add(new Node(circleCenter.x, circleCenter.y, nodeRadius, 0));

            for (int i = 1; i < count; i++)
            {
                float angle = (float)(2 * Math.PI * i / (count - 1));
                Vector2 pos = circleCenter + circleRadius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                nodes.Add(new Node(pos.x, pos.y, nodeRadius, i));
            }

            return nodes;
        }

        int[,] GenerateMatrix(int n)
        {
            Random rand = new Random(n1 * 1000 + n2 * 100 + n3 * 10 + n4);

            int[,] m1 = randomMatrix(rand, n);
            int[,] m2 = randomMatrix(rand, n);

            int[,] T = new int[n, n]; 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    T[i, j] = m1[i, j] + m2[i, j];
                    T[i, j] = (int)Math.Floor(T[i,j]*(1.0 - n3*0.02 - n4*0.005 - 0.25));
                }
            }
            return T;
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

        int[,] undirectedMatrix(int[,] m)
        {
            int[,] res = m.Clone() as int[,];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    if (res[i, j] == 1)
                        res[j, i] = 1;
                }
            }

            return res;
        }

        void WriteMatrix(int[,] m, TextBox tb)
        {
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

        void DrawLinesFromMatrix(int[,] matrix, List<Node> nodes, Pen pen, Graphics g, bool withArrows)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] == 1)
                    {
                        if (i == j)
                        {
                            nodes[i].DrawCircle(centerNode.center, pen, g, withArrows);
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
                                float scale = isSecond ? 1.7f : 1.3f;
                                Vector2 op = obstacle.GetOffsetPointOnCircle(cp, scale);
                                nodes[i].DrawArcTo(nodes[j], op, pen, g, withArrows);
                            }

                            else
                            {
                                if (isSecond)
                                {
                                    Vector2 op = findFreePointBetween(nodes[i].center, nodes[j].center);
                                    nodes[i].DrawArcTo(nodes[j], op, pen, g, withArrows);
                                }
                                else
                                    nodes[i].DrawLineTo(nodes[j], pen, g, withArrows);
                            }
                        }
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

            foreach (var node in nodes)
            {
                if (node.ContainsPoint(t1))
                    isOk = false;
            }    
            
            if(!isOk)
                t1 = (cp - dir.turnOn((float)(1.57f)) * h);
            return t1;
        }

        private void cbArrows_CheckedChanged(object sender, EventArgs e)
        {
            withArrows = cbArrows.Checked;
            
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawScale = 1 + (sender as TrackBar).Value / 10f;
            transformOffset = new Vector2(2, 1) * (drawScale - 1) * -300;

            Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scaleOffset.x = -(hScrollBar1.Value - 50) * 10;
            Invalidate();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scaleOffset.y = -(vScrollBar1.Value - 50) * 10;
            Invalidate();
        }
    }

    public class Node
    {
        Vector2 position;
        float radius;
        public int index;
        public Rectangle rect;
        public Vector2 center
        {
            
            get { return position + new Vector2(rect.Width, rect.Height) / 2; }
        }
        

        public Node(float x, float y, int radius, int n)
        {        
            index = n;
            rect = new Rectangle((int)x, (int)y, 2 * radius, 2 * radius);
            this.radius = radius;
            position = Vector2.FromPoint(rect.Location);
        }

        public void Draw(Pen pen, Graphics g)
        {
            
            g.FillEllipse(Brushes.Pink, rect);
            g.DrawEllipse(pen, rect);
            g.DrawString((index+1) + "", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, (center - new Vector2(7, 7)).point);
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
                Point t2 = (Vector2.FromPoint(t1) + dir * h + dir.turnOn((float)(1.57f)) * h / 3).point;
                Point t3 = (Vector2.FromPoint(t1) + dir * h - dir.turnOn((float)(1.57f)) * h / 3).point;

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
                Point t2 = (Vector2.FromPoint(t1) + dir * h + dir.turnOn((float)(1.57f)) * h / 3).point;
                Point t3 = (Vector2.FromPoint(t1) + dir * h - dir.turnOn((float)(1.57f)) * h / 3).point;

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
                Point t2 = (Vector2.FromPoint(t1) + dir * h + dir.turnOn((float)(1.57f)) * h / 3).point;
                Point t3 = (Vector2.FromPoint(t1) + dir * h - dir.turnOn((float)(1.57f)) * h / 3).point;

                g.FillPolygon(Brushes.Black, new Point[] { t1, t2, t3 });
            }
        }

        public Vector2 isBetween(Node n1, Node n2)
        {
            Vector2 cp = (n2.center + n1.center) / 2;
            if((cp - center).length < radius)
                return cp;

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
}