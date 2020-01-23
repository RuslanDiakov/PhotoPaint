using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PhotoPaint
{
    [Serializable]
    [XmlInclude(typeof(Ellipse))]
    public class Primitives
    {

        [XmlElement("PenColor")]
        public int PenColor
        {
            get { return pen.Color.ToArgb(); }
            set
            {
                if (pen == null)
                {
                    pen = new Pen(Color.Gray);
                }
                pen.Color = Color.FromArgb(value);
            }
        }

        [XmlElement("PenWidth")]
        public float PenWidth
        {
            get { return pen.Width; }
            set
            {
                if (pen == null)
                {
                    pen = new Pen(Color.Gray);
                }
                pen.Width = value;
            }
        }

        public virtual void Paint(Graphics g)
        {

        }

        public override string ToString()
        {
            try
            {
                return $"Слой";
            }
            catch
            {
                return "Слой";
            }
        }

        /// <summary>
        /// Елипс
        /// </summary>
        public class Ellipse : Primitives
        {
            public override string ToString()
            {
                return $"Фигура: Элипс | Цвет обводки: {pen.Color.ToString()} | Толщина: {pen.Width.ToString()}" +
                $" | Заливка: {solidG}";
            }

            public override void Paint(Graphics g)
            {
                if (endX - startX == 0 || endY - startY == 0) return;
                Rectangle r = new Rectangle(startX, startY, endX - startX, endY - startY);

                switch (BrushType)
                {
                    case GradientType.Line:
                        LinearGradientBrush lgb = new LinearGradientBrush(r, lgbFrom, lgbTo, lgbPos, true);
                        g.FillEllipse(lgb, r);
                        break;
                    case GradientType.Solid:
                        SolidBrush solid = new SolidBrush(solidG);
                        g.FillEllipse(solid, r);
                        break;
                    case GradientType.Hatch:
                        HatchBrush hatchBrush = new HatchBrush(hatchStyle, hatchColor);
                        g.FillEllipse(hatchBrush, r);
                        break;
                    case GradientType.Image:
                        TextureBrush textureBrush = new TextureBrush(new Bitmap(TextureBmp));
                        g.FillEllipse(textureBrush, r);

                        break;
                }
                g.DrawEllipse(pen, r);
            }
        }

        /// <summary>
        /// Прямоугольник
        /// </summary>
        public class Rectangle_figure : Primitives
        {
            public override string ToString()
            {
                return $"Фигура: Прямоугольник | Цвет обводки: {pen.Color.ToString()} | Толщина: {pen.Width.ToString()}" +
                $" | Заливка: {solidG}";
            }

            public override void Paint(Graphics g)
            {
                if (endX - startX == 0 || endY - startY == 0) return;
                Rectangle r = new Rectangle(startX, startY, endX - startX, endY - startY);

                switch (BrushType)
                {
                    case GradientType.Line:
                        LinearGradientBrush lgb = new LinearGradientBrush(r, lgbFrom, lgbTo, lgbPos, true);
                        g.FillRectangle(lgb, r);
                        break;
                    case GradientType.Solid:
                        SolidBrush solid = new SolidBrush(solidG);
                        g.FillRectangle(solid, r);
                        break;
                    case GradientType.Hatch:
                        HatchBrush hatchBrush = new HatchBrush(hatchStyle, hatchColor);
                        g.FillRectangle(hatchBrush, r);
                        break;
                    case GradientType.Image:
                        TextureBrush textureBrush = new TextureBrush(new Bitmap(TextureBmp));
                        g.FillRectangle(textureBrush, r);

                        break;
                }
                g.DrawRectangle(pen, r);
            }
        }

        /// <summary>
        /// Линия
        /// </summary>
        public class Line_figure : Primitives
        {
            public override string ToString()
            {
                return $"Фигура: Линия | Цвет обводки: {pen.Color.ToString()} | Толщина: {pen.Width.ToString()}" +
                $" | Заливка: {solidG}";
            }
            public override void Paint(Graphics g)
            {
                //  if (endX - startX == 0 || endY - startY == 0) return;                               
                g.DrawLine(pen, startX, startY, endX, endY);
            }
        }

        /// <summary>
        /// Текст
        /// </summary>
        public class Text_figure : Primitives
        {
            public override string ToString()
            {
                return $"Текст | {newText}";
            }
            public override void Paint(Graphics g)
            {
                PointF drawPoint = new PointF(startX, startY);
                Rectangle r = new Rectangle(startX, startY, endX - startX, endY - startY);
                SolidBrush solid = new SolidBrush(solidG);

                switch (BrushType)
                {
                    case GradientType.Line:
                        /* try
                         {
                             LinearGradientBrush lgb = new LinearGradientBrush(r, lgbFrom, lgbTo, lgbPos, true);
                             g.DrawString(newText, newFont, lgb, drawPoint);
                             break;
                         }
                         catch (Exception)
                         {
                             MessageBox.Show("Ошибка при заполнении градиентом\n" +
                                 "Возможное решение:\n" +
                                 "Переместите курсок на конец текста", "Error");
                             break;
                         }*/

                        LinearGradientBrush lgb = new LinearGradientBrush(r, lgbFrom, lgbTo, lgbPos, true);
                        g.DrawString(newText, newFont, lgb, drawPoint);
                        break;

                    case GradientType.Solid:
                        g.DrawString(newText, newFont, solid, drawPoint);
                        break;
                    case GradientType.Hatch:
                        HatchBrush hatchBrush = new HatchBrush(hatchStyle, hatchColor);
                        g.DrawString(newText, newFont, hatchBrush, drawPoint);
                        break;
                    case GradientType.Image:
                        TextureBrush textureBrush = new TextureBrush(new Bitmap(TextureBmp));
                        g.DrawString(newText, newFont, textureBrush, drawPoint);

                        break;
                    default:
                        g.DrawString(newText, newFont, solid, drawPoint);
                        break;

                }

                //SolidBrush solid = new SolidBrush(solidG);
                //HatchBrush hatchBrush = new HatchBrush(hatchStyle, hatchColor);
                //g.DrawString(newText, newFont, hatchBrush, drawPoint);
            }
        }

        /// <summary>
        /// Точка / перо
        /// </summary>
        public class Point_figure : Primitives
        {
            public override void Paint(Graphics g)
            {
                Point point1 = new Point(startX, startY);
                Point point2 = new Point(endX, endY);
                g.DrawLine(pen, point1, point2);
                point1.X = point2.X;
                point1.Y = point2.Y;
            }
        }

        /// <summary>
        /// Картинка
        /// </summary>
        public class Img_figure : Primitives
        {
            public override string ToString()
            {
                return $"Изображение | Размеры: {LoadTempImg.Size}";
            }

            public override void Paint(Graphics g)
            {
                PointF point = new PointF(endX, endY);
                g.DrawImage(LoadTempImg, point);
            }
        }




        public class DrawingModel
        {
            public List<Primitives> allDraw;

            List<Primitives> undoElement;

            private DrawingModel()
            {
                allDraw = new List<Primitives>();
                undoElement = new List<Primitives>();
            }

            private static DrawingModel instance;

            public static DrawingModel getInstance()
            {
                if (instance == null)
                {
                    instance = new DrawingModel();
                }
                return instance;
            }

            public void Paint(Graphics g)
            {
                foreach (var p in allDraw)
                {
                    p.Paint(g);
                }
            }

            public Primitives GetLast()
            {
                try
                {
                    return allDraw.Last();
                }
                catch (Exception)
                {
                    return null;
                }

            }

            public List<Primitives> Getall()
            {
                try
                {
                    return allDraw;
                }
                catch (Exception)
                {
                    return null;
                }

            }

            /// <summary>
            /// Создание Елипса
            /// </summary>
            /// <param name="frm">Главная форма</param>
            public void CreateEllipse(Main frm)
            {
                Ellipse r1 = new Ellipse();
                r1.startX = frm.startX; r1.startY = frm.startY;
                r1.endX = frm.endX; r1.endY = frm.endY;
                r1.pen = (Pen)frm.pen.Clone();
                r1.BrushType = frm.BrashType;

                r1.lgbFrom = frm.lgbFrom;
                r1.lgbTo = frm.lgbTo;
                r1.lgbPos = frm.lgbPos;
                r1.solidG = frm.solidG;

                r1.hatchColor = frm.hatchColor;
                r1.hatchStyle = frm.hatchStyle;
                r1.TextureBmp = frm.TextureBmp;
                allDraw.Add(r1);
            }

            /// <summary>
            /// Создание прямоугольника
            /// </summary>
            /// <param name="frm">Главная форма</param>
            public void CreateRectangle(Main frm)
            {
                Rectangle_figure r1 = new Rectangle_figure();
                r1.startX = frm.startX; r1.startY = frm.startY;
                r1.endX = frm.endX; r1.endY = frm.endY;
                r1.pen = (Pen)frm.pen.Clone();
                r1.BrushType = frm.BrashType;

                r1.lgbFrom = frm.lgbFrom;
                r1.lgbTo = frm.lgbTo;
                r1.lgbPos = frm.lgbPos;
                r1.solidG = frm.solidG;

                r1.hatchColor = frm.hatchColor;
                r1.hatchStyle = frm.hatchStyle;
                r1.TextureBmp = frm.TextureBmp;

                allDraw.Add(r1);
            }

            /// <summary>
            /// Создание линии
            /// </summary>
            /// <param name="frm">Главная форма</param>
            public void CreateLine(Main frm)
            {
                Line_figure r1 = new Line_figure();
                r1.startX = frm.startX; r1.startY = frm.startY;
                r1.endX = frm.endX; r1.endY = frm.endY;
                r1.pen = (Pen)frm.pen.Clone();
                r1.BrushType = frm.BrashType;

                allDraw.Add(r1);
            }

            /// <summary>
            /// Создание точки
            /// </summary>
            /// <param name="frm"></param>
            public void CreatePoint(Main frm)
            {
                Point_figure r1 = new Point_figure();
                r1.startX = frm.startX; r1.startY = frm.startY;
                r1.endX = frm.endX; r1.endY = frm.endY;
                r1.pen = (Pen)frm.pen.Clone();
                r1.BrushType = frm.BrashType;

                allDraw.Add(r1);
            }

            /// <summary>
            /// Создание текста
            /// </summary>
            /// <param name="frm"></param>
            public void CreateText(Main frm)
            {
                Text_figure r1 = new Text_figure();
                r1.startX = frm.startX; r1.startY = frm.startY;
                r1.endX = frm.endX; r1.endY = frm.endY;
                r1.pen = (Pen)frm.pen.Clone();
                r1.BrushType = frm.BrashType;

                r1.lgbFrom = frm.lgbFrom;
                r1.lgbTo = frm.lgbTo;
                r1.lgbPos = frm.lgbPos;
                r1.solidG = frm.solidG;

                r1.hatchColor = frm.hatchColor;
                r1.hatchStyle = frm.hatchStyle;
                r1.TextureBmp = frm.TextureBmp;

                r1.newText = frm.newText;
                r1.newFont = frm.newFont;

                allDraw.Add(r1);
            }

            /// <summary>
            /// Создание картинки DragDrop
            /// </summary>
            /// <param name="frm"></param>
            public void CreateImg(Main frm)
            {
                Img_figure r1 = new Img_figure();
                r1.endX = frm.endX; r1.endY = frm.endY;
                r1.LoadTempImg = frm.LoadTempImg;
                allDraw.Add(r1);
            }

            public void saveToXml(string filename)
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    XmlSerializer formater = new XmlSerializer(typeof(List<Primitives>));
                    formater.Serialize(fs, allDraw);
                }
            }

            public void loadToXml(string filename)
            {
                allDraw.Clear();
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer formater = new XmlSerializer(typeof(List<Primitives>));
                    allDraw = (List<Primitives>)formater.Deserialize(fs);
                }
            }

            public bool canUndo()
            {
                if (allDraw.Count > 0) return true;
                return false;
            }

            public void undo()
            {
                allDraw.RemoveAt(allDraw.Count - 1);
            }

            Main form = new Main();

            public void delete(int i)
            {
                allDraw.RemoveAt(i);
            }

            public bool canRedo()
            {
                if (allDraw.Count > 0) return true;
                return false;
            }

            public void redo()
            {
                // allDraw.Add(allDraw.Last<Primitives>);
            }

            #region Слои

            public void Top()
            {
                if (allDraw.Count > 0)
                {
                    allDraw.Add(undoElement[undoElement.Count - 1]);
                }
            }

            public List<Primitives> clone()
            {
                List<Primitives> primitivesList = new List<Primitives>();
                for (int i = 0; i < allDraw.Count; i++)
                {
                    primitivesList.Add(allDraw[i]);
                }
                return primitivesList;
            }

            public void undo2()
            {
                if (allDraw.Count > 0)
                {
                    undoElement.Add(allDraw[allDraw.Count - 1]);
                    allDraw.RemoveAt(allDraw.Count - 1);
                }
            }


            #endregion


        }




        // Переменные

        public int startX { get; set; }
        public int endX { get; set; }
        public int startY { get; set; }
        public int endY { get; set; }
        [XmlIgnore]
        public Pen pen { get; set; }
        [XmlIgnore]
        public Brush brush { get; set; } = new SolidBrush(Color.Black);
        public Font newFont { get; set; } = new Font("Arial", 20);
        public String newText { get; set; } = "Sample Text";

        [XmlIgnore]
        // Заливка фигуры градиентом
        public GradientType BrushType { get; set; } = GradientType.Transparent;
        public Color lgbFrom = Color.AliceBlue;
        public Color lgbTo = Color.Red;
        public float lgbPos = 0;

        Bitmap LoadTempImg;

        // Заливка фигуры 1 цветом
        public Color solidG = Color.Red;

        // Заливка фигуры узором
        public HatchStyle hatchStyle;
        public Color hatchColor;

        // Заливка фигуры картинкой
        public string TextureBmp;
    }
}
