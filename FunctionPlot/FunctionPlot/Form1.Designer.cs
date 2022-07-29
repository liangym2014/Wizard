namespace FunctionPlot {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.input_restriction = new System.Windows.Forms.Label();
            this.error_label = new System.Windows.Forms.Label();
            this.submit_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.x_range = new System.Windows.Forms.Label();
            this.x_lower = new System.Windows.Forms.TextBox();
            this.x_upper = new System.Windows.Forms.TextBox();
            this.to_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BorderWidth = 10;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(32, 238);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1457, 529);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // input_restriction
            // 
            this.input_restriction.AutoSize = true;
            this.input_restriction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_restriction.Location = new System.Drawing.Point(28, 21);
            this.input_restriction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.input_restriction.Name = "input_restriction";
            this.input_restriction.Size = new System.Drawing.Size(889, 40);
            this.input_restriction.TabIndex = 1;
            this.input_restriction.Text = "Use x as variable. Support elementary arithmetic operations, sin(x), cos(x), tan(" +
    "x), log2(x). X-axis by default [-100,100].\r\nInput function:";
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(304, 208);
            this.error_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(15, 20);
            this.error_label.TabIndex = 2;
            this.error_label.Text = " ";
            // 
            // submit_btn
            // 
            this.submit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(32, 202);
            this.submit_btn.Margin = new System.Windows.Forms.Padding(4);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(100, 28);
            this.submit_btn.TabIndex = 3;
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_btn.Location = new System.Drawing.Point(157, 202);
            this.reset_btn.Margin = new System.Windows.Forms.Padding(4);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(100, 28);
            this.reset_btn.TabIndex = 4;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(32, 75);
            this.textBox.Margin = new System.Windows.Forms.Padding(4);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(1160, 115);
            this.textBox.TabIndex = 5;
            // 
            // x_range
            // 
            this.x_range.AutoSize = true;
            this.x_range.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_range.Location = new System.Drawing.Point(1213, 78);
            this.x_range.Name = "x_range";
            this.x_range.Size = new System.Drawing.Size(78, 20);
            this.x_range.TabIndex = 6;
            this.x_range.Text = "X Range:";
            // 
            // x_lower
            // 
            this.x_lower.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_lower.Location = new System.Drawing.Point(1217, 105);
            this.x_lower.Name = "x_lower";
            this.x_lower.Size = new System.Drawing.Size(100, 26);
            this.x_lower.TabIndex = 7;
            this.x_lower.Text = "-100";
            // 
            // x_upper
            // 
            this.x_upper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_upper.Location = new System.Drawing.Point(1358, 105);
            this.x_upper.Name = "x_upper";
            this.x_upper.Size = new System.Drawing.Size(100, 26);
            this.x_upper.TabIndex = 8;
            this.x_upper.Text = "100";
            // 
            // to_label
            // 
            this.to_label.AutoSize = true;
            this.to_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_label.Location = new System.Drawing.Point(1325, 108);
            this.to_label.Name = "to_label";
            this.to_label.Size = new System.Drawing.Size(23, 20);
            this.to_label.TabIndex = 9;
            this.to_label.Text = "to";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 780);
            this.Controls.Add(this.to_label);
            this.Controls.Add(this.x_upper);
            this.Controls.Add(this.x_lower);
            this.Controls.Add(this.x_range);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.input_restriction);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Plot Your Fucntion";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label input_restriction;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label x_range;
        private System.Windows.Forms.TextBox x_lower;
        private System.Windows.Forms.TextBox x_upper;
        private System.Windows.Forms.Label to_label;
    }
}

