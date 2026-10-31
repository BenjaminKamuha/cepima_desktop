
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;

namespace Cepima.Controls
{
    public class MonGraphique : UserControl
    {
        // ============================================================
        // CONTRÔLE LIVECHARTS
        // ============================================================

        private LiveCharts.WinForms.CartesianChart graphique;
        private LiveCharts.WinForms.PieChart graphiqueCirculaire;
        // ============================================================
        // PROPRIÉTÉS PERSONNALISABLES
        // ============================================================

        private string _titre = "Mon graphique";
        private Color _couleurFond = Color.White;
        private Color _couleurTitre = Color.FromArgb(45, 45, 45);
        private Color _couleurPrincipale = Color.FromArgb(52, 152, 219);

        private bool _afficherLegende = true;
        private bool _afficherGrille = true;
        private bool _animation = true;

        // ============================================================
        // CONSTRUCTEUR
        // ============================================================

        public MonGraphique()
        {
            InitialiserControle();
        }


        // ============================================================
        // INITIALISATION
        // ============================================================

        private void InitialiserControle()
        {
            this.BackColor = _couleurFond;
            this.Size = new Size(700, 400);

            // Graphique cartésien : histogrammes, courbes et barres
            graphique = new LiveCharts.WinForms.CartesianChart();
            graphique.Dock = DockStyle.Fill;
            graphique.BackColor = _couleurFond;
            graphique.DisableAnimations = !_animation;

            // Graphique circulaire
            graphiqueCirculaire = new LiveCharts.WinForms.PieChart();
            graphiqueCirculaire.Dock = DockStyle.Fill;
            graphiqueCirculaire.BackColor = _couleurFond;
            graphiqueCirculaire.DisableAnimations = !_animation;
            graphiqueCirculaire.Visible = false;

            this.Controls.Add(graphique);
            this.Controls.Add(graphiqueCirculaire);


            ConfigurerAxes();
        }

        // ============================================================
        // PROPRIÉTÉ : TITRE
        // ============================================================

        public string Titre
        {
            get
            {
                return _titre;
            }
            set
            {
                _titre = value;
                Invalidate();
            }
        }

        // ============================================================
        // PROPRIÉTÉ : COULEUR DU FOND
        // ============================================================

        public Color CouleurFond
        {
            get
            {
                return _couleurFond;
            }
            set
            {
                _couleurFond = value;

                this.BackColor = value;

                if (graphique != null)
                    graphique.BackColor = value;
            }
        }

        // ============================================================
        // PROPRIÉTÉ : COULEUR DU TITRE
        // ============================================================

        public Color CouleurTitre
        {
            get
            {
                return _couleurTitre;
            }
            set
            {
                _couleurTitre = value;
            }
        }

        // ============================================================
        // PROPRIÉTÉ : COULEUR PRINCIPALE
        // ============================================================

        public Color CouleurPrincipale
        {
            get
            {
                return _couleurPrincipale;
            }
            set
            {
                _couleurPrincipale = value;
            }
        }

        // ============================================================
        // PROPRIÉTÉ : LÉGENDE
        // ============================================================

        public bool AfficherLegende
        {
            get
            {
                return _afficherLegende;
            }
            set
            {
                _afficherLegende = value;

                if (graphique != null)
                {
                    graphique.LegendLocation =
                        value
                        ? LegendLocation.Bottom
                        : LegendLocation.None;
                }
            }
        }

        // ============================================================
        // PROPRIÉTÉ : GRILLE
        // ============================================================

        public bool AfficherGrille
        {
            get
            {
                return _afficherGrille;
            }
            set
            {
                _afficherGrille = value;
                ConfigurerAxes();
            }
        }

        // ============================================================
        // PROPRIÉTÉ : ANIMATION
        // ============================================================

        public bool AnimationActive
        {
            get
            {
                return _animation;
            }
            set
            {
                _animation = value;

                if (graphique != null)
                    graphique.DisableAnimations = !value;
            }
        }

        // ============================================================
        // CONFIGURATION DES AXES
        // ============================================================

