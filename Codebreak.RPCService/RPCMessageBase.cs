﻿using Codebreak.Framework.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.RPCService
{
    public abstract class RPCMessageBase : BinaryQueue
    {
        private byte[] _cache;
                
        public byte[] Data
        {
            get
            {
                if (_cache == null)
                {
                    var count = base.Count;
                    var data = base.ReadBytes(count);
                    var idBytes = BitConverter.GetBytes((int)Id);
                    var lengthBytes = BitConverter.GetBytes(count);
                    _cache = new byte[8 + count];
                    Buffer.BlockCopy(lengthBytes, 0, _cache, 0, 4);
                    Buffer.BlockCopy(idBytes, 0, _cache, 4, 4);
                    Buffer.BlockCopy(data, 0, _cache, 8, count);
                }
                return _cache;
            }
        }

        public abstract int Id
        {
            get;
        }

        public RPCMessageBase()
        {
        }

        public void SetData(byte[] data)
        {
            base.WriteBytes(data);
        }

        public abstract void Deserialize();
        public abstract void Serialize();
    }
}
