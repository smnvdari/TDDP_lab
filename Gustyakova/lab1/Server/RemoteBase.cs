using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;

namespace RemoteBase
{
    /// <remarks>
    /// Sample object to demonstrate the use of .NET Remoting.
    /// </remarks>
    public class SampleObject : MarshalByRefObject
    {
       
        Hashtable hTChatMsg=new Hashtable ();
        ArrayList alOnlineUser = new ArrayList();
        private int key = 0;
        
        public bool JoinToChatRoom(string name)
        {
            if (alOnlineUser.IndexOf(name) > -1)
                return false;
            else
            {
                alOnlineUser.Add(name);
                SendMsgToSvr(name + " has joined into chat room.");
                return true;
            }
            
        }
        public void LeaveChatRoom(string name)
        {
            alOnlineUser.Remove(name);
            SendMsgToSvr(name + " has left the chat room.");
        }
        public ArrayList GetOnlineUser()
        {
            return alOnlineUser;
        }

        public int CurrentKeyNo()
        {
            return key;
        }
        public void SendMsgToSvr(string chatMsgFromUsr)
        {
            //chatMsg = chatMsgFromUsr;
            hTChatMsg.Add(++key, chatMsgFromUsr);
        }
        public string GetMsgFromSvr(int lastKey)
        {
            if (key > lastKey)
                return hTChatMsg[lastKey + 1].ToString();
            else
                return "";
        }

        public float razn(float a, float b)
        {
           
                    return (b - a);

        }
    }
}
