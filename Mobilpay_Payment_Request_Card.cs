// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Request_Card
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [XmlRoot("order")]
  [Serializable]
  public class Mobilpay_Payment_Request_Card : Mobilpay_Payment_Request_Abstract
  {
    private Mobilpay_Payment_Invoice objInvoice;
    private Mobilpay_Payment_Split objSplit;
    private Mobilpay_Recurrence objRecurrence;
    private Mobilpay_Payment_Instrument_Card objCard;

    public Mobilpay_Payment_Request_Card()
    {
      this.objInvoice = (Mobilpay_Payment_Invoice) null;
      this.objSplit = (Mobilpay_Payment_Split) null;
      this.objRecurrence = (Mobilpay_Recurrence) null;
      this.objCard = (Mobilpay_Payment_Instrument_Card) null;
    }

    [XmlElement("invoice")]
    public Mobilpay_Payment_Invoice Invoice
    {
      get
      {
        return this.objInvoice;
      }
      set
      {
        this.objInvoice = value;
      }
    }

    [XmlArray("split")]
    [XmlArrayItem("destination")]
    public Mobilpay_Payment_Split Split
    {
      get
      {
        return this.objSplit;
      }
      set
      {
        this.objSplit = value;
      }
    }

    [XmlElement("recurrence")]
    public Mobilpay_Recurrence Recurrence
    {
      get
      {
        return this.objRecurrence;
      }
      set
      {
        this.objRecurrence = value;
      }
    }

    [XmlElement("card")]
    public Mobilpay_Payment_Instrument_Card Card
    {
      get
      {
        return this.objCard;
      }
      set
      {
        this.objCard = value;
      }
    }
  }
}
