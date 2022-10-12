using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP586Television
{
    public class Remote
    {
        public delegate void remoteEventHandler(object source, EventArgs args);
        public delegate void remoteChannelEventHandler(object source, EventArgs args, int chan);
        public event remoteEventHandler remotePowered;
        public event remoteEventHandler remoteVolumeUp;
        public event remoteEventHandler remoteVolumeDown;
        public event remoteEventHandler remoteChannelUp;
        public event remoteEventHandler remoteChannelDown;
        public event remoteEventHandler remoteMuted;
        public event remoteEventHandler remotePrevChannel;
        public event remoteChannelEventHandler remoteChangeChannel;
        public event remoteEventHandler remoteOpenSettings;
        public event remoteEventHandler remoteOpenSmart;



        public void power() {
            onRemotePowered();
        
        }
        public void volumeUp() {
            onRemoteVolumeUp();
        }
        public void volumeDown()
        {
            onRemoteVolumeDown();
        }
        public void channelUp()
        {
            onRemoteChannelUp();
        }
        public void channelDown()
        {
            onRemoteChannelDown();
        }
        public void mute()
        {
            onRemoteMuted();
        }
        public void changeChannel(int chan)
        {
            onRemoteChangeChannel(chan);
        }
        public void prevChannel()
        {
            onRemotePrevChannel();
        }
        public void openSettings()
        {
            onRemoteOpenSettings();
        }
        protected virtual void onRemotePowered() {
            if (remotePowered != null) { 
               remotePowered(this, EventArgs.Empty);
            }

        }
        protected virtual void onRemoteVolumeUp()
        {
            if (remoteVolumeUp != null)
            {
                remoteVolumeUp(this, EventArgs.Empty);
            }
        }
        protected virtual void onRemoteVolumeDown()
        {
            if (remoteVolumeDown != null)
            {
                remoteVolumeDown(this, EventArgs.Empty);
            }
        }
        protected virtual void onRemoteChannelUp()
        {
            if (remoteChannelUp != null)
            {
                remoteChannelUp(this, EventArgs.Empty);
            }
        }
        protected virtual void onRemoteChannelDown()
        {
            if (remoteChannelDown != null)
            {
                remoteChannelDown(this, EventArgs.Empty);
            }
        }
        protected virtual void onRemoteMuted()
        {
            if (remoteMuted != null)
            {
                remoteMuted(this, EventArgs.Empty);
            }
        }
        protected virtual void onRemotePrevChannel()
        {
            if (remoteMuted != null)
            {
                remotePrevChannel(this, EventArgs.Empty);
            }
        }
        protected virtual void onRemoteChangeChannel(int chan)
        {
            if (remoteChangeChannel != null)
            {
                remoteChangeChannel(this, EventArgs.Empty,chan);
            }
        }
        protected virtual void onRemoteOpenSettings()
        {
            if (remoteOpenSettings != null)
            {
                remoteOpenSettings(this, EventArgs.Empty);
            }
        }
        protected virtual void onRemoteOpenSmart()
        {
            if (remoteOpenSmart != null)
            {
                remoteOpenSmart(this, EventArgs.Empty);
            }
        }
    }
}
