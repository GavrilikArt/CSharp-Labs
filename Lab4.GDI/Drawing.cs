using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab4.GDI
{
    static class Drawing {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd);
        static public void FillEllips(Color color, int x, int y, int width, int height) {
            SolidBrush brush= new SolidBrush(color);
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopDC);
            g.FillEllipse(brush, x, y, width, height);
            g.Dispose();
            ReleaseDC(desktopDC);
        }
        static public void FillRectangle(Color color, int x, int y, int width, int height) {
            SolidBrush brush = new SolidBrush(color);
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopDC);
            g.FillRectangle(brush, x, y, width, height);
            g.Dispose();
            ReleaseDC(desktopDC);
        }
        static public void DrawBezier(string color, int x, int y, int x1, int y1) {
            //SolidBrush brush = new SolidBrush(color);
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopDC);
            Pen skyBluePen = new Pen(Brushes.Blue);
            if (color == "red")
            {
                skyBluePen = new Pen(Brushes.Red);
            }
            else
            {
                skyBluePen = new Pen(Brushes.White);
            }
            skyBluePen.Width = 8.0F;
            skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawBezier(skyBluePen, new PointF(x, y), new PointF((x + x1) / 3, (y +y1) / 3), new PointF((x + x1) / 2, (y + y1) / 2), new PointF(x1, y1));
            skyBluePen.Dispose();
        }

        static public void DrawClosedCurve(Color color, params int[] coords)
        {
            //SolidBrush brush = new SolidBrush(color);
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopDC);
            Pen pen = new Pen(color, 3);
            Point[] curvePoints = new Point[coords.Length / 2];
            for (int i = 0; i < coords.Length; i += 2)
            {
                curvePoints[i / 2] = new Point(coords[i], coords[i + 1]);
            }
            g.DrawLines(pen, curvePoints);
            g.DrawClosedCurve(pen, curvePoints);
        }
    }
}