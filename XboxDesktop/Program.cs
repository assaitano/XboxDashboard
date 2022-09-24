using System;
using System.Collections.Generic;
using System.Text;
using XInputDotNetPure;
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Timers;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Interop;
using System.Xml;
using System.IO;

namespace XboxDesktop
{
    public class Program
    {
        public struct Game
        {
            public string Title;
            public string PosterURL;
            public string DiskLink;

            /*
            public Game()
            {
                Title = "";
                PosterURL = "";
                DiskLink = "";
            }
            */
        }

        public static List<Game> Games = new List<Game>();

        static ButtonsConstants lastPressButton = ButtonsConstants.None;

        private static void DellayDoublePressGamepadState(ButtonsConstants bState)
        {
            lastPressButton = bState;

            DispatcherTimer dispatcherTimer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(100) };
            dispatcherTimer.Start();
            dispatcherTimer.Tick += new EventHandler((object c, EventArgs eventArgs) =>
            {
                lastPressButton = ButtonsConstants.None;
                ((DispatcherTimer)c).Stop();
            });
        }

        public static void ConsoleGamepadState()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            System.Diagnostics.Debug.WriteLine("IsConnected {0} Packet #{1}", state.IsConnected, state.PacketNumber);
            System.Diagnostics.Debug.WriteLine("\tTriggers {0} {1}", state.Triggers.Left, state.Triggers.Right);
            System.Diagnostics.Debug.WriteLine("\tD-Pad {0} {1} {2} {3}", state.DPad.Up, state.DPad.Right, state.DPad.Down, state.DPad.Left);
            System.Diagnostics.Debug.WriteLine("\tButtons Start {0} Back {1} LeftStick {2} RightStick {3} LeftShoulder {4} RightShoulder {5} Guide {6} A {7} B {8} X {9} Y {10}",
                state.Buttons.Start, state.Buttons.Back, state.Buttons.LeftStick, state.Buttons.RightStick, state.Buttons.LeftShoulder, state.Buttons.RightShoulder,
                state.Buttons.Guide, state.Buttons.A, state.Buttons.B, state.Buttons.X, state.Buttons.Y);
            System.Diagnostics.Debug.WriteLine("\tSticks Left {0} {1} Right {2} {3}", state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y, state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
            GamePad.SetVibration(PlayerIndex.One, state.Triggers.Left, state.Triggers.Right);
            Thread.Sleep(16);
        }

        public static ButtonsConstants GamepadStateButton()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            ButtonsConstants pressButton = ButtonsConstants.None;

            if (state.DPad.Right == ButtonState.Pressed) pressButton = ButtonsConstants.DPadRight;
            if (state.DPad.Left == ButtonState.Pressed) pressButton = ButtonsConstants.DPadLeft;
            if (state.DPad.Up == ButtonState.Pressed) pressButton = ButtonsConstants.DPadUp;
            if (state.DPad.Down == ButtonState.Pressed) pressButton = ButtonsConstants.DPadDown;
            if (state.Buttons.A == ButtonState.Pressed) pressButton = ButtonsConstants.A;

            if (pressButton != lastPressButton)
            {
                if (state.DPad.Right == ButtonState.Pressed)
                {
                    DellayDoublePressGamepadState(pressButton);
                    return ButtonsConstants.DPadRight;
                }
                if (state.DPad.Left == ButtonState.Pressed)
                {
                    DellayDoublePressGamepadState(pressButton);
                    return ButtonsConstants.DPadLeft;
                }
                if (state.Buttons.A == ButtonState.Pressed)
                {
                    DellayDoublePressGamepadState(pressButton);
                    return ButtonsConstants.A;
                }
            }
            return ButtonsConstants.None;
        }

        //public void UpdateState()
        //{
        /*
        XInputCapabilities X = new XInputCapabilities();
        int result = XInput.XInputGetState(_playerIndex, ref gamepadStateCurrent);
        IsConnected = (result == 0);

        UpdateBatteryState();
        if (gamepadStateCurrent.PacketNumber != gamepadStatePrev.PacketNumber)
        {
            OnStateChanged();
        }
        gamepadStatePrev.Copy(gamepadStateCurrent);

        if (_stopMotorTimerActive && (DateTime.Now >= _stopMotorTime))
        {
            XInputVibration stopStrength = new XInputVibration() { LeftMotorSpeed = 0, RightMotorSpeed = 0 };
            XInput.XInputSetState(_playerIndex, ref stopStrength);
        }
        */
        //}

        public static void LoadDB()
        {
            foreach (string file in Directory.GetFiles("./DB/", "*.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                Game game = new Game();
                XmlNode node;
                //
                node = doc.DocumentElement.SelectSingleNode("Title");
                game.Title = node.InnerText;
                //
                node = doc.DocumentElement.SelectSingleNode("Poster");
                game.PosterURL = node.InnerText;
                //
                node = doc.DocumentElement.SelectSingleNode("DiskLink");
                game.DiskLink = node.InnerText;

                Games.Add(game);
            }
        }

        public static void ReadTestXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./DB/Game1.xml");

            Game game = new Game();
            XmlNode node;
            //
            node = doc.DocumentElement.SelectSingleNode("Title");
            game.Title = node.InnerText;
            //
            node = doc.DocumentElement.SelectSingleNode("Poster");
            game.PosterURL = node.InnerText;
            //System.Diagnostics.Debug.WriteLine(text);

            Games.Add(game);
        }

        public static void WriteTestXML()
        {
            XmlTextWriter textWriter = new XmlTextWriter("../testGame.xml", null);
            // Opens the document
            textWriter.WriteStartDocument();
            // Write comments
            textWriter.WriteComment("Game *Name*");
            // Write first element
            textWriter.WriteStartElement("Game");
            //textWriter.WriteStartElement("r", "RECORD", "urn:record");
            // Write next element
            textWriter.WriteStartElement("Title", "");
            textWriter.WriteString("Assassin's Creed: Odyssey");
            textWriter.WriteEndElement();
            // Write one more element
            textWriter.WriteStartElement("Year", "");
            textWriter.WriteString("2018");
            textWriter.WriteEndElement();
            //
            textWriter.WriteStartElement("Trailer", "");
            textWriter.WriteString("https://www.imdb.com/video/vi2362096665/?playlistId=tt8545606&ref_=tt_ov_vi");
            textWriter.WriteEndElement();
            //
            textWriter.WriteStartElement("Poster", "");
            textWriter.WriteString("https://www.imdb.com/title/tt8545606/mediaviewer/rm1678524416/?ref_=tt_ov_i");
            textWriter.WriteEndElement();
            //
            textWriter.WriteStartElement("Wikipedia", "");
            textWriter.WriteString("Set in 431 BC during the Pelopenesian War, play as either a male or female mercenary as you embark on your own epic odyssey to become a legendary Spartan hero in a world where every choice matters.");
            textWriter.WriteEndElement();
            // WriteChars
            /*
            char[] ch = new char[3];
            ch[0] = 'a';
            ch[1] = 'r';
            ch[2] = 'c';
            textWriter.WriteStartElement("Char");
            textWriter.WriteChars(ch, 0, ch.Length);
            */
            //textWriter.WriteEndElement();
            // Ends the document.
            textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
        }
    }
}
