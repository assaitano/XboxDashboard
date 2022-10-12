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
using XboxDesktop;
using System.ComponentModel;
using XInputDotNetPure;
using System.Windows.Threading;
using System.Threading;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Xml;
using System.Windows.Markup;
using System.Xml.Linq;
using System.Windows.Automation;
using Microsoft.Xaml.Behaviors.Core;
using ModernWpf;
using System.Windows.Media.Animation;


namespace XboxDesktop
{
    public enum MenuState
    {
        Desktop,
        Libriary,
        WebBrowser,
        RunGame
    }

    public struct NewsButton
    {
        public string imageURL;
        public string postURL;
        public Image image;
        public Button button;

        public NewsButton(Button but)
        {
            this.button = but;
            this.image = new Image();
            this.imageURL = "";
            this.postURL = "";
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        String btnLastPress = "";
        MenuState menuState = MenuState.Desktop;

        private DispatcherTimer clock;

        public MainWindow()
        {
            InitializeComponent();

            Program.LoadDB();

            this.PreviewKeyDown += new KeyEventHandler(HandleKey);

            UpdateRednderState();

            btnNewsList = new List<Button>() { btnNews1, btnNews2, btnNews3 };
            /*
            controllerControls = new Control[] {
                picController1,
                picController2,
                picController3,
                picController4
            };
            stickControls = new Control[] {
                picStickLeft,
                picStickRight
            };
            stickControlPositions = new Point[] {
                picStickLeft.Location,
                picStickRight.Location
            };
            */

            //while (true)
            //{
            //    UpdateState();
            //}

            //Program.StartPolling();

            //UpdateNews();

            Start();
        }

        private void Start()
        {
            clock = new DispatcherTimer();
            clock.Tick += new EventHandler(Update);
            clock.Interval = new TimeSpan(0, 0, 0, 0, 16);
            clock.Start();
        }

        private void Update(Object sender, EventArgs e)
        {
            checkGamePads();
        }

        private void WindowLauncher(object sender, RoutedEventArgs e)
        {
            UpdateNews();
            UpdateRenderListGames();
        }

        private void UpdateRednderState()
        {
            switch (menuState)
            {
                case MenuState.Desktop:
                    Desktop.Visibility = Visibility.Visible;
                    WebBrowser.Visibility = Visibility.Hidden;
                    GamesApps.Visibility = Visibility.Hidden;
                    break;
                case MenuState.Libriary:
                    Desktop.Visibility = Visibility.Hidden;
                    GamesApps.Visibility = Visibility.Visible;
                    WebBrowser.Visibility = Visibility.Hidden;
                    break;
                case MenuState.WebBrowser:
                    Desktop.Visibility = Visibility.Hidden;
                    GamesApps.Visibility = Visibility.Hidden;
                    WebBrowser.Visibility = Visibility.Visible;
                    break;
            }
        }

        public void btnPress(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btnLastPress = btn.Name;
        }

        public void btnPressEnd()
        {
            if (btnLastPress == "") return;
            
            var id = 0;
            string message = btnLastPress;
            string[] keys = new string[] { "btnNews", "btLibriary" };

            string sKeyResult = keys.FirstOrDefault<string>(s => message.Contains(s));

            switch (sKeyResult)
            {
                case "btnNews":
                    message = message.Replace("btnNews", "");
                    id = Int32.Parse(message);
                    if (id > 0)
                    {
                        menuState = MenuState.WebBrowser;
                        UpdateRednderState();
                        webBrowser.Address = newsButtons[id - 1].postURL;
                    }
                    break;
                case "btLibriary":
                    menuState = MenuState.Libriary;
                    UpdateRednderState();
                    break;
            }

            btnLastPress = "";
        }

        //======================News============================

        List<NewsButton> newsButtons = new List<NewsButton>();
        List<Button> btnNewsList = new List<Button>();

        private void UpdateNews()
        {
            if (Net.CheckConnection("https://google.com"))
            {
                var doc = Net.LoadContentFromURL("https://news.xbox.com/en-us/xbox-game-pass/");
                ParseContentFromXBOX(doc);
            }
        }

        private void ParseContentFromXBOX(HtmlAgilityPack.HtmlDocument doc)
        {
            string imageNewsURL = "";
            string newsURL = "";
            List<string> ArhiveNewsImages = new List<string>();
            List<string> ArhiveNewsPost = new List<string>();

            //load Images 
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[contains(@class, 'media-image feed__image')]"))
            {
                ArhiveNewsImages.Add(node.InnerHtml);
            }
            //load Posts
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[contains(@class, 'media-body feed__body')]"))
            {
                ArhiveNewsPost.Add(node.InnerHtml);
            }

            for (int i = 0; i < 3; i++)
            {
                imageNewsURL = getBetween(ArhiveNewsImages[i], "<img", " class");
                imageNewsURL = getBetween(imageNewsURL, "src=\"", "\"");
                newsURL = getBetween(ArhiveNewsPost[i], "feed__title", "h3");
                newsURL = getBetween(newsURL, "href=\"", "\"");

                var nb = new NewsButton();
                nb.imageURL = imageNewsURL;
                nb.postURL = newsURL;
                nb.button = btnNewsList[0];
                nb.image = GetButtonImage(btnNewsList[i]);

                newsButtons.Add(nb);

                newsButtons[i].image.Source = Net.LoadImages(newsButtons[i].imageURL);
            }
        }

        /*
        private void btnNews_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name;
            name = name.Replace("btnNews", "");
            int id = Int32.Parse(name);
            if (id > 0)
            {
                menuState = MenuState.WebBrowser;
                UpdateRednderState();
                webBrowser.Address = newsButtons[id-1].postURL;
            }
        }
        */
        //======================Games============================

        int templateGameWidth = 305;
        int templateGameHeight = 305;
        int templateGameBorder = 3;

        int borderGameListBottom = 1080;
        int borderGameListTop = 258;

        private void UpdateRenderListGames()
        {
            GameTemplate.Visibility = Visibility.Hidden;

            int templateLeft = (int)GameTemplate.Margin.Left;
            int templateUp = (int)GameTemplate.Margin.Top;

            int columnCount = 4;
            int rowCount = 1;
            if (Program.Games.Count / columnCount > 0)
                rowCount = Program.Games.Count / columnCount + Program.Games.Count % columnCount;

            //Change Size Grid
            var listLeft = (int)listGames.Margin.Left;
            var listTop = (int)listGames.Margin.Top;
            var listRight = (int)listGames.Margin.Right;
            var listBottom = (int)listGames.Margin.Bottom;
            var sizeListBottom = listBottom - (rowCount * (templateGameHeight + templateGameBorder));
            listGames.Margin = new Thickness(listLeft, listTop, listRight, sizeListBottom);
            
            //Create Grid Data
            int game = 0;
            for (int mR = 0; mR < rowCount; mR++)
            {
                for (int mC = 0; mC < columnCount; mC++)
                {
                    var newButton = new Button();
                    newButton = (Button)CloneElement(GameTemplate);
                    var gameID = Program.Games[game].gameID;
                    newButton.Name = "btnGameId_" + gameID;
                    var x = templateLeft + mC * (templateGameWidth + templateGameBorder);
                    var y = templateUp + mR * (templateGameHeight + templateGameBorder);
                    newButton.Margin = new Thickness(x, y, 0, 0);
                    Program.AddRowColumn(gameID, mR, mC);

                    listGames.Children.Add(newButton);

                    newButton.Visibility = Visibility.Visible;
                    newButton.Click += btnGame_Click;
                    newButton.GotFocus += btnGame_GotFocus;
                    newButton.LostFocus += btnGame_LostFocus;

                    newButton.Loaded += btnGame_Load;

                    game++;
                    if (game == Program.Games.Count) break;
                }
            }
        }

        private Vector lastFocusRC = new Vector();

        private void btnGame_LostFocus(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name;
            lastFocusRC = GetGameRowColumn(btn);
        }

        private void btnGame_GotFocus(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name;
            var gameID = GetGameID(btn);

            //Move Game List if game around next focus

            MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
            var gameLeftTop = mainWindow.TranslatePoint(new Point(0, 0), btn);
            var gameBottom = (int)gameLeftTop.Y * (-1) + templateGameHeight;
            var gameTop = (int)gameLeftTop.Y * (-1) - templateGameHeight;

            var listLeft = (int)listGames.Margin.Left;
            var listTop = (int)listGames.Margin.Top;
            var listRight = (int)listGames.Margin.Right;
            var listBottom = (int)listGames.Margin.Bottom;

            var maxRow = Program.Games[Program.Games.Count - 1].Row;
            var actualRow = Program.Games[gameID].Row;
            var lastFocusRow = (int)lastFocusRC.Y;

            if (gameBottom > borderGameListBottom && actualRow == maxRow)
            {
                listTop -= templateGameHeight;
                listBottom -= templateGameHeight;
                listGames.Margin = new Thickness(listLeft, listTop, listRight, listBottom);
            }
            else
            if (gameTop < borderGameListTop && actualRow > 0)
            {
                listTop += templateGameHeight;
                listBottom += templateGameHeight;
                listGames.Margin = new Thickness(listLeft, listTop, listRight, listBottom);
            }
            else
            if (gameTop < borderGameListTop && actualRow == 0 && lastFocusRow == maxRow)
            {
                listTop += templateGameHeight;
                listBottom += templateGameHeight;
                listGames.Margin = new Thickness(listLeft, listTop, listRight, listBottom);
            }
        }

        private void btnGame_Load(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var newButtonImage = GetButtonImage(btn);
            newButtonImage.Source = Net.LoadImages(Program.Games[GetGameID(btn)].PosterURL);
        }

        private void btnGame_Click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            string name = btn.Name;
            name = name.Replace("btnGameId_", "");
            int id = Int32.Parse(name);

            menuState = MenuState.RunGame;

            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    myProcess.StartInfo.FileName = Program.Games[id].DiskLink;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    myProcess.Start();

                    MaximizeProcessWindow(myProcess.MainWindowTitle);


                    // This code assumes the process you are starting will terminate itself.
                    // Given that it is started without a window so you cannot terminate it
                    // on the desktop, it must terminate itself or you can do it programmatically
                    // from this application using the Kill method.
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// WINDOWPLACEMENT showCmd - 1 for normal, 2 for minimized, 3 for maximized, 0 for hide 
        /// </summary>
        public static void MaximizeProcessWindow(string processName)
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals(processName))
                {
                    try
                    {
                        WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                        GetWindowPlacement(proc.MainWindowHandle, ref wp);

                        // Maximize window if it is in a normal state
                        // You can also do the reverse by simply checking and setting 
                        // the value of wp.showCmd
                        if (wp.showCmd == 1)
                        {
                            wp.showCmd = 3;
                        }
                        SetWindowPlacement(proc.MainWindowHandle, ref wp);
                        break;
                    }
                    catch (Exception ex)
                    {
                        // log exception here and do something
                    }
                }
            }
        }

        //======================Other============================

        public Button DeepCopy(Button element)
        {
            string shapestring = XamlWriter.Save(element);
            StringReader stringReader = new StringReader(shapestring);
            XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
            Button DeepCopyobject = (Button)XamlReader.Load(xmlTextReader);
            return DeepCopyobject;
        }

        public UIElement CloneElement(UIElement orig)
        {
            if (orig == null)
                return (null);
            string s = XamlWriter.Save(orig);
            StringReader stringReader = new StringReader(s);
            XmlReader xmlReader = XmlTextReader.Create(stringReader, new XmlReaderSettings());
            return (UIElement)XamlReader.Load(xmlReader);
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            return "";
        }

        private Image GetButtonImage(Button but)
        {
            var border = VisualTreeHelper.GetChild(but, 0);
            var image = VisualTreeHelper.GetChild(border, 0);

            return (Image) image;
        }

        private int GetGameID(Button btn) 
        {
            string name = btn.Name;
            name = name.Replace("btnGameId_", "");
            int id = Int32.Parse(name);
            return id;
        }

        private Vector GetGameRowColumn(Button btn)
        {
            var g = Program.Games[GetGameID(btn)];
            return g.RowColumn;
        }

        //======================Control============================

        private ReporterState reporterState = new ReporterState();
        private Control[] controllerControls;
        private Control[] stickControls;
        private Point[] stickControlPositions;

        private void checkGamePads()
        {
            //UpdateState();
            //bool pressA = reporterState.LastActiveState.Buttons.A == XInputDotNetPure.ButtonState.Pressed;
            //
            //if (reporterState.LastActiveState.Buttons.A == XInputDotNetPure.ButtonState.Pressed)
            //{
            //    System.Diagnostics.Debug.WriteLine("Press A");
            //}



            // Program.ConsoleGamepadState();
            //Program.GamepadState();


            ButtonsConstants but = Program.GamepadStateButton();
            if (but != ButtonsConstants.None)
            {
                MoveFocusGPad(but);
            }

            //Thread.Sleep(16);

            //Фиксирование нажатия клавиш 
            /*
            checkA.Checked = reporterState.LastActiveState.Buttons.A == XInputDotNetPure.ButtonState.Pressed;
            checkB.Checked = reporterState.LastActiveState.Buttons.B == XInputDotNetPure.ButtonState.Pressed;
            checkX.Checked = reporterState.LastActiveState.Buttons.X == XInputDotNetPure.ButtonState.Pressed;
            checkY.Checked = reporterState.LastActiveState.Buttons.Y == XInputDotNetPure.ButtonState.Pressed;
            checkStart.Checked = reporterState.LastActiveState.Buttons.Start == XInputDotNetPure.ButtonState.Pressed;
            checkBack.Checked = reporterState.LastActiveState.Buttons.Back == XInputDotNetPure.ButtonState.Pressed;
            checkGuide.Checked = reporterState.LastActiveState.Buttons.Guide == XInputDotNetPure.ButtonState.Pressed;
            checkStickLeft.Checked = reporterState.LastActiveState.Buttons.LeftStick == XInputDotNetPure.ButtonState.Pressed;
            checkStickRight.Checked = reporterState.LastActiveState.Buttons.RightStick == XInputDotNetPure.ButtonState.Pressed;
            checkShoulderLeft.Checked = reporterState.LastActiveState.Buttons.LeftShoulder == XInputDotNetPure.ButtonState.Pressed;
            checkShoulderRight.Checked = reporterState.LastActiveState.Buttons.RightShoulder == XInputDotNetPure.ButtonState.Pressed;

            checkDPadUp.Checked = reporterState.LastActiveState.DPad.Up == XInputDotNetPure.ButtonState.Pressed;
            checkDPadRight.Checked = reporterState.LastActiveState.DPad.Right == XInputDotNetPure.ButtonState.Pressed;
            checkDPadDown.Checked = reporterState.LastActiveState.DPad.Down == XInputDotNetPure.ButtonState.Pressed;
            checkDPadLeft.Checked = reporterState.LastActiveState.DPad.Left == XInputDotNetPure.ButtonState.Pressed;

            labelTriggerLeft.Text = FormatFloat(reporterState.LastActiveState.Triggers.Left);
            labelTriggerRight.Text = FormatFloat(reporterState.LastActiveState.Triggers.Right);

            labelStickLeftX.Text = FormatFloat(reporterState.LastActiveState.ThumbSticks.Left.X);
            labelStickLeftY.Text = FormatFloat(reporterState.LastActiveState.ThumbSticks.Left.Y);
            labelStickRightX.Text = FormatFloat(reporterState.LastActiveState.ThumbSticks.Right.X);
            labelStickRightY.Text = FormatFloat(reporterState.LastActiveState.ThumbSticks.Right.Y);
            */

            //Считывание долгих нажатий
            /*
            if (reporterState.LastActiveState.Buttons.Start == XInputDotNetPure.ButtonState.Pressed)
            {
                timerStart.Start();
            }
            else
            {
                timerStart.Stop();
            }
            if (reporterState.LastActiveState.Buttons.Back == XInputDotNetPure.ButtonState.Pressed)
            {
                timerBack.Start();
            }
            else
            {
                timerBack.Stop();
            }
            */

            /*
            for (int i = 0; i < 4; i++)
            {
                controllerControls[i].Visible = i == reporterState.LastActiveIndex && reporterState.LastActiveState.IsConnected;
            }
            */
            //PositionStickControl(stickControls[0], stickControlPositions[0], reporterState.LastActiveState.ThumbSticks.Left);
            //PositionStickControl(stickControls[1], stickControlPositions[1], reporterState.LastActiveState.ThumbSticks.Right);

        }

        /*
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //Program.Start();
        }

        /*
        void OnLoad(object sender, RoutedEventArgs e)
        {
            Program.Start();
        }
        */
        /*
        private void pollingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                if (reporterState.Poll())
                {
                    System.Diagnostics.Debug.WriteLine("SomeText");
                    // Invoke(new Action(UpdateState));
                    //Invoke(new Action(UpdateState));

                }
            }
        }
        */


        /*
        private void MainForm_Load(object sender, EventArgs e)
        {
            //comboDeadZone.Items.AddRange(Enum.GetNames(typeof(GamePadDeadZone)));
            //comboDeadZone.SelectedItem = reporterState.DeadZone.ToString();

            pollingWorker.RunWorkerAsync();
            Program.Start().RunWorkerAsync();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pollingWorker.CancelAsync();
        }
        
        private static string FormatFloat(float v)
        {
            return string.Format("{0:F3}", v);
        }

        private static void PositionStickControl(Control control, Point location, GamePadThumbSticks.StickValue value)
        {
            var deltaX = value.X * control.Width * 0.5f;
            var deltaY = value.Y * control.Height * -0.5f;

            //control.Location = new Point(location.X + (int)deltaX, location.Y + (int)deltaY);
            //control.Refresh();
        }
        */

        /*
        private void checkLink_CheckedChanged(object sender, EventArgs e)
        {
            reporterState.LinkTriggersToVibration = checkLink.Checked;
        }
        */
        /*
        private void comboDeadZone_SelectedValueChanged(object sender, EventArgs e)
        {
            reporterState.DeadZone = (GamePadDeadZone)Enum.Parse(typeof(GamePadDeadZone), comboDeadZone.SelectedItem as string);
        }
        */
        /*
        private void timerStart_Tick(object sender, EventArgs e)
        {
            var deadZoneInt = (int)reporterState.DeadZone;
            deadZoneInt = (deadZoneInt + 1) % Enum.GetValues(typeof(GamePadDeadZone)).Length;
            //comboDeadZone.SelectedItem = ((GamePadDeadZone)deadZoneInt).ToString();
            timerStart.Stop();
        }
        */
        /*
        private void timerBack_Tick(object sender, EventArgs e)
        {
            checkLink.Checked = !checkLink.Checked;
            timerBack.Stop();
        }
        */

        private void MoveFocusGPad(ButtonsConstants button)
        {
            switch (button)
            {
                case ButtonsConstants.DPadRight:
                    Send(Key.Right);
                    break;
                case ButtonsConstants.DPadLeft:
                    Send(Key.Left);
                    break;
                case ButtonsConstants.A:
                    Send(Key.Space);
                    break;
            }
        }

        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    };
                    InputManager.Current.ProcessInput(e);

                    // Note: Based on your requirements you may also need to fire events for:
                    // RoutedEvent = Keyboard.PreviewKeyDownEvent
                    // RoutedEvent = Keyboard.KeyUpEvent
                    // RoutedEvent = Keyboard.PreviewKeyUpEvent
                }
            }
        }

        private void HandleKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                menuState = MenuState.Desktop;
                UpdateRednderState();
            }
        }
    }
}
