﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace SocketCommunication.PipeData
{
    public abstract class ISocketCommand
    {
        private Socket _sourceClient;

        public Socket _SourceClient
        {
            get { return _sourceClient; }
            set { _sourceClient = value; }
        }

        private List<byte> _afterDecodeData;

        public List<byte> _AfterDecodeData
        {
            get { return _afterDecodeData; }
            set { _afterDecodeData = value; }
        }
        

        public abstract void Analysis();

        public abstract List<byte> GetCommand();

        public byte[] GetProtocolCommand()
        {
            return ProtocolRule.CreatePipeCommand(this);
        }
    }
}
