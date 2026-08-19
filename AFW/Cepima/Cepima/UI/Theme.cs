using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cepima.UI
{
    class Theme
    {
        // ========================================
        // COULEURS PRINCIPALES 
        // ========================================

        public static Color Primary = Color.FromArgb(37, 99, 235);
        public static Color PrimaryDark = Color.FromArgb(30, 64, 175);
        public static Color Sidebar = Color.FromArgb(15, 23, 42);
        public static Color SidebarHover = Color.FromArgb(30, 41, 59);
        public static Color Background = Color.FromArgb(248, 250, 252);
        public static Color White = Color.White;
        public static Color Text = Color.FromArgb(30, 41, 59);
        public static Color TextSecondary = Color.FromArgb(100, 116, 139);
        public static Color Border = Color.FromArgb(226, 232, 240);
        public static Color Success = Color.FromArgb(22, 163, 74);
        public static Color Warning = Color.FromArgb(220, 38, 38);
        public static Color Danger = Color.FromArgb(220, 38, 38);
        public static Color Info = Color.FromArgb(14, 165, 233);


        // ===========================================
        // POLICES
        // ===========================================

        public static Font FontNormal = new Font("Segoe UI", 9);
        public static Font FontMedium = new Font("Segoe UI", 10);
        public static Font FontTitle = new Font("Segoe UI", 18, FontStyle.Bold);
        public static Font FontCardTitle = new Font("Segoe UI", 9, FontStyle.Regular);
        public static Font FontCardValue = new Font("Segoe UI", 20, FontStyle.Bold);


        
    }
}
