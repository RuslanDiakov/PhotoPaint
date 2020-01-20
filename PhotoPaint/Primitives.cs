using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhotoPaint
{
    [Serializable]
    [XmlInclude(typeof(Ellipse))]
    class Primitives
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

        public class Ellipse : Primitives
        {
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
                g.DrawEllipse(pen, r);/////////////////////--------------!!!!
            }
        }

        public class DrawingModel
        {
            List<Primitives> allDraw;
          
            private DrawingModel()
            {
                allDraw = new List<Primitives>();
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
        }




        // Переменные

        public int startX { get; set; }
        public int endX { get; set; }
        public int startY { get; set; }
        public int endY { get; set; }
        [XmlIgnore]
        public Pen pen { get; set; }
        [XmlIgnore]
        public Brush brush { get; set; }

        [XmlIgnore]
        // Заливка фигуры градиентом
        public GradientType BrushType { get; set; } = GradientType.Transparent;
        public Color lgbFrom = Color.AliceBlue;
        public Color lgbTo = Color.Red;
        public float lgbPos = 0;

        // Заливка фигуры 1 цветом
        public Color solidG = Color.Red;

        // Заливка фигуры узором
        public HatchStyle hatchStyle;
        public Color hatchColor;

        // Заливка фигуры картинкой
        public string TextureBmp = "C:\\Users\\Core00\\Documents\\Untitled.png";
    }
}
