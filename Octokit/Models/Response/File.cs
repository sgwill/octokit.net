﻿using System;

namespace Octokit
{
    public class File
    {
        public string FileName { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
        public int Changes { get; set; }
        public string Status { get; set; }
        public string RawUrl { get; set; }
        public string BlobUrl { get; set; }
        public string Patch { get; set; }
    }
}