        private void ConfigurerAxes()
        {
            if (graphique == null)
                return;

            graphique.AxisX.Clear();
            graphique.AxisY.Clear();

            Axis axeX = new Axis();

            Axis axeY = new Axis();

            if (_afficherGrille)
            {
                axeX.Separator = new Separator
                {
                    IsEnabled = true,
                    StrokeThickness = 1
                };

                axeY.Separator = new Separator
                {
                    IsEnabled = true,
                    StrokeThickness = 1
                };
            }
            else
            {
                axeX.Separator = new Separator
                {
                    IsEnabled = false
                };

                axeY.Separator = new Separator
                {
                    IsEnabled = false
                };
            }

            graphique.AxisX.Add(axeX);
            graphique.AxisY.Add(axeY);
        }

        // ============================================================
        // AJOUTER UNE SÉRIE
        // ============================================================

        public void AjouterSerie(
            string nom,
            IList<double> valeurs)
        {
            if (graphique == null)
                return;

            ChartValues<double> donnees =
                new ChartValues<double>();

            foreach (double valeur in valeurs)
            {
                donnees.Add(valeur);
            }

            LineSeries serie = new LineSeries
            {
                Title = nom,
                Values = donnees,
                PointGeometrySize = 8,
                LineSmoothness = 0.5
            };

            graphique.Series.Add(serie);
        }

        // ============================================================
        // AJOUTER UNE SÉRIE AVEC DES ÉTIQUETTES
        // ============================================================

        public void AjouterSerie(
      string nom,
      IList<string> etiquettes,
      IList<double> valeurs)
        {
            if (graphique == null)
                return;

            ChartValues<double> donnees =
                new ChartValues<double>();

            foreach (double valeur in valeurs)
            {
                donnees.Add(valeur);
            }

            LineSeries serie = new LineSeries
            {
                Title = nom,
                Values = donnees,
                PointGeometrySize = 8,
                LineSmoothness = 0.5
            };

            graphique.Series.Add(serie);

            // Recréer l'axe X
            graphique.AxisX.Clear();

            Axis axex = new Axis
            {
                Labels = new List<string>(etiquettes),

                Separator = new Separator
                {
                    IsEnabled = _afficherGrille
                }
            };

            graphique.AxisX.Add(axex);
        }

        // ============================================================
        // AJOUTER UNE SÉRIE EN HISTOGRAMME
        // ============================================================

        public void AjouterHistogramme(
     string nom,
     IList<string> etiquettes,
     IList<double> valeurs)
        {
            graphiqueCirculaire.Visible = false;
            graphique.Visible = true;
            graphique.BringToFront();
            if (graphique == null)
                return;

            // =====================================================
            // Nettoyer les anciennes données
            // =====================================================

            graphique.Series.Clear();
            graphique.AxisX.Clear();
            graphique.AxisY.Clear();

            // =====================================================
            // Préparer les valeurs
            // =====================================================

            ChartValues<double> donnees =
                new ChartValues<double>();

            double maximum = 0;

            foreach (double valeur in valeurs)
            {
                // Éliminer les petits résidus numériques
                double valeurCorrigee = valeur;

                if (Math.Abs(valeurCorrigee) < 0.000001)
                {
                    valeurCorrigee = 0;
                }

                donnees.Add(valeurCorrigee);

                if (valeurCorrigee > maximum)
                {
                    maximum = valeurCorrigee;
                }
            }

            // =====================================================
            // Série en colonnes
            // =====================================================

            ColumnSeries serie = new ColumnSeries
            {
                Title = nom,
                Values = donnees,
                Fill = System.Windows.Media.Brushes.DodgerBlue,
                DataLabels = true,
                LabelPoint = p => p.Y.ToString("0"),
                FontSize = 12,
                Foreground = System.Windows.Media.Brushes.DimGray
            };

            graphique.Series.Add(serie);

            // =====================================================
            // AXE X
            // =====================================================

            Axis axeX = new Axis
            {
                Labels = new List<string>(etiquettes),

                // Afficher les étiquettes horizontalement
                LabelsRotation = 0,

                // Taille des mois
                FontSize = 10,

                Separator = new Separator
                {
                    // Une séparation pour chaque mois
                    Step = 1,

                    IsEnabled = _afficherGrille
                }
            };

            graphique.AxisX.Add(axeX);

            // =====================================================
            // AXE Y
            // =====================================================

            Axis axeY = new Axis
            {
                MinValue = 0,

                Separator = new Separator
                {
                    IsEnabled = _afficherGrille
                }
            };

            graphique.AxisY.Add(axeY);

            // =====================================================
            // Si toutes les valeurs sont à zéro
            // =====================================================

            if (maximum <= 0)
            {
                axeY.MaxValue = 10;
            }
            else
            {
                // Ajouter un peu d'espace au-dessus
                axeY.MaxValue = maximum * 1.15;
            }
        }
        //===================================================================
        //AJOUTER LES BARS 
        public void AjouterBarres(
    string nom,
    IList<string> etiquettes,
    IList<double> valeurs)
        {
            if (graphique == null)
                return;

            ChartValues<double> donnees =
                new ChartValues<double>();

            foreach (double valeur in valeurs)
            {
                donnees.Add(valeur);
            }

            RowSeries serie = new RowSeries
            {
                Title = nom,
                Values = donnees
            };

            graphique.Series.Add(serie);

            // Axe Y : les catégories
            graphique.AxisY.Clear();

            Axis axeY = new Axis
            {
                Labels = new List<string>(etiquettes),

                Separator = new Separator
                {
                    IsEnabled = _afficherGrille
                }
            };

            graphique.AxisY.Add(axeY);
        }

