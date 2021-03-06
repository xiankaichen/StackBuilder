﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Exporters
{
    public class ExporterCSV : Exporter
    {
        public ExporterCSV() {}
        public override string Filter => "Comma Separated Values (*.csv)|*.csv";
        public override string Extension => "csv";
        public override void Export(Analysis analysis, string filePath)
        {
            var csv = new StringBuilder();
            Solution sol = analysis.Solution;
            List<ILayer> layers = sol.Layers;
            foreach (ILayer layer in layers)
            {
                Layer3DBox layerBox = layer as Layer3DBox;
                foreach (BoxPosition bPosition in layerBox)
                {
                    csv.AppendLine(string.Format("{0};{1};{2};{3};{4};{5}",
                        1,
                        bPosition.Position.X,
                        bPosition.Position.Y,
                        bPosition.Position.Z,
                        bPosition.DirectionLength,
                        bPosition.DirectionWidth));
                }
            }
            File.WriteAllText(filePath, csv.ToString());
        }
    }
}
