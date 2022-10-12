using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace COMP586Television
{
    public class MainScreen : Screen
    {
        int volumeLevel;
        int volumeAtMute;
        int channel;
        int prevChannel;
        private Boolean power;
        public Boolean Power { set { power = value; } get { return power; } }
        Boolean isMuted;
        Boolean isSettings;
        Boolean isSmartMenu;
        public void OnPowered(object Source, EventArgs e)
        {

            Power = !Power;
            if (Power)
            {
                TextReader tr = new StreamReader("ScreenConfig.txt");
                volumeLevel = Convert.ToInt32(tr.ReadLine());
                volumeAtMute = Convert.ToInt32(tr.ReadLine());
                channel = Convert.ToInt32(tr.ReadLine());
                prevChannel = Convert.ToInt32(tr.ReadLine());
                isMuted = Convert.ToBoolean(tr.ReadLine());
                isSettings = Convert.ToBoolean(tr.ReadLine());
                isSmartMenu = Convert.ToBoolean(tr.ReadLine());
                tr.Close();
                isPowered();
                readChannel();
                readVolume();
            }
            else
            {
                TextWriter tw = new StreamWriter("ScreenConfig.txt");
                tw.WriteLine(volumeLevel);
                tw.WriteLine(volumeAtMute);
                tw.WriteLine(channel);
                tw.WriteLine(prevChannel);
                tw.WriteLine(isMuted);
                tw.WriteLine(isSettings);
                tw.WriteLine(isSmartMenu);
                tw.Close();
                isPowered();
            }
        }
        public void OnVolumeUp(object Source, EventArgs e)
        {
            if (Power)
            {
                if (isMuted) OnMuted(Source, e);
                else
                {
                    if (volumeLevel < 100) volumeLevel++;
                    readVolume();
                }
            }
        }
        public void OnVolumeDown(object Source, EventArgs e)
        {
            if (Power)
            {
                if (isMuted) OnMuted(Source, e);
                else
                {
                    if (volumeLevel > 0) volumeLevel--;
                    readVolume();
                }
            }
        }
        public void OnChannelUp(object Source, EventArgs e)
        {
            if (Power)
            {
                prevChannel = channel;
                if (channel < 1000) channel++;
                else channel = 1;
                readChannel();
            }
        }
        public void OnChannelDown(object Source, EventArgs e)
        {
            if (Power)
            {
                prevChannel = channel;
                if (channel > 0) channel--;
                else channel = 1000;
                readChannel();
            }
        }
        public void OnPrevChannel(object Source, EventArgs e)
        {
            if (Power)
            {
                int temp = channel;
                channel = prevChannel;
                prevChannel = temp;
                readChannel();
            }
        }
        public void OnChangeChannel(object Source, EventArgs e, int chan)
        {
            if (Power)
            {
                prevChannel = channel;
                if (chan > 0 && chan <= 1000) channel = chan;
                readChannel();
            }
        }
        public void OnMuted(object Source, EventArgs e)
        {
            if (Power)
            {
                if (!isMuted)
                {
                    volumeAtMute = volumeLevel;
                    volumeLevel = 0;
                    isMuted = !isMuted;
                    readVolume();
                }
                else
                {
                    volumeLevel = volumeAtMute;
                    isMuted = !isMuted;
                    readVolume();
                }
            }
        }
        public MainScreen()
        {
            volumeLevel = 0;
            volumeAtMute = 0;
            channel = 0;
            prevChannel = 0;
            Power = false;
            isMuted = false;
            isSettings = false;
            isSmartMenu = false;
        }
        private void isPowered()
        {
            Console.WriteLine((Power) ? "Screen is On" : "Screen is Off");
        }
        private void readVolume()
        {
            if (!isMuted)
                Console.WriteLine("Volume Level: " + volumeLevel.ToString() + "\n\n\n");
            else Console.WriteLine("Volume Muted" + "\n\n\n");
        }
        private void readChannel()
        {
            Console.WriteLine("Channel: " + channel.ToString()+"\n\n\n");
        }
        public void displayOptions() {
            Console.WriteLine("p - Power");
            Console.WriteLine("vu - volume up");
            Console.WriteLine("vd - volume down");
            Console.WriteLine("cu - channel up");
            Console.WriteLine("cd - channel down");
            Console.WriteLine("pv - Previous channel");
            Console.WriteLine("[number] - change channel");
            Console.WriteLine("m - mute");
            Console.WriteLine("ANY OTHER KEY TO EXIT...");


        }

    }
}
