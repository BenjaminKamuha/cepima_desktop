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

        public static Color Primary = ColorTranslator.FromHtml("#029EFA");
        public static Color Secondary = ColorTranslator.FromHtml("#073383");
        public static Color Danger = ColorTranslator.FromHtml("#A60202");
        public static Color Success = ColorTranslator.FromHtml("#00CC66");
        public static Color Warning = ColorTranslator.FromHtml("#EB8602");


        // AUtres couleurs
        public static Color White = Color.White;
        public static Color Text = Color.FromArgb(30, 41, 59);
        public static Color TextSecondary = Color.FromArgb(100, 116, 139);
        public static Color Border = Color.FromArgb(226, 232, 240);
        public static Color Info = Color.FromArgb(14, 165, 233);


        // ===========================================
        // POLICES
        // ===========================================

        public static Font FontNormal = new Font("Calibri", 9);
        public static Font FontMedium = new Font("Calibri", 10,FontStyle.Bold);
        public static Font FontTitle = new Font("Calibri", 18, FontStyle.Bold);
        public static Font FontCardTitle = new Font("Calibri", 9, FontStyle.Regular);
        public static Font FontCardValue = new Font("Calibri", 20, FontStyle.Bold);
        
    }
}
