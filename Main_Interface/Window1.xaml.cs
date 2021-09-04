using ICSharpCode.AvalonEdit;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace __UI_____Panda_A_.Main_Interface
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Panda_Executor))
                {
                    TextEditor textEditor = Panda_Executor.FindVisualChild<TextEditor>((window as Panda_Executor).Tabs);
                    textEditor.Text = File.ReadAllText("./scripts/" + (window as Panda_Executor).Viewer.SelectedItem);
                    (window as __UI_____Panda_A_.Main_Interface.Panda_Executor).Viewer.UnselectAll();
                }
            }
            Hide();
        }
    }
}