        //////// ajouter cercle
        public void AjouterGraphiqueCirculaire(params object[] donnees)
        {
            if (graphiqueCirculaire == null || donnees == null)
                return;

            if (donnees.Length == 0 || donnees.Length % 2 != 0)
                throw new ArgumentException(
                    "Fournissez un nom et un montant pour chaque catégorie.");

            graphique.Visible = false;
            graphiqueCirculaire.Visible = true;
            graphiqueCirculaire.BringToFront();

            graphiqueCirculaire.Series.Clear();

            Color[] couleurs =
    {
        Color.FromArgb(8, 120, 249),
        Color.FromArgb(7, 148, 71),
        Color.FromArgb(245, 34, 53),
        Color.FromArgb(128, 60, 245),
        Color.FromArgb(245, 130, 11),
        Color.FromArgb(0, 150, 170)
    };

            for (int i = 0; i < donnees.Length; i += 2)
            {
                string nom = Convert.ToString(donnees[i]);
                double montant = Convert.ToDouble(donnees[i + 1]);

                if (montant < 0)
                    throw new ArgumentException(
                        "Les montants du graphique ne peuvent pas être négatifs.");

                LiveCharts.Wpf.PieSeries serie =
                    new LiveCharts.Wpf.PieSeries
                    {
                        Title = nom,
                        Values = new LiveCharts.ChartValues<double> { montant },
                        Fill = new System.Windows.Media.SolidColorBrush(
                            System.Windows.Media.Color.FromRgb(
                                couleurs[(i / 2) % couleurs.Length].R,
                                couleurs[(i / 2) % couleurs.Length].G,
                                couleurs[(i / 2) % couleurs.Length].B)),
                        DataLabels = true,
                        LabelPoint = p => p.Participation.ToString("P0"),
                        FontSize = 14,
                        Foreground = System.Windows.Media.Brushes.White
                    };

                graphiqueCirculaire.Series.Add(serie);
            }

            graphiqueCirculaire.LegendLocation =
                LiveCharts.LegendLocation.Right;
        }

        // ============================================================
        // VIDER LE GRAPHIQUE
        // ============================================================

        public void Vider()
        {
            if (graphique == null)
                return;

            graphique.Series.Clear();

            ConfigurerAxes();
        }

        // ============================================================
        // OBTENIR LE GRAPHIQUE LIVECHARTS
        // ============================================================

        public LiveCharts.WinForms.CartesianChart ControleGraphique
        {
            get
            {
                return graphique;
            }
        }
    }
}

