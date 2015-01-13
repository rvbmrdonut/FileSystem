﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    /// <summary>
    /// This contains the 57 blocks of data for all the files in the file system.
    /// </summary>
    class Ldisk
    {
        private Block[] _blocks;

        public Ldisk(Block[] blocks)
        {
            _blocks = blocks;
        }

        public Ldisk()
        {
            _blocks = new Block[64];
        }
    }
}
