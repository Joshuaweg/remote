// See https://aka.ms/new-console-template for more information
using COMP586Television;
 
Remote r = new Remote();
MainScreen s = new MainScreen();
r.remotePowered += s.OnPowered;
r.remoteVolumeUp += s.OnVolumeUp;
r.remoteVolumeDown += s.OnVolumeDown;
r.remoteChannelUp += s.OnChannelUp;
r.remoteChannelDown += s.OnChannelDown;
r.remoteMuted += s.OnMuted;
r.remotePrevChannel += s.OnPrevChannel;
r.remoteChangeChannel += s.OnChangeChannel;
while (true) {
    object input = -1;
    if (s.Power)
    {
        s.displayOptions();
        Console.Write("Input: ");
    }
    else {
        Console.WriteLine("p - Power On");
        Console.Write("Input: "); 
    }
    string s_input = Console.ReadLine();
    System.Threading.Thread.Sleep(1000);
    Console.Clear();
    input = s_input;
    int num;
    Boolean isNumber = int.TryParse(s_input,out num);
    if (isNumber) { input = num; }
    switch (input) {
        case string func:
            switch (func)
            {
                case "p":
                    r.power();
                    break;
                case "vu":
                    r.volumeUp();
                    break;
                case "vd":
                    r.volumeDown();
                    break;
                case "cu":
                    r.channelUp();
                    break;
                case "cd":
                    r.channelDown();
                    break;
                case "m":
                    r.mute();
                    break;
                case "pv":
                    r.prevChannel();
                    break;
               

                default:
                    input = -1;
                    break;
            }
            break;
        case int chan:
            r.changeChannel(chan);
            break;
        
    }
    System.Threading.Thread.Sleep(3000);
    Console.Clear();
    if (input.Equals(-1)) break;


}