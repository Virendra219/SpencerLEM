using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace WinFormsLibrary3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly double pi = Math.PI;
        Point3d[] SlopePts = new Point3d[4]; // Slope corners: A=>Start point, B=>Crest, C=>Toe, D=>End Point,
        int n; // n = number of slices + 1,
        double BetaDeg, Beta, bwid, bhigh; // Beta=Anlge of Embankment wrt -ve x axis, BetaDeg=angle in degrees, bwid=bench width, bhigh=bench height,
        Point3d[,] testSlices; // 2D array of 3D point coordinates: 1st row for points on slope, 2nd for points on the curve
                               // testSlices[0,i] joins testSlices[1,i] to form boundary between i+1th and i+2th slice,
        double dist1, dist2; //dist1=distance of start point of test curve from crest, dist2=distance of end point of test curve on the base from the toe.
        double den, c, Phi, TPhi; // den=density of soil, c=cohesion, Phi=internal angle of friction, TPhi=tan(Phi) 

        public void DrawSlope_Click(object sender, EventArgs e)
        {
            this.Draw_Slope();
        }
        // Code for DrawSlope button. It'll take inputs for the slope parameters and draw the slope to AutoCAD.
        public void Draw_Slope()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            doc.LockDocument();

            string temp = this.StrPt.Text; // reading the start point coordinates from StrPt textbox.
            string[] t = temp.Split(','); // separating the x, y, z coordinates.
            double x = Convert.ToDouble(t[0]);
            double y = Convert.ToDouble(t[1]);
            double z = Convert.ToDouble(t[2]);

            SlopePts[0] = new Point3d(x, y, z); //storing coordinates of A.
            
            bwid = Convert.ToDouble(this.BWidth.Text); // reading the bench width from BWidth textbox.
            double x1 = x + bwid;
            SlopePts[1] = new Point3d(x1, y, z); //storing coordinates of B.
            
            bhigh = Convert.ToDouble(this.BHeight.Text); // reading the bench height from BHeight textbox.
            BetaDeg = Convert.ToDouble(this.SAngle.Text); // reading the angle of embankment in degrees from SAngle textbox.
            Beta = BetaDeg * pi / 180; // converting it to radians
            double tanSAng = Math.Tan(Beta);
            double x2 = x1 + bhigh / tanSAng;
            double y1 = y - bhigh;
            SlopePts[2] = new Point3d(x2, y1, z); //storing coordinates of C.

            double x3 = x2 + bwid;
            SlopePts[3] = new Point3d(x3, y1, z); //storing coordinates of D.

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    for (int i=0; i<3; i++)
                    {
                        Line ln = new Line(SlopePts[i], SlopePts[i + 1]);
                        ln.ColorIndex = 40;
                        btr.AppendEntity(ln);
                        trans.AddNewlyCreatedDBObject(ln, true);
                    }

                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    doc.Editor.WriteMessage("Error encountered: " + ex.Message);
                    trans.Abort();
                }
            }
        }

        // Code for DrawSlices button. It'll take inputs for the test case parameters and make a call to Curve_data, SlicesData functions
        // It'll then draw the test curve and the slices using these data to AutoCAD
        public void DrawSlices_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            dist1 = Convert.ToDouble(this.distC.Text); // reading dist1 from distC textbox.
            dist2 = Convert.ToDouble(this.distT.Text); //reading dist2 from distT textbox.
            double radius = Convert.ToDouble(this.radTC.Text); // reading radius of test circle from radTC textbox.
            n = Convert.ToInt32(num.Text) + 1; // num = number of test slices, n = number of boundaries.
            double[] curveData = this.Curve_data(dist1, dist2, radius); // getting data required to draw arc from Curve_data().

            double x0 = SlopePts[1].X - dist1;
            double y0 = SlopePts[1].Y;
            Point3d pt0 = new Point3d(x0, y0, SlopePts[0].Z); // point of curve on upper bench.

            double xn = curveData[4];
            double yn = curveData[5];
            Point3d ptn = new Point3d(xn, yn, SlopePts[0].Z); // end point of curve as per Curve_data function.
            Point3d centre = new Point3d(curveData[2], curveData[3], SlopePts[1].Z); //center of arc as per Curve_data function.
            Arc testC = new Arc()
            {
                Radius = radius,
                Center = centre,
                StartAngle = curveData[0],
                EndAngle = curveData[1],
                ColorIndex = 6, // 6=>magenta.
            };

            testSlices = new Point3d[2, n];
            testSlices = this.SlicesData(pt0, ptn, centre, radius); //getting Slice points coordinates.

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    btr.AppendEntity(testC);
                    trans.AddNewlyCreatedDBObject(testC, true);

                    LinetypeTable lineTypes = (LinetypeTable)trans.GetObject(db.LinetypeTableId, OpenMode.ForRead);
                    if (!lineTypes.Has("DASHEDX2")) 
                        db.LoadLineTypeFile("DASHEDX2", "acad.lin");
                    for (int i=0; i<n-1; i++)
                    {
                        Line ln = new Line(testSlices[0, i], testSlices[1, i]);

                        ln.ColorIndex = 7;
                        ln.Linetype = "DASHEDX2";
                        
                        btr.AppendEntity(ln);
                        trans.AddNewlyCreatedDBObject(ln, true);
                    }
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\Book2.csv"))
                    {
                        sw.WriteLine(string.Format(Convert.ToString(testSlices[0, n - 1]) + "," + Convert.ToString(testSlices[1, n - 1])));
                    }
                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    doc.Editor.WriteMessage("Error encountered: " + ex.Message);
                    trans.Abort();
                }
            }
        }
    
        //Code for GetFOS button. It'll take inputs for the soil parameters and make a call to SolveFOS function and print the output in the FOS textbox.
        private void GetFOS_Click(object sender, EventArgs e)
        {
            den = Convert.ToDouble(Bden.Text); // reading density of soil from Bden textbox.
            c = Convert.ToDouble(coh.Text); // reading cohhesion in soil from coh textbox.
            Phi = Convert.ToDouble(phi.Text) * pi / 180; // reading internal angle of friction of soil from phi textbox.
            TPhi = Math.Tan(Phi);
            FOS.Text = Convert.ToString(SolveFOS(testSlices)); //getting factor of safety of test curve from SolveFOS function.
        }

        // Function Curve_data inputs distance of test curve point on both benches from crest and toe resp. and the radius of test curve.
        // and returns the start angle, end angle, x, y coordinates of center and end point of the test arc.
        // Let E, F be the top and bottom points on test curve. 
        public double[] Curve_data(double d1, double d2, double rad)
        {
            double x = SlopePts[1].X;
            double x1 = x - d1;
            double y1 = SlopePts[1].Y; // x, y coordinates of E.

            double x2 = SlopePts[2].X;
            double x3 = x2 + d2;
            double y2 = SlopePts[2].Y; // x, y coordinates of F.

            // Calculations to calculate the centre(Cc) of the test arc.
            double midX = (x1 + x3) / 2;
            double midY = (y1 + y2) / 2; // x, y coordinates of mid point(M) of E and F

            double d = Math.Sqrt(Math.Pow(x3 - midX, 2) + Math.Pow(y2 - midY, 2)); //d=distance b/w F and M.
            double d3 = Math.Sqrt(Math.Pow(rad, 2) - Math.Pow(d, 2)); // d3=distaance b/w M and Cc.

            double ang1 = Math.Atan((y1 - y2) / (x3 - x1)); // angle of line EF wrt -ve x axis.
            double ang2 = pi / 2 - ang1; // angle of line MC wrt +ve x axis.

            double cenX = midX + d3 * Math.Cos(ang2);
            double cenY = midY + d3 * Math.Sin(ang2); //coordinates of Cc.

            double SAng = pi + Math.Atan((cenY - y1) / (cenX - x1)); //Start angle of test arc.
            double EAng, endX, endY; // End Angle, x, y, coordinates of end point(G) of test arc

            // calculations to find out the end point of test curve.
            // the point F need not necessarily be the end point of test curve
            // since the curve might cut the slanting portion(BC) of the slope too. So, cheching for that.
            // let H, I be the point on BC closest from Cc, lower point at which curve cuts the line BC.
            double dcl = Math.Sin(Beta) * (cenX - x) + Math.Cos(Beta) * (cenY - y1); //dcl=distance b/w Cc and H.
            double dp = Math.Sqrt(Math.Pow(rad, 2) - Math.Pow(dcl, 2)); // dp= distance b/w H and I.
            double del = pi / 2 - Beta; //del=angle of CH wrt +ve x axis;
            double xcl = cenX - dcl * Math.Cos(del);
            double ycl = cenY - dcl * Math.Sin(del); // xcl, ycl are the coordinates of H.

            double xp = xcl + dp * Math.Cos(Beta); // x coordinate of I.
            if (xp <= x2) // if (x coordinate of I is lesser than or equal that of C(Toe) then end point of curve = I and EAng = anticlockwise angle of CI wrt +ve x axis
            {
                endX = xp;
                endY = ycl - dp * Math.Sin(Beta);
                if (cenX > endX)
                    EAng = pi + Math.Atan((cenY - endY) / (cenX - endX));
                else
                    EAng = 2 * pi - Math.Atan((cenY - endY) / (endX - cenX));
            }
            else // else end point of curve = F and EAng = anticlockwise angle of CF wrt +ve x axis.
            {
                endX = x3;
                endY = y2;
                if (cenX > endX)
                    EAng = pi + Math.Atan((cenY - endY) / (cenX - endX));
                else
                    EAng = 2 * pi - Math.Atan((cenY - endY) / (endX - cenX));
            }
            double[] curveData = new double[6]; // array object to return the required, calculated data.
            curveData[0] = SAng;
            curveData[1] = EAng;
            curveData[2] = cenX;
            curveData[3] = cenY;
            curveData[4] = endX;
            curveData[5] = endY;

            return curveData;
        }

        // Function SlicesData takes the start point, end point, center and radius of test arc
        // and returns a 2d array of 3d points which are coordinates of end points of boundary b/w adjacent slices.
        public Point3d[,] SlicesData(Point3d pt0, Point3d ptn, Point3d centre, double radius)
        {
            double[,] slicesData = new double[3,n]; // 1st row for x coordinates of points on slope, 2nd row for y coordinates of points on slope.
                                                    // 3rd row for x coordinates of points on curve, 4th row for y coordinates of points on curve.
            slicesData[0, 0] = pt0.X;
            slicesData[1, 0] = pt0.Y; // x, y coordinates of 1st point on slope.
            slicesData[2, 0] = pt0.Y; // x, y coordinates of 1st point on the curve.
            double dx = (ptn.X - pt0.X) / (n-1);
            double x1 = SlopePts[1].X;
            double y1 = SlopePts[1].Y; 
            double x2 = SlopePts[2].X;
            double y2 = SlopePts[2].Y;
            double z = SlopePts[0].Z;

            Point3d[,] sliceCo = new Point3d[2, n]; //object to be returned.

            for (int i=1; i<n; i++)
            {
                slicesData[0, i] = slicesData[0, i - 1] + dx; // storing x coordinates of i+1th point on the slope and the curve,
                if (slicesData[0, i] <= x1) // checking conditions for position of i+1th point on slope and storing y coordinates.
                    slicesData[1, i] = y1;
                else if (slicesData[0, i] >= x2)
                    slicesData[1, i] = y2;
                else
                    slicesData[1, i] = y1 - (slicesData[0, i] - x1) * Math.Tan(Beta);
                // storing y coordinates of i+1th point on curve.
                slicesData[2, i] = centre.Y - Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(slicesData[0, i] - centre.X, 2));
                 
                sliceCo[0, i] = new Point3d(slicesData[0, i], slicesData[1, i], z); //storing the i+1th point on slope.
                sliceCo[1, i] = new Point3d(slicesData[0, i], slicesData[2, i], z); //storing the i+1th point on the curve.
            }
            sliceCo[0, 0] = new Point3d(slicesData[0, 0], slicesData[1, 0], z); //1st point on slope.
            sliceCo[1, 0] = new Point3d(slicesData[0, 0], slicesData[2, 0], z); //1st point on curve.

            return sliceCo;
        }

        // Function SolveFOS inputs coordinates of end points of boundaries b/w slices
        // and returns the Factor of safety of the curve.
        public double SolveFOS(Point3d[,] sliceCo)
        {
            double[] Ws = new double[n - 1]; // Ws[i] = Weight of ith slice.
            double[] As = new double[n - 1]; // As[i] = base angle of ith slice.
            double[] WSs = new double[n - 1]; // WSs[i] = Ws[i] * Sin(As[i]) => W * SinA for each  slice.
            double[] WCs = new double[n - 1]; // WCs[i] = Ws[i] * Cos(As[i]) => W * CosA for each  slice.
            double[] cbSAs = new double[n - 1]; // cohesive force due to ith slice.

            double dx = sliceCo[0, 1].X - sliceCo[0, 0].X; //dx = width of slice.
            double TStress = 0, TStrength = 0; // TStress = total stress along the test surface.
                                               // TStrength = total strength along the test surface.

            for (int i = 0; i < n - 1; i++)
            {
                Ws[i] = (sliceCo[0, i + 1].Y + sliceCo[0, i].Y - sliceCo[1, i + 1].Y - sliceCo[1, i].Y) / 2 * dx * den;
                As[i] = -1 * Math.Atan((sliceCo[1, i + 1].Y - sliceCo[1, i].Y) / dx); //-1 to store the angle wrt +ve x axis.
                WSs[i] = Ws[i] * Math.Sin(As[i]);
                WCs[i] = Ws[i] * Math.Cos(As[i]);
                cbSAs[i] = c * dx / Math.Cos(As[i]);
                
                TStress += WSs[i];
                TStrength += (WCs[i] * TPhi + cbSAs[i]);
            }
            double F0 = Math.Abs(TStrength / TStress); // F0 = factor of safety without considering inter slice forces.
            int FSize = Convert.ToInt32(35*F0); // size of array to store all values of fos to be iterated with gradient 0.01
            int TSize = Convert.ToInt32(BetaDeg); // size of array to store all values of theta to be iterated with gradient 1 degree.
            //int TSize = 45;
            double[] theta = new double[TSize]; // array to store all fos for iteration.
            double[] FoS = new double[FSize]; // array to store all theta for iteration. 
            FoS[0] = F0;

            for (int i = 1; i < FSize; i++)
            {
                FoS[i] = FoS[i - 1] + 0.01;
            }
            double sumQ = 0, Qmin = 100000000000; 
            double[] fosTf = new double[TSize]; // ith fosTf stores fos for which sumQ is minimum for ith theta.
            for (int i = 0; i < theta.Length; i++)
            {
                theta[i] = i * pi / 180;
                for (int j = 0; j < FoS.Length; j++)
                {
                    for (int k = 0; k < n - 1; k++)
                    {
                        sumQ += (cbSAs[k] / FoS[j] + WCs[k] * TPhi / FoS[j] - WSs[k]) / (Math.Cos(As[k] - theta[i]) * (1 + Math.Tan(As[k] - theta[i]) * TPhi / FoS[j]));
                    }
                    if (Math.Abs(sumQ) < Qmin)
                    {
                        fosTf[i] = FoS[j];
                        Qmin = Math.Abs(sumQ);
                    }
                    sumQ = 0;
                }
                Qmin = 100000000000;
            }
            double sumQm = 0, Qmmin = 100000000000;
            double[] fosTm = new double[TSize]; // ith fosTm stores fos for which sumQ (moment) is minimum for ith theta
            for (int i = 0; i < theta.Length; i++)
            {
                for (int j = 0; j < FoS.Length; j++)
                {
                    for (int k = 0; k < n - 1; k++)
                    {
                        sumQm += (cbSAs[k] / FoS[j] + (WCs[k]) * TPhi / FoS[j] - WSs[k]) / (1 + Math.Tan(As[k] - theta[i]) * TPhi / FoS[j]);
                    }
                    if (Math.Abs(sumQm) < Qmmin)
                    {
                        fosTm[i] = FoS[j];
                        Qmmin = Math.Abs(sumQm);
                    }
                    sumQm = 0;
                }
                Qmmin = 100000000000;
            }
            double diff = Math.Abs(fosTm[0] - fosTf[0]);
            double F = (fosTf[0] + fosTm[0]) / 2;
            // finding fos for which both Q and Qm are minimum.
            for (int i = 1; i < TSize; i++)
            {
                double temp = Math.Abs(fosTm[i] - fosTf[i]);
                if (temp < diff)
                {
                    F = (fosTm[i] + fosTf[i]) / 2;
                    diff = temp;
                }
            }
            return F;
        }

        // Code for FOSmin button which finds out the curve with minimum fos and displays it on AutoCAD also displaying the minimum FOS in minFOS textbox.
        private void FOSmin_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            Point3d centerW = new Point3d();
            double SAng = 0, EAng = 0, RadiusW = 0;
            double Fmin = 100;

            double[] d1s = new double[20]; // array to store values of d1s to be iterated over.
            double[] d2s = new double[20]; // array to store values of d2s to be iterated over.

            d1s[0] = 4;
            d2s[0] = 0;
            for (int i = 1; i < d1s.Length; i++)
            {
                d1s[i] = d1s[i - 1] + 4;
                d2s[i] = d2s[i - 1] + 2;
            }
            for (int i = 0; i < d1s.Length; i++)
            {
                for (int j = 0; j < d2s.Length; j++)
                {
                    Point3d pt0 = new Point3d(SlopePts[1].X - d1s[i], SlopePts[0].Y, SlopePts[0].Z); // point E mentioned above.

                    double rad = Math.Sqrt(Math.Pow(bhigh, 2) + Math.Pow(SlopePts[2].X + d2s[j] - pt0.X, 2)) / 2 + 5;
                    for (int k = 0; k < 10; k++)
                    {
                        rad += 5; //iterating over radius of test curves.
                        double[] testCData = Curve_data(d1s[i], d2s[j], rad); // getting the test curve data from Curve_data function. 
                        Point3d center = new Point3d(testCData[2], testCData[3], SlopePts[0].Z);
                        Point3d ptn = new Point3d(testCData[4], testCData[5], SlopePts[0].Z);
                        Point3d[,] sliceCo = SlicesData(pt0, ptn, center, rad); // getting the slice data from the SlicesData function.
                        double F = SolveFOS(sliceCo); // getting the fos for the current test curve.
                        if (F < Fmin) // storing curve data with minimum fos.
                        {
                            Fmin = F;
                            SAng = testCData[0];
                            EAng = testCData[1];
                            RadiusW = rad;
                            centerW = center;
                        }
                    }
                }
            }
            minFOS.Text = Convert.ToString(Fmin); //displaying the minimum fos in the minFOS textbox.
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Arc Weakest_Arc = new Arc() //drawing the curve with min fos.
                    {
                        Center = centerW,
                        StartAngle = SAng,
                        EndAngle = EAng,
                        Radius = RadiusW,
                        ColorIndex = 1,
                        LineWeight = LineWeight.LineWeight211,
                        Thickness = 1,
                    };

                    btr.AppendEntity(Weakest_Arc);
                    trans.AddNewlyCreatedDBObject(Weakest_Arc, true);
                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    doc.Editor.WriteMessage("Error encountered: " + ex.Message);
                    trans.Abort();
                }
            }
        }
    }
}
