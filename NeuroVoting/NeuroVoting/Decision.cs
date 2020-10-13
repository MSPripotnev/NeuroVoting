using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NeuroVoting
{
    public class Decision
    {
        #region Fields
        private XDocument xDoc
        {
            get
            {
                return xdocument;
            }
            set
            {
                xdocument = value;
                XArgs = xDoc.Root.Element("Arguments");
                XSettings = xDoc.Root.Element("Settings");
            }
        }
        private XDocument xdocument;
        private XElement XArgs;
        private XElement XSettings;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        /// <summary>
        /// Description of decision
        /// </summary>
        public string Description { get; set; }
        public string Name { get; set; }
        private string XPath;
        private int MaxWeight;
        public int PlacetSumWeight
        {
            get
            {
                int sum = 0;
                foreach (Argument arg in Argums)
                    if (arg.Placet) sum += arg.Weight;
                return sum;
            }
        }
        public int OppositeSumWeight
        {
            get
            {
                int sum = 0;
                foreach (Argument arg in Argums)
                    if (!arg.Placet) sum += arg.Weight;
                return sum;
            }
        }
        private List<Argument> argums;
        /// <summary>
        /// List of arguments
        /// </summary>
        public List<Argument> Argums
        {
            get
            {
                return argums;
            }
            private set
            {
                argums = value;
                if (xDoc != null) xDoc.Save(XPath);
            }
        }
        #endregion
        #region Construct
        /// <summary>
        /// Constuctor of new empty decision
        /// </summary>
        public Decision()
        {
            StartDate = DateTime.Now;
            Argums = new List<Argument>();
        }
        /// <summary>
        /// Constructor of existing decision
        /// </summary>
        /// <param name="XDoc">Xml-document where this decision contains</param>
        public Decision(XDocument XDoc, string path)
        {
            xDoc = XDoc;
            Name = xDoc.Root.Attribute("name").Value;
            XPath = path;
            XElement[] xArgums = XArgs.Elements().ToArray();
            List<Argument> TArgums = new List<Argument>();
            foreach (var el in xArgums)
                TArgums.Add(new Argument(el.Attribute("name").Value, bool.Parse(el.Attribute("is_placet").Value), el.Value, int.Parse(el.Attribute("weight").Value)));
            Argums = new List<Argument>(TArgums);
            Description = XSettings.Element("Description").Value;
            StartDate = DateTime.Parse(XSettings.Element("Date").Attribute("start").Value);
            if (XSettings.Element("Date").Attribute("end").Value != "")
                EndDate = DateTime.Parse(XSettings.Element("Date").Attribute("end").Value);
            else EndDate = DateTime.MinValue;
        }
        #endregion

        public double RecalcPercentage(int decimals)
        {
            double sum = 0;
            MaxWeight = 0;
            foreach (var arg in Argums)
            {
                MaxWeight += arg.Weight;
                if (arg.Placet) sum += arg.Weight;
            }
            return Math.Round(sum / MaxWeight, decimals);
        }
        #region XDocumentWork
        public void AddArgument(Argument arg)
        {
            XArgs.Add(arg.XPlace);
            xDoc.Save(XPath.ToString());
            Argums.Add(arg);
            MaxWeight += arg.Weight;
        }
        public void DelArgument(Argument arg)
        {
            Argums.Remove(arg);
            xDoc.Save(XPath);
            MaxWeight -= arg.Weight;
            XArgs.Elements().Where((XElement el) => el.Name == arg.Name).Remove();
        }
        public void XDocumentLoad(string path)
        {
            xDoc = XDocument.Load(path);
            Name = xDoc.Root.Attribute("name").Value;
            XPath = path;
        }
        public void TakeDecision(DateTime endDate)
        {
            EndDate = endDate;
            XSettings.Element("Date").Attribute("end").Value = EndDate.ToLongDateString();
            xDoc.Save(XPath);
        }
        public void SaveDecision()
        {
            XArgs.RemoveNodes();
            foreach (Argument arg in Argums)
            {
                XArgs.Add(arg.XPlace);
            }
            if (Description != null)
                XSettings.Element("Description").Value = Description;
            xDoc.Save(XPath);
        }
        #endregion
    }
    public class Argument
    {
        private readonly XElement StandartXPlace = new XElement("argument",
                new XAttribute("name", "arg"),
                new XAttribute("is_placet", "true"),
                new XAttribute("weight", "")
                );
        public XElement XPlace { get; set; }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                XPlace.Attribute("name").Value = value;
            }
        }
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                XPlace.Value = value;
            }
        }
        private bool placet;
        public bool Placet
        {
            get
            {
                return placet;
            }
            set
            {
                placet = value;
                XPlace.Attribute("is_placet").Value = value.ToString();
            }
        }
        private int weight;
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                XPlace.Attribute("weight").Value = value.ToString();
            }
        }
        public Argument(string name)
        {
            XPlace = StandartXPlace;
            Name = name;
            Placet = true;
            Description = "";
            Weight = 1;
        }
        public Argument(string name, bool is_placet)
        {
            XPlace = StandartXPlace;
            Name = name;
            Placet = is_placet;
            Description = "";
            Weight = 1;
        }
        public Argument(string name, bool is_placet, string description)
        {
            XPlace = StandartXPlace;
            Name = name;
            Placet = is_placet;
            Description = description;
            Weight = 1;
        }
        public Argument(string name, bool is_placet, int weight)
        {
            XPlace = StandartXPlace;
            Name = name;
            Placet = is_placet;
            Description = "";
            Weight = weight;
        }
        public Argument(string name, bool is_placet, string description, int weight)
        {
            XPlace = StandartXPlace;
            Name = name;
            Placet = is_placet;
            Description = description;
            Weight = weight;
        }
    }
}
