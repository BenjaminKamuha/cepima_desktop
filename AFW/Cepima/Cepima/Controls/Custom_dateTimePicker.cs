using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace Cepima.Controls
{
    [DefaultEvent("ValueChanged")]
    public class MyDateTimePicker : UserControl
    {
        private Label lblDate;
        private Button btnCalendar;

        private ToolStripDropDown popup;
        private ToolStripControlHost popupHost;
        private CustomCalendar calendar;

        private DateTime selectedDate = DateTime.Today;

        private Color borderColor = Color.FromArgb(210, 220, 230);
        private Color borderFocusColor = Color.FromArgb(41, 128, 185);
        private Color selectedDayColor = Color.FromArgb(41, 128, 185);
        private Color calendarBackColor = Color.White;

        private int borderRadius = 10;
        private int borderSize = 1;
        private int calendarHeight = 280;

        private bool isFocused = false;
        private string customFormat = "dd/MM/yyyy";

        public MyDateTimePicker()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            Size = new Size(320, 32);
            MinimumSize = new Size(180, 28);
            BackColor = Color.White;
            ForeColor = Color.FromArgb(50, 60, 70);
            Font = new Font("Segoe UI", 10F);

            lblDate = new Label();
            lblDate.AutoSize = false;
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            lblDate.BackColor = Color.Transparent;
            lblDate.Cursor = Cursors.Hand;

            btnCalendar = new Button();
            btnCalendar.Text = "\u25BC";
            btnCalendar.FlatStyle = FlatStyle.Flat;
            btnCalendar.FlatAppearance.BorderSize = 0;
            btnCalendar.BackColor = Color.White;
            btnCalendar.ForeColor = Color.FromArgb(41, 128, 185);
            btnCalendar.Cursor = Cursors.Hand;
            btnCalendar.TabStop = false;

            Controls.Add(lblDate);
            Controls.Add(btnCalendar);

            lblDate.Click += delegate { ToggleCalendar(); };
            btnCalendar.Click += delegate { ToggleCalendar(); };

            lblDate.Enter += delegate
            {
                isFocused = true;
                Invalidate();
            };

            lblDate.Leave += delegate
            {
                isFocused = false;
                Invalidate();
            };

            calendar = new CustomCalendar();
            calendar.DateSelected += Calendar_DateSelected;
            calendar.SelectedDayColor = selectedDayColor;
            calendar.CalendarBackColor = calendarBackColor;

            popup = new ToolStripDropDown();
            popup.AutoClose = true;
            popup.Padding = Padding.Empty;
            popup.Margin = Padding.Empty;

            popupHost = new ToolStripControlHost(calendar);
            popupHost.Padding = Padding.Empty;
            popupHost.Margin = Padding.Empty;
            popupHost.AutoSize = false;

            popup.Items.Add(popupHost);

            popup.Closed += delegate
            {
                isFocused = false;
                Invalidate();
            };

            UpdateDisplay();
            LayoutControls();
        }

        // Date sélectionnée

        [Category("Date")]
        public DateTime Value
        {
            get { return selectedDate; }
            set
            {
                if (value < minDate || value > maxDate)
                    throw new ArgumentOutOfRangeException("Value");

                selectedDate = value;
                UpdateDisplay();

                if (calendar != null)
                    calendar.SetDate(selectedDate);

                Invalidate();
            }
        }

        // Compatibilité avec les propriétés de l'ancien DateTimePicker

        private DateTimePickerFormat dateFormat =
            DateTimePickerFormat.Custom;

        private DateTime minDate =
            DateTimePicker.MinimumDateTime;

        private DateTime maxDate =
            DateTimePicker.MaximumDateTime;

        private bool dateChecked = true;
        private bool showCheckBox = false;
        private bool showUpDown = false;

        [Category("Date")]
        public DateTimePickerFormat Format
        {
            get { return dateFormat; }
            set
            {
                dateFormat = value;
                UpdateDisplay();
            }
        }

        [Category("Date")]
        public DateTime MinDate
        {
            get { return minDate; }
            set
            {
                if (value > maxDate)
                    throw new ArgumentOutOfRangeException("MinDate");

                minDate = value;

                if (selectedDate < minDate)
                    Value = minDate;
            }
        }

        [Category("Date")]
        public DateTime MaxDate
        {
            get { return maxDate; }
            set
            {
                if (value < minDate)
                    throw new ArgumentOutOfRangeException("MaxDate");

                maxDate = value;

                if (selectedDate > maxDate)
                    Value = maxDate;
            }
        }

        [Category("Date")]
        public bool Checked
        {
            get { return dateChecked; }
            set { dateChecked = value; }
        }

        [Category("Date")]
        public bool ShowCheckBox
        {
            get { return showCheckBox; }
            set { showCheckBox = value; }
        }

        [Category("Date")]
        public bool ShowUpDown
        {
            get { return showUpDown; }
            set { showUpDown = value; }
        }

        [Category("Apparence")]
        public Font CalendarFont
        {
            get { return calendar.Font; }
            set
            {
                if (value != null)
                    calendar.Font = value;
            }
        }

        [Category("Apparence")]
        public Color CalendarTitleBackColor
        {
            get { return selectedDayColor; }
            set { SelectedDayColor = value; }
        }

        [Category("Apparence")]
        public Color CalendarTitleForeColor
        {
            get { return Color.White; }
            set { }
        }
        // Format de la date

        [Category("Date")]
        public string CustomFormat
        {
            get { return customFormat; }
            set
            {
                customFormat = value;
                UpdateDisplay();
            }
        }

        // Largeur du calendrier = largeur du contrôle

        [Category("Calendrier")]
        [ReadOnly(true)]
        public int CalendarWidth
        {
            get { return Width; }
        }

        // Hauteur du calendrier déroulant

        [Category("Calendrier")]
        public int CalendarHeight
        {
            get { return calendarHeight; }
            set
            {
                calendarHeight = Math.Max(220, value);
                Invalidate();
            }
        }

        // Couleur du jour sélectionné

        [Category("Calendrier")]
        public Color SelectedDayColor
        {
            get { return selectedDayColor; }
            set
            {
                selectedDayColor = value;

                if (calendar != null)
                    calendar.SelectedDayColor = value;

                Invalidate();
            }
        }

        // Fond du calendrier

        [Category("Calendrier")]
        public Color CalendarBackColor
        {
            get { return calendarBackColor; }
            set
            {
                calendarBackColor = value;

                if (calendar != null)
                    calendar.CalendarBackColor = value;
            }
        }

        // Couleur de bordure normale

        [Category("Apparence")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        // Couleur de bordure lorsque le contrôle est actif

        [Category("Apparence")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set
            {
                borderFocusColor = value;
                Invalidate();
            }
        }

        // Arrondi des coins

        [Category("Apparence")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = Math.Max(0, value);
                UpdateRegion();
                Invalidate();
            }
        }

        // Épaisseur de la bordure

        [Category("Apparence")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = Math.Max(0, value);
                LayoutControls();
                Invalidate();
            }
        }

        // Événement de changement de date

        public event EventHandler ValueChanged;

        private void OnValueChanged()
        {
            EventHandler handler = ValueChanged;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void UpdateDisplay()
        {
            if (lblDate == null)
                return;

            try
            {
                if (dateFormat == DateTimePickerFormat.Short)
                {
                    lblDate.Text = selectedDate.ToString(
                        "d", CultureInfo.GetCultureInfo("fr-FR"));
                }
                else if (dateFormat == DateTimePickerFormat.Long)
                {
                    lblDate.Text = selectedDate.ToString(
                        "D", CultureInfo.GetCultureInfo("fr-FR"));
                }
                else
                {
                    lblDate.Text = selectedDate.ToString(
                        customFormat, CultureInfo.GetCultureInfo("fr-FR"));
                }
            }
            catch
            {
                lblDate.Text = selectedDate.ToString("dd/MM/yyyy");
            }

            lblDate.ForeColor = ForeColor;
            lblDate.Font = Font;
        }

        private void LayoutControls()
        {
            if (lblDate == null || btnCalendar == null)
                return;

            int inset = borderSize + 5;
            int buttonWidth = 30;

            lblDate.Location = new Point(inset, 1);
            lblDate.Size = new Size(
                Math.Max(0, Width - buttonWidth - inset - 5),
                Math.Max(0, Height - 2));

            btnCalendar.Location = new Point(
                Math.Max(0, Width - buttonWidth - borderSize),
                borderSize);

            btnCalendar.Size = new Size(
                Math.Max(0, buttonWidth),
                Math.Max(0, Height - borderSize * 2));

            btnCalendar.Font = new Font("Segoe UI", 8F);
        }

        private void ToggleCalendar()
        {
            if (popup.Visible)
            {
                popup.Close();
                return;
            }

            calendar.SetDate(selectedDate);
            calendar.SelectedDayColor = selectedDayColor;
            calendar.CalendarBackColor = calendarBackColor;

            int popupWidth = Math.Max(1, Width);

            calendar.Size = new Size(popupWidth, calendarHeight);
            popupHost.Size = calendar.Size;
            popup.Size = calendar.Size;

            isFocused = true;
            Invalidate();

            popup.Show(this, new Point(0, Height));
        }

        private void Calendar_DateSelected(DateTime date)
        {
            selectedDate = date;
            UpdateDisplay();
            Invalidate();

            popup.Close();
            OnValueChanged();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            LayoutControls();
            UpdateRegion();

            if (popup != null && popup.Visible)
            {
                calendar.Size = new Size(Width, calendarHeight);
                popupHost.Size = calendar.Size;
                popup.Size = calendar.Size;
            }

            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            UpdateDisplay();
            LayoutControls();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (lblDate != null)
                lblDate.BackColor = Color.Transparent;

            if (btnCalendar != null)
                btnCalendar.BackColor = BackColor;

            Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            UpdateDisplay();
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int d = Math.Min(
                radius * 2,
                Math.Min(rect.Width, rect.Height));

            Rectangle arc = new Rectangle(
                rect.X, rect.Y, d, d);

            path.AddArc(arc, 180, 90);

            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);

            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);

            arc.X = rect.X;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0)
                return;

            using (GraphicsPath path = GetRoundedPath(
                new Rectangle(0, 0, Width, Height),
                borderRadius))
            {
                Region oldRegion = Region;
                Region = new Region(path);

                if (oldRegion != null)
                    oldRegion.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedPath(
                new Rectangle(0, 0, Width - 1, Height - 1),
                borderRadius))
            using (Pen pen = new Pen(
                isFocused ? borderFocusColor : borderColor,
                Math.Max(1, borderSize)))
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);

                if (borderSize > 0)
                    e.Graphics.DrawPath(pen, path);
            }
        }
    }

    // Calendrier entièrement personnalisé

    internal class CustomCalendar : UserControl
    {
        private Button btnPrevious;
        private Button btnNext;
        private Label lblMonth;
        private TableLayoutPanel table;

        private DateTime currentMonth;
        private DateTime selectedDate;

        private Color selectedDayColor =
            Color.FromArgb(41, 128, 185);

        private Color calendarBackColor = Color.White;

        public event Action<DateTime> DateSelected;

        public CustomCalendar()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            MinimumSize = new Size(180, 220);

            currentMonth = DateTime.Today;
            selectedDate = DateTime.Today;

            BuildCalendar();
            RefreshCalendar();
        }

        public Color SelectedDayColor
        {
            get { return selectedDayColor; }
            set
            {
                selectedDayColor = value;
                RefreshCalendar();
            }
        }

        public Color CalendarBackColor
        {
            get { return calendarBackColor; }
            set
            {
                calendarBackColor = value;
                BackColor = value;
                RefreshCalendar();
            }
        }

        public void SetDate(DateTime date)
        {
            selectedDate = date;
            currentMonth = new DateTime(date.Year, date.Month, 1);
            RefreshCalendar();
        }

        private void BuildCalendar()
        {
            Controls.Clear();

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 42;
            header.BackColor = selectedDayColor;

            btnPrevious = new Button();
            btnPrevious.Text = "\u2039";
            btnPrevious.Font = new Font("Segoe UI", 20F);
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.ForeColor = Color.White;
            btnPrevious.BackColor = selectedDayColor;
            btnPrevious.Dock = DockStyle.Left;
            btnPrevious.Width = 42;
            btnPrevious.Click += delegate
            {
                currentMonth = currentMonth.AddMonths(-1);
                RefreshCalendar();
            };

            btnNext = new Button();
            btnNext.Text = "\u203A";
            btnNext.Font = new Font("Segoe UI", 20F);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.ForeColor = Color.White;
            btnNext.BackColor = selectedDayColor;
            btnNext.Dock = DockStyle.Right;
            btnNext.Width = 42;
            btnNext.Click += delegate
            {
                currentMonth = currentMonth.AddMonths(1);
                RefreshCalendar();
            };

            lblMonth = new Label();
            lblMonth.Dock = DockStyle.Fill;
            lblMonth.TextAlign = ContentAlignment.MiddleCenter;
            lblMonth.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMonth.ForeColor = Color.White;
            lblMonth.BackColor = selectedDayColor;

            header.Controls.Add(lblMonth);
            header.Controls.Add(btnPrevious);
            header.Controls.Add(btnNext);

            table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.Padding = new Padding(5);
            table.Margin = Padding.Empty;
            table.BackColor = calendarBackColor;
            table.ColumnCount = 7;
            table.RowCount = 7;
            table.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            for (int i = 0; i < 7; i++)
            {
                table.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100F / 7F));
            }

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));

            for (int i = 0; i < 6; i++)
            {
                table.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100F / 6F));
            }

            string[] days = {
                "Lu", "Ma", "Me", "Je", "Ve", "Sa", "Di"
            };

            for (int i = 0; i < 7; i++)
            {
                Label day = new Label();
                day.Text = days[i];
                day.Dock = DockStyle.Fill;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                day.ForeColor = Color.FromArgb(100, 110, 120);
                day.BackColor = calendarBackColor;

                table.Controls.Add(day, i, 0);
            }

            Controls.Add(table);
            Controls.Add(header);

            header.BringToFront();
        }

        private void RefreshCalendar()
        {
            if (table == null || lblMonth == null)
                return;

            lblMonth.Text = currentMonth.ToString(
                "MMMM yyyy",
                CultureInfo.GetCultureInfo("fr-FR"));

            lblMonth.Text = char.ToUpper(
                lblMonth.Text[0]) + lblMonth.Text.Substring(1);

            while (table.Controls.Count > 7)
            {
                System.Windows.Forms.Control c = table.Controls[7];
                table.Controls.RemoveAt(7);
                c.Dispose();
            }

            DateTime firstDay = new DateTime(
                currentMonth.Year, currentMonth.Month, 1);

            int offset = ((int)firstDay.DayOfWeek + 6) % 7;

            int daysInMonth = DateTime.DaysInMonth(
                currentMonth.Year, currentMonth.Month);

            for (int cell = 0; cell < 42; cell++)
            {
                int dayNumber = cell - offset + 1;

                Button dayButton = new Button();
                dayButton.Dock = DockStyle.Fill;
                dayButton.Margin = new Padding(1);
                dayButton.FlatStyle = FlatStyle.Flat;
                dayButton.FlatAppearance.BorderSize = 0;
                dayButton.Font = new Font("Segoe UI", 9F);
                dayButton.Cursor = Cursors.Hand;
                dayButton.TabStop = false;

                if (dayNumber >= 1 && dayNumber <= daysInMonth)
                {
                    DateTime date = new DateTime(
                        currentMonth.Year,
                        currentMonth.Month,
                        dayNumber);

                    dayButton.Text = dayNumber.ToString();
                    dayButton.Tag = date;

                    bool selected =
                        date.Date == selectedDate.Date;

                    dayButton.BackColor = selected
                        ? selectedDayColor
                        : calendarBackColor;

                    dayButton.ForeColor = selected
                        ? Color.White
                        : Color.FromArgb(50, 60, 70);

                    dayButton.FlatAppearance.MouseOverBackColor =
                        Color.FromArgb(225, 238, 250);

                    dayButton.Click += delegate(object sender, EventArgs e)
                    {
                        Button b = sender as Button;

                        if (b != null && b.Tag is DateTime)
                        {
                            Action<DateTime> handler = DateSelected;

                            if (handler != null)
                                handler((DateTime)b.Tag);
                        }
                    };
                }
                else
                {
                    dayButton.Text = "";
                    dayButton.Enabled = false;
                    dayButton.BackColor = calendarBackColor;
                }

                table.Controls.Add(dayButton, cell % 7, cell / 7 + 1);
            }

            table.BackColor = calendarBackColor;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (table != null)
                table.Invalidate();
        }
    }
}
