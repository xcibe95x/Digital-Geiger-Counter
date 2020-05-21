using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Radiation_Logger
{
    public partial class Graph : Form
    {
        private List<string> _graphData = new List<string>();

        public List<string> GraphData
        {
            get { return _graphData; }
            set { _graphData = value; }
        }

        private readonly List<int> _values = new List<int>();
        private readonly List<string> _inputStrings = new List<string>();
        
        public Graph()
        {
            InitializeComponent();
        }

        private void splitInputDataToLists()
        {
            _inputStrings.Clear();
            _values.Clear();

            foreach (var line in _graphData)
            {
                if (line != null)
                {
                    try
                    {
                        var lineSplit = line.Replace(',', ' ').Split(' ');
                        _inputStrings.Add(lineSplit[0] + " " + lineSplit[1]);
                        _values.Add(int.Parse(lineSplit[2]));
                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }

        private void Graph_Load(object sender, EventArgs e)
        {
            chart1.Series[0].LegendText = "";
            chart1.Series[1].LegendText = "";
            splitInputDataToLists();
            if (_inputStrings.Count == _values.Count)
            {
                for (var i = 0; i < _graphData.Count; i++)
                {
                    try
                    {
                        chart1.Series[0].Points.AddXY(_inputStrings[i], _values[i]);
                        chart1.Series[1].Points.AddXY(_inputStrings[i], _values[i]);
                    }
                    catch (Exception)
                    {
                    }
                    
                }
            }
        }
    }
}
