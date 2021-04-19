
namespace WinFormsLibrary3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SlopeParameters = new System.Windows.Forms.GroupBox();
            this.SAngle = new System.Windows.Forms.TextBox();
            this.BHeight = new System.Windows.Forms.TextBox();
            this.SlopeAngle = new System.Windows.Forms.Label();
            this.BenchHeight = new System.Windows.Forms.Label();
            this.BWidth = new System.Windows.Forms.TextBox();
            this.BenchWidth = new System.Windows.Forms.Label();
            this.StrPt = new System.Windows.Forms.TextBox();
            this.StartPoint = new System.Windows.Forms.Label();
            this.TestParam = new System.Windows.Forms.GroupBox();
            this.num = new System.Windows.Forms.TextBox();
            this.number_of_slices = new System.Windows.Forms.Label();
            this.radTC = new System.Windows.Forms.TextBox();
            this.Radius = new System.Windows.Forms.Label();
            this.distT = new System.Windows.Forms.TextBox();
            this.dToe = new System.Windows.Forms.Label();
            this.distC = new System.Windows.Forms.TextBox();
            this.dCrest = new System.Windows.Forms.Label();
            this.SoilParameters = new System.Windows.Forms.GroupBox();
            this.phi = new System.Windows.Forms.TextBox();
            this.PhiD = new System.Windows.Forms.Label();
            this.coh = new System.Windows.Forms.TextBox();
            this.Cohes = new System.Windows.Forms.Label();
            this.Bden = new System.Windows.Forms.TextBox();
            this.BulkDenisty = new System.Windows.Forms.Label();
            this.DrawSlope = new System.Windows.Forms.Button();
            this.GetFOS = new System.Windows.Forms.Button();
            this.FOS = new System.Windows.Forms.TextBox();
            this.FOSmin = new System.Windows.Forms.Button();
            this.minFOS = new System.Windows.Forms.TextBox();
            this.DrawSlices = new System.Windows.Forms.Button();
            this.SlopeParameters.SuspendLayout();
            this.TestParam.SuspendLayout();
            this.SoilParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // SlopeParameters
            // 
            this.SlopeParameters.Controls.Add(this.SAngle);
            this.SlopeParameters.Controls.Add(this.BHeight);
            this.SlopeParameters.Controls.Add(this.SlopeAngle);
            this.SlopeParameters.Controls.Add(this.BenchHeight);
            this.SlopeParameters.Controls.Add(this.BWidth);
            this.SlopeParameters.Controls.Add(this.BenchWidth);
            this.SlopeParameters.Controls.Add(this.StrPt);
            this.SlopeParameters.Controls.Add(this.StartPoint);
            this.SlopeParameters.Location = new System.Drawing.Point(12, 10);
            this.SlopeParameters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SlopeParameters.Name = "SlopeParameters";
            this.SlopeParameters.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SlopeParameters.Size = new System.Drawing.Size(250, 195);
            this.SlopeParameters.TabIndex = 0;
            this.SlopeParameters.TabStop = false;
            this.SlopeParameters.Text = "Slope parameters";
            // 
            // SAngle
            // 
            this.SAngle.Location = new System.Drawing.Point(140, 158);
            this.SAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SAngle.Name = "SAngle";
            this.SAngle.Size = new System.Drawing.Size(97, 22);
            this.SAngle.TabIndex = 4;
            this.SAngle.Text = "45";
            // 
            // BHeight
            // 
            this.BHeight.Location = new System.Drawing.Point(140, 115);
            this.BHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BHeight.Name = "BHeight";
            this.BHeight.Size = new System.Drawing.Size(97, 22);
            this.BHeight.TabIndex = 3;
            this.BHeight.Text = "50";
            // 
            // SlopeAngle
            // 
            this.SlopeAngle.AutoSize = true;
            this.SlopeAngle.Location = new System.Drawing.Point(6, 160);
            this.SlopeAngle.Name = "SlopeAngle";
            this.SlopeAngle.Size = new System.Drawing.Size(121, 17);
            this.SlopeAngle.TabIndex = 19;
            this.SlopeAngle.Text = "Slope angle (deg)";
            // 
            // BenchHeight
            // 
            this.BenchHeight.AutoSize = true;
            this.BenchHeight.Location = new System.Drawing.Point(6, 115);
            this.BenchHeight.Name = "BenchHeight";
            this.BenchHeight.Size = new System.Drawing.Size(118, 17);
            this.BenchHeight.TabIndex = 18;
            this.BenchHeight.Text = "Bench Height (m)";
            // 
            // BWidth
            // 
            this.BWidth.Location = new System.Drawing.Point(140, 70);
            this.BWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BWidth.Name = "BWidth";
            this.BWidth.Size = new System.Drawing.Size(97, 22);
            this.BWidth.TabIndex = 2;
            this.BWidth.Text = "100";
            // 
            // BenchWidth
            // 
            this.BenchWidth.AutoSize = true;
            this.BenchWidth.Location = new System.Drawing.Point(6, 73);
            this.BenchWidth.Name = "BenchWidth";
            this.BenchWidth.Size = new System.Drawing.Size(113, 17);
            this.BenchWidth.TabIndex = 3;
            this.BenchWidth.Text = "Bench Width (m)";
            // 
            // StrPt
            // 
            this.StrPt.Location = new System.Drawing.Point(140, 30);
            this.StrPt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StrPt.Name = "StrPt";
            this.StrPt.Size = new System.Drawing.Size(97, 22);
            this.StrPt.TabIndex = 1;
            this.StrPt.Text = "0,0,0";
            // 
            // StartPoint
            // 
            this.StartPoint.AutoSize = true;
            this.StartPoint.Location = new System.Drawing.Point(6, 33);
            this.StartPoint.Name = "StartPoint";
            this.StartPoint.Size = new System.Drawing.Size(74, 17);
            this.StartPoint.TabIndex = 17;
            this.StartPoint.Text = "Start Point";
            // 
            // TestParam
            // 
            this.TestParam.Controls.Add(this.num);
            this.TestParam.Controls.Add(this.number_of_slices);
            this.TestParam.Controls.Add(this.radTC);
            this.TestParam.Controls.Add(this.Radius);
            this.TestParam.Controls.Add(this.distT);
            this.TestParam.Controls.Add(this.dToe);
            this.TestParam.Controls.Add(this.distC);
            this.TestParam.Controls.Add(this.dCrest);
            this.TestParam.Location = new System.Drawing.Point(693, 10);
            this.TestParam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TestParam.Name = "TestParam";
            this.TestParam.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TestParam.Size = new System.Drawing.Size(269, 195);
            this.TestParam.TabIndex = 2;
            this.TestParam.TabStop = false;
            this.TestParam.Text = "Test case parameters";
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(122, 158);
            this.num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(118, 22);
            this.num.TabIndex = 4;
            this.num.Text = "25";
            // 
            // number_of_slices
            // 
            this.number_of_slices.AutoSize = true;
            this.number_of_slices.Location = new System.Drawing.Point(6, 160);
            this.number_of_slices.Name = "number_of_slices";
            this.number_of_slices.Size = new System.Drawing.Size(83, 17);
            this.number_of_slices.TabIndex = 4;
            this.number_of_slices.Text = "no. of slices";
            // 
            // radTC
            // 
            this.radTC.Location = new System.Drawing.Point(122, 113);
            this.radTC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radTC.Name = "radTC";
            this.radTC.Size = new System.Drawing.Size(118, 22);
            this.radTC.TabIndex = 3;
            this.radTC.Text = "74.981";
            // 
            // Radius
            // 
            this.Radius.AutoSize = true;
            this.Radius.Location = new System.Drawing.Point(6, 115);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(77, 17);
            this.Radius.TabIndex = 6;
            this.Radius.Text = "Radius (m)";
            // 
            // distT
            // 
            this.distT.Location = new System.Drawing.Point(122, 70);
            this.distT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.distT.Name = "distT";
            this.distT.Size = new System.Drawing.Size(118, 22);
            this.distT.TabIndex = 2;
            this.distT.Text = "20";
            // 
            // dToe
            // 
            this.dToe.AutoSize = true;
            this.dToe.Location = new System.Drawing.Point(6, 73);
            this.dToe.Name = "dToe";
            this.dToe.Size = new System.Drawing.Size(71, 17);
            this.dToe.TabIndex = 4;
            this.dToe.Text = "D. toe (m)";
            // 
            // distC
            // 
            this.distC.Location = new System.Drawing.Point(122, 30);
            this.distC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.distC.Name = "distC";
            this.distC.Size = new System.Drawing.Size(118, 22);
            this.distC.TabIndex = 1;
            this.distC.Text = "40";
            // 
            // dCrest
            // 
            this.dCrest.AutoSize = true;
            this.dCrest.Location = new System.Drawing.Point(6, 33);
            this.dCrest.Name = "dCrest";
            this.dCrest.Size = new System.Drawing.Size(82, 17);
            this.dCrest.TabIndex = 2;
            this.dCrest.Text = "D. crest (m)";
            // 
            // SoilParameters
            // 
            this.SoilParameters.Controls.Add(this.phi);
            this.SoilParameters.Controls.Add(this.PhiD);
            this.SoilParameters.Controls.Add(this.coh);
            this.SoilParameters.Controls.Add(this.Cohes);
            this.SoilParameters.Controls.Add(this.Bden);
            this.SoilParameters.Controls.Add(this.BulkDenisty);
            this.SoilParameters.Location = new System.Drawing.Point(325, 10);
            this.SoilParameters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoilParameters.Name = "SoilParameters";
            this.SoilParameters.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoilParameters.Size = new System.Drawing.Size(299, 160);
            this.SoilParameters.TabIndex = 1;
            this.SoilParameters.TabStop = false;
            this.SoilParameters.Text = "Soil parameters";
            // 
            // phi
            // 
            this.phi.Location = new System.Drawing.Point(167, 113);
            this.phi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phi.Name = "phi";
            this.phi.Size = new System.Drawing.Size(104, 22);
            this.phi.TabIndex = 3;
            this.phi.Text = "30";
            // 
            // PhiD
            // 
            this.PhiD.AutoSize = true;
            this.PhiD.Location = new System.Drawing.Point(6, 115);
            this.PhiD.Name = "PhiD";
            this.PhiD.Size = new System.Drawing.Size(143, 17);
            this.PhiD.TabIndex = 22;
            this.PhiD.Text = "angle of friction (deg)";
            // 
            // coh
            // 
            this.coh.Location = new System.Drawing.Point(167, 70);
            this.coh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.coh.Name = "coh";
            this.coh.Size = new System.Drawing.Size(104, 22);
            this.coh.TabIndex = 2;
            this.coh.Text = "10000";
            // 
            // Cohes
            // 
            this.Cohes.AutoSize = true;
            this.Cohes.Location = new System.Drawing.Point(6, 73);
            this.Cohes.Name = "Cohes";
            this.Cohes.Size = new System.Drawing.Size(67, 17);
            this.Cohes.TabIndex = 21;
            this.Cohes.Text = "Cohesion";
            // 
            // Bden
            // 
            this.Bden.Location = new System.Drawing.Point(167, 30);
            this.Bden.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bden.Name = "Bden";
            this.Bden.Size = new System.Drawing.Size(104, 22);
            this.Bden.TabIndex = 1;
            this.Bden.Text = "20000";
            // 
            // BulkDenisty
            // 
            this.BulkDenisty.AutoSize = true;
            this.BulkDenisty.Location = new System.Drawing.Point(6, 33);
            this.BulkDenisty.Name = "BulkDenisty";
            this.BulkDenisty.Size = new System.Drawing.Size(84, 17);
            this.BulkDenisty.TabIndex = 20;
            this.BulkDenisty.Text = "Bulk density";
            // 
            // DrawSlope
            // 
            this.DrawSlope.Location = new System.Drawing.Point(18, 230);
            this.DrawSlope.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawSlope.Name = "DrawSlope";
            this.DrawSlope.Size = new System.Drawing.Size(94, 26);
            this.DrawSlope.TabIndex = 3;
            this.DrawSlope.Text = "Draw slope";
            this.DrawSlope.UseVisualStyleBackColor = true;
            this.DrawSlope.Click += new System.EventHandler(this.DrawSlope_Click);
            // 
            // GetFOS
            // 
            this.GetFOS.Location = new System.Drawing.Point(428, 229);
            this.GetFOS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetFOS.Name = "GetFOS";
            this.GetFOS.Size = new System.Drawing.Size(58, 27);
            this.GetFOS.TabIndex = 5;
            this.GetFOS.Text = "FOS = ";
            this.GetFOS.UseVisualStyleBackColor = true;
            this.GetFOS.Click += new System.EventHandler(this.GetFOS_Click);
            // 
            // FOS
            // 
            this.FOS.Location = new System.Drawing.Point(492, 232);
            this.FOS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FOS.Name = "FOS";
            this.FOS.ReadOnly = true;
            this.FOS.Size = new System.Drawing.Size(125, 22);
            this.FOS.TabIndex = 6;
            this.FOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FOSmin
            // 
            this.FOSmin.Location = new System.Drawing.Point(695, 230);
            this.FOSmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FOSmin.Name = "FOSmin";
            this.FOSmin.Size = new System.Drawing.Size(89, 26);
            this.FOSmin.TabIndex = 6;
            this.FOSmin.TabStop = false;
            this.FOSmin.Text = "min. FOS = ";
            this.FOSmin.UseVisualStyleBackColor = true;
            this.FOSmin.Click += new System.EventHandler(this.FOSmin_Click);
            // 
            // minFOS
            // 
            this.minFOS.Location = new System.Drawing.Point(790, 232);
            this.minFOS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minFOS.Name = "minFOS";
            this.minFOS.ReadOnly = true;
            this.minFOS.Size = new System.Drawing.Size(125, 22);
            this.minFOS.TabIndex = 8;
            this.minFOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DrawSlices
            // 
            this.DrawSlices.Location = new System.Drawing.Point(220, 230);
            this.DrawSlices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawSlices.Name = "DrawSlices";
            this.DrawSlices.Size = new System.Drawing.Size(106, 26);
            this.DrawSlices.TabIndex = 9;
            this.DrawSlices.Text = "Draw slices";
            this.DrawSlices.UseVisualStyleBackColor = true;
            this.DrawSlices.Click += new System.EventHandler(this.DrawSlices_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 323);
            this.Controls.Add(this.DrawSlices);
            this.Controls.Add(this.minFOS);
            this.Controls.Add(this.FOSmin);
            this.Controls.Add(this.FOS);
            this.Controls.Add(this.GetFOS);
            this.Controls.Add(this.DrawSlope);
            this.Controls.Add(this.SoilParameters);
            this.Controls.Add(this.TestParam);
            this.Controls.Add(this.SlopeParameters);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Input Form";
            this.SlopeParameters.ResumeLayout(false);
            this.SlopeParameters.PerformLayout();
            this.TestParam.ResumeLayout(false);
            this.TestParam.PerformLayout();
            this.SoilParameters.ResumeLayout(false);
            this.SoilParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SlopeParameters;
        private System.Windows.Forms.TextBox SAngle;
        private System.Windows.Forms.TextBox BHeight;
        private System.Windows.Forms.Label SlopeAngle;
        private System.Windows.Forms.Label BenchHeight;
        private System.Windows.Forms.TextBox BWidth;
        private System.Windows.Forms.Label BenchWidth;
        private System.Windows.Forms.TextBox StrPt;
        private System.Windows.Forms.Label StartPoint;
        private System.Windows.Forms.GroupBox TestParam;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.Label number_of_slices;
        private System.Windows.Forms.TextBox radTC;
        private System.Windows.Forms.Label Radius;
        private System.Windows.Forms.TextBox distT;
        private System.Windows.Forms.Label dToe;
        private System.Windows.Forms.TextBox distC;
        private System.Windows.Forms.Label dCrest;
        private System.Windows.Forms.GroupBox SoilParameters;
        private System.Windows.Forms.TextBox phi;
        private System.Windows.Forms.Label PhiD;
        private System.Windows.Forms.TextBox coh;
        private System.Windows.Forms.Label Cohes;
        private System.Windows.Forms.TextBox Bden;
        private System.Windows.Forms.Label BulkDenisty;
        private System.Windows.Forms.Button DrawSlope;
        private System.Windows.Forms.Button GetFOS;
        private System.Windows.Forms.TextBox FOS;
        private System.Windows.Forms.Button FOSmin;
        private System.Windows.Forms.TextBox minFOS;
        private System.Windows.Forms.Button DrawSlices;
    }
}