using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Profile_Editor.Model
{
    [XmlRoot("UserSettings")]
    public class UserSettings
    {
        [XmlElement("AppLevelNames")]
        public List<AppLevelNames> AppLevelNames { get; set; }

        [XmlElement("ChairPosistions")]
        public List<ChairPositions> ChairPositions { get; set; }

        [XmlElement("Instruments")]
        public List<Instruments> Instruments { get; set; }

        [XmlElement("InstrumentsSurg")]
        public List<InstrumentsSurg> InstrumentsSurg { get; set; }

        [XmlElement("InstrumentEndo")]
        public string InstrumentEndo { get; set; }

        [XmlElement("LedLight")]
        public List<LedLight> LedLight { get; set; }

        [XmlElement("SoftKeys")]
        public List<SoftKeys> SoftKeys { get; set; }

        [XmlElement("Timers")]
        public List<Timers> Timers { get; set; }

        [XmlElement("Various")]
        public List<Various> Various { get; set; }
    }

    // new layer
    public class AppLevelNames
    {
        [XmlElement("AppLevelName")]
        public List<AppLevelName> AppLevelName { get; set; }
    }

    public class ChairPositions
    {
        [XmlElement("ChairPosition")]
        public List<ChairPosition> ChairPosition { get; set; }
    }

    public class Instruments
    {
        [XmlElement("Instrument")]
        public List<Instrument> Instrument { get; set; }
    }

    public class InstrumentsSurg
    {
        [XmlElement("InstrumentSurg")]
        public List<InstrumentSurg> InstrumentSurg { get; set; }
    }

    public class LedLight
    {
        [XmlElement("Intensity")]
        public string Intensity { get; set; }

        [XmlElement("ColorTemperature")]
        public string ColorTemperature { get; set; }

        [XmlElement("DimMode")]
        public string DimMode { get; set; }

        [XmlElement("DimIntensity")]
        public string DimIntensity { get; set; }
    }

    public class SoftKeys
    {
        [XmlElement("SoftKey1")]
        public string SoftKey1 { get; set; }

        [XmlElement("SoftKey2")]
        public string SoftKey2 { get; set; }

        [XmlElement("SoftKey3")]
        public string SoftKey3 { get; set; }

        [XmlElement("SoftKey4")]
        public string SoftKey4 { get; set; }

        [XmlElement("SoftKey5")]
        public string SoftKey5 { get; set; }

        [XmlElement("SoftKey6")]
        public string SoftKey6 { get; set; }

    }

    public class Timers
    {
        [XmlElement("Timer")]
        public List<Timer> Timer { get; set; }
    }

    public class Various
    {
        [XmlElement("Language")]
        public string Language { get; set; }
    }

    // new layer
    public class AppLevelName
    {
        [XmlElement("AppLevel")]
        public string AppLevel { get; set; }

        [XmlElement("Value")]
        public string Value { get; set; }
    }

    public class ChairPosition
    {
        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Axis1")]
        public string Axis1 { get; set; }

        [XmlElement("Axis2")]
        public string Axis2 { get; set; }

        [XmlElement("Axis3")]
        public string Axis3 { get; set; }

        [XmlElement("Axis4")]
        public string Axi41 { get; set; }

        [XmlElement("Axis5")]
        public string Axis5 { get; set; }

        [XmlElement("Axis6")]
        public string Axis6 { get; set; }
    }

    public class Instrument
    {
        [XmlElement("AppLevel")]
        public string AppLevel { get; set; }

        [XmlElement("Holder")]
        public string Holder { get; set; }

        [XmlElement("InstrumentType")]
        public string InstrumentType { get; set; }

        [XmlElement("Center")]
        public string Center { get; set; }

        [XmlElement("Rotation")]
        public string Rotation { get; set; }

        [XmlElement("CoolantMode")]
        public string CoolantMode { get; set; }

        [XmlElement("Auxilliary")]
        public string Auxilliary { get; set; }

        [XmlElement("Lux")]
        public string Lux { get; set; }
    }

    public class InstrumentSurg
    {
        [XmlElement("StepNumber")]
        public string StepNumber { get; set; }

        [XmlElement("StepActivity")]
        public string StepActivity { get; set; }

        [XmlElement("MaxPower")]
        public string MaxPower { get; set; }

        [XmlElement("Center")]
        public string Center { get; set; }

        [XmlElement("Rotation")]
        public string Rotation { get; set; }

        [XmlElement("CoolantMode")]
        public string CoolantMode { get; set; }

        [XmlElement("Auxilliary")]
        public string Auxilliary { get; set; }

        [XmlElement("Lux")]
        public string Lux { get; set; }
    }
    
    public class Timer
    {
        [XmlElement("TimerNumber")]
        public string TimerNumber { get; set; }

        [XmlElement("Direction")]
        public string Direction { get; set; }

        [XmlElement("Interval")]
        public string Interval { get; set; }
    }
}
