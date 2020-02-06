namespace Yazılım_Yapımı_Projesi
{
    partial class FormIstatistik
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram3D xyDiagram3D1 = new DevExpress.XtraCharts.XYDiagram3D();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBar3DSeriesView sideBySideBar3DSeriesView1 = new DevExpress.XtraCharts.SideBySideBar3DSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIstatistik));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.chartIstatistik = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartIstatistik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis Dark";
            // 
            // chartIstatistik
            // 
            this.chartIstatistik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.chartIstatistik.DataBindings = null;
            xyDiagram3D1.RotationMatrixSerializable = "0.766044443118978;-0.219846310392954;0.604022773555054;0;0;0.939692620785908;0.34" +
    "2020143325669;0;-0.642787609686539;-0.262002630229385;0.719846310392954;0;0;0;0;" +
    "1";
            this.chartIstatistik.Diagram = xyDiagram3D1;
            this.chartIstatistik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartIstatistik.Legend.Name = "Default Legend";
            this.chartIstatistik.Location = new System.Drawing.Point(0, 0);
            this.chartIstatistik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartIstatistik.Name = "chartIstatistik";
            this.chartIstatistik.PaletteName = "Green";
            series1.Name = "Seviye-Ogrenilenler";
            series1.View = sideBySideBar3DSeriesView1;
            this.chartIstatistik.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartIstatistik.Size = new System.Drawing.Size(618, 373);
            this.chartIstatistik.TabIndex = 0;
            this.chartIstatistik.Click += new System.EventHandler(this.chartIstatistik_Click);
            // 
            // FormIstatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 373);
            this.Controls.Add(this.chartIstatistik);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormIstatistik";
            this.Text = "FormIstatistik";
            this.Load += new System.EventHandler(this.FormIstatistik_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIstatistik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraCharts.ChartControl chartIstatistik;
    }
}