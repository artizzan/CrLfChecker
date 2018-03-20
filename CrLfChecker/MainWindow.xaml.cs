using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrLfChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var detector = new Detector();
            var results = detector.AnalyzeDirectory(RootDir.Text);

            var sb = new StringBuilder();
            foreach (var result in results)
            {
                sb.AppendLine($"{result.FileName} ==> LF: {result.LfCount} CRLF: {result.CrLfCount} FullPath: {result.FilePath}");
            }

            ResultsBox.Text = sb.ToString();
        }
    }
}
