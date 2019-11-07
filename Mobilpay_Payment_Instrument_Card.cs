// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Instrument_Card
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Instrument_Card
  {
    private string number;
    private string name;
    private string expYear;
    private string expMonth;
    private string cvv2;

    public Mobilpay_Payment_Instrument_Card()
    {
      this.name = "";
      this.cvv2 = "";
    }

    [XmlElement("number")]
    public string Number
    {
      get
      {
        return this.number;
      }
      set
      {
        this.number = value;
      }
    }

    [XmlElement("name")]
    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    [XmlElement("exp_year")]
    public string ExpYear
    {
      get
      {
        return this.expYear;
      }
      set
      {
        this.expYear = value;
      }
    }

    [XmlElement("exp_month")]
    public string ExpMonth
    {
      get
      {
        return this.expMonth;
      }
      set
      {
        this.expMonth = value;
      }
    }

    [XmlElement("cvv2")]
    public string Cvv2
    {
      get
      {
        return this.cvv2;
      }
      set
      {
        if (value.Length == 0 && this.number[0] != '6')
          throw new Exception("Mobilpay_Payment_Instrument_Card::loadFromXml failed: invalid cvv2");
        this.cvv2 = value;
      }
    }
  }
}
