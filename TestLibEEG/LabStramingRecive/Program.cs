﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSL;

namespace LabStramingRecive
{
    class Program
    {
        static void Main(string[] args)
        {
            // wait until an EEG stream shows up
            liblsl.StreamInfo[] results = liblsl.resolve_stream("type", "Markers");

            // open an inlet and print meta-data
            liblsl.StreamInlet inlet = new liblsl.StreamInlet(results[0]);
            System.Console.Write(inlet.info().as_xml());

            // read samples
            string[] sample = new string[1];
            while (true)
            {
                inlet.pull_sample(sample);
                System.Console.WriteLine(sample[0]);
            }
        }
    }
}
