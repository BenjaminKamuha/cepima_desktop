using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

public class LineChart : UserControl
{
    private Chart chart;
    public LineChart()
    {
        chart = new Chart();
        chart.Dock = DockStyle.Fill;
        ChartArea area = new ChartArea();
        area.AxisX.MajorGrid.Enabled = false;
        area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        chart.ChartAreas.Add(area);
        this.Controls.Add(chart);
    }

    //Afficher les valeurs simple
    public void SetData(string[] labels, double[] values)
    {
        chart.Series.Clear();
        Series serie = new Series();
        serie.ChartType = SeriesChartType.Line;
        serie.BorderWidth = 4;
        serie.IsValueShownAsLabel = true;

        for (int i = 0; i < labels.Length; i++)
        {
            serie.Points.AddXY(labels[i],values[i]);
        }
        chart.Series.Add(serie);
    }
}
