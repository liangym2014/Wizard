using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FunctionPlot {
    public partial class Form1 : Form {
        private Plotter plt;
        public Form1() {
            InitializeComponent();
            plt = new Plotter();
        }

        private void submit_btn_Click(object sender, EventArgs e) {
            error_label.Text = " ";
            chart1.Series[0].Points.Clear();
            plt.clear_data();

            string error_message = plt.validate_input(textBox.Text, x_lower.Text, x_upper.Text);
            if (error_message.Length > 0) {
                error_label.Text = "Error:  " + error_message;
                return;
            }

            //print_postorder(plt.get_postorder());

            foreach (var point in plt.get_xys())
                chart1.Series[0].Points.AddXY(point.Key, point.Value);
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;  // set chart type
        }

        private void reset_btn_Click(object sender, EventArgs e) {
            textBox.Text = "";
            x_lower.Text = "-100";
            x_upper.Text = "100";
            error_label.Text = " ";
            chart1.Series[0].Points.Clear();
            plt.clear_data();
        }

        /// <summary>
        /// Output the post order list. Used for debug only.
        /// </summary>
        private void print_postorder(List<string> p) {
            foreach (var ele in p)
                Debug.Write(ele + ',');
            Debug.Write("\n\n");
        }
    }
}
