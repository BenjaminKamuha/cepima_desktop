using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIFramework;
namespace MyProject
{
    public partial class Form1 : Form
    {
        private Button toggleThemeButton;
        public Form1()
        {

            //TestButton();
            //TestStatCard();
            //TestAvatarControl();
            //TestDonutChart();
            //TestLineChart();
            //TestEmployeeTable();
            //TestbarChart();

            Label lb = new Label();
            lb.Text = "My Label";
            lb.Location = new Point(200, 150);
            this.Controls.Add(lb);

            InitializeComponent();


            // Bouton pour changer le thème
            toggleThemeButton = new Button();
            toggleThemeButton.Text = "Changer thème";
            toggleThemeButton.Location = new Point(100, 220);
            toggleThemeButton.Click += ToggleThemeButton_Click;
            this.Controls.Add(toggleThemeButton);


            // Appliquer le thème initial
            ThemeManager.ApplyTheme(this);

            // S'abonner au changement de thème pour réappliquer le thème sur le Form
            ThemeManager.ThemeChanged += () =>
            {
                ThemeManager.ApplyTheme(this); // met à jour tous les contrôles
                // Sauvegarder le theme
                Properties.Settings.Default.ThemeMode = ThemeManager.CurrentMode.ToString();
                Properties.Settings.Default.Save();
            };

        }

        private void ToggleThemeButton_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme(); // bascule clair/sombre
        }


        public static void TestbarChart()
        {
            
            BarChartControl chart = new BarChartControl();
            chart.Location = new Point(300, 100);
            chart.Size = new Size(400, 150);
            chart.LabelFont = new Font("Segoe UI", 9, FontStyle.Regular);

            chart.Bars = new List<BarChartControl.Bar>
            {
                new BarChartControl.Bar(80, Color.Red, "Article 1 très long qui pourrait se couper"),
                new BarChartControl.Bar(50, Color.Green, "Article 2"),
                new BarChartControl.Bar(120, Color.Orange, "Article 3"),
                new BarChartControl.Bar(30, Color.Blue, "Article 4 très très long également")
            };
            
            chart.BarWidth = 40;
            chart.BarSpacing = 5;
            chart.StartAnimation();
            
        }

        private void TestButton()
        {
            ButtonEx btn = new ButtonEx();
            btn.TextValue = "Click me";
            btn.Location = new Point(50, 50);
            btn.Size = new Size(120, 40);
            this.Controls.Add(btn);
        }

        //private void TestStatCard()
        //{
        //    StatCard card = new StatCard();
        //    card.Title = "Revenue";
        //    card.Value = "5000$";
        //    card.Subtitle_one = "This Month";
        //    card.Location = new Point(50, 100);
        //    card.Size = new Size(180, 120);
        //    this.Controls.Add(card);
        //}

        private void TestAvatarControl()
        {
            AvatarControl avatar = new AvatarControl();
            avatar.Location = new Point(300, 50);
            avatar.Size = new Size(60, 60);
            this.Controls.Add(avatar);
        }

        private void TestDonutChart()
        {
            DonutChartControl donut = new DonutChartControl();
            donut.Size = new Size(150, 150);
            donut.Percentage = 86;
            donut.Thickness = 20;
            donut.ArcColor = Color.Teal;
            donut.ValueFont = new Font("Sego UI", 12, FontStyle.Bold);
            donut.StartAnimation();
            
            this.Controls.Add(donut);
        }

        private void TestEmployeeTable()
        {
            EmployeeTableControl table = new EmployeeTableControl();
            table.Location = new Point(50, 50);
            table.Size = new Size(800, 200);
            table.Employees = new List<Employee>
        {
            new Employee { FirstName="John", LastName="Doe", Email="john@example.com", Department="IT", Role="Admin", Salary="$5000", Status="Paid"},
            new Employee { FirstName="Jane", LastName="Smith", Email="jane@example.com", Department="HR", Role="Manager", Salary="$4500", Status="Pending"},
            new Employee { FirstName="Benjamin", LastName="Kamuha", Email="jane@example.com", Department="HR", Role="Manager", Salary="$4500", Status="Pending"}
        };
            this.Controls.Add(table);
        }

    }
}
